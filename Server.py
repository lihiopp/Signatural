import socket, threading, re, os
import pandas as pd
#import enterSignatureWindow as drawSig
#import email_verification as verify

class Server:
    def __init__(self,ip,port):
        # folders: users folders with: their signature & files, the database csv file, email verification folder  
        self.socket = socket.socket()
        self.socket.bind((ip,port))
        self.socket.listen(5)
        self.clients = {} # dictionary of connected users and their client sockets
        self.df = pd.read_csv(r"C:\Users\idd\Desktop\Michals\cyber\Signatural\Demo_project\users_data.csv")
        # dataframe of: usernames, passwords, emails and signatures(path), num of attempts, num of forgeries.
        print("Server initiallized.")
    
    def get_connection(self):
        # Accepts connection of a client
        client, addr = self.socket.accept()
        print("got connection from: " + str(addr))
        client_id = len(self.clients)

        # Creates a thread for each client and adds
        # them to the clients dictionary.
        t = threading.Thread(target=Server.handle_client ,
                             args=(self,client,client_id,)).start()
        self.clients.update({client_id:client})

    def handle_client(self,client,client_id):
        # Handles the clients actions in the server
        try:
            action = client.recv(1024).decode()
            while(action!="Exit"):
                if(action=="Login"):
                    username = Server.login(self, client,client_id)
                    while(username == -1):
                        username = Server.login(self, client,client_id)
                if(action=="Signup"):
                    code = Server.signup(self,client)
                    while(code=="Failed"):
                        code = Server.signup(self,client)
                if(action=="Send file"):
                    Server.uploader(self,client,username)
                if(action=="Logout"):
                    new_id = len(self.clients)
                    self.clients[new_id] = self.clients[username]
                    del self.clients[username]

                action = client.recv(1024).decode()
        except ConnectionResetError:
            # Connection was cut off, closes the socket
            # and deletes it from the clients dictionary
            try:
                client.close()
                del self.clients[username]
            except UnboundLocalError:
                # client hasn't logged in yet and still has
                # an id instead of a username as the dictionary key.
                del self.clients[client_id]
            except KeyError:
                del self.clients[client_id]
                


    def login(self, client,client_id):
        # Get username and passord from client
        username = client.recv(1024).decode()
        password = client.recv(1024).decode()
        
        # if username doesn't exists
        usernames_list = self.df['username'].tolist()
        if(username not in usernames_list):
            client.send("Invalid username.".encode())
            return -1
        else:
            # Get password of user from the dataframe
            user_row_index = self.df.index[self.df["username"]==username] # Find row of user
            tmp = self.df.iloc[user_row_index] # Create data frame with this row only
            user_password = tmp["password"][tmp.index[0]] # Get the value of the cell in the password columns
            
        # If given password is not the one in the df
        if(password != str(user_password)):
            client.send("Invalid password.".encode())
            return -1
        else:
            # changes client_id key to the client's username in clients dictionary
            client.send("Logged in".encode())

            self.clients[username] = self.clients[client_id]
            del self.clients[client_id]
            print(str(username) + " has logged in.")
            return username


    def signup(self, client):
        reg = "[a-z0-9]+@[a-z]+\.[a-z]{2,3}" # Email format
        print(-1)
        # Gets user details from client
        details = client.recv(1024).decode()
        details = details[1:-1].split(',')
        username = details[0]
        password = details[1]
        email = details[2]
        
        # If the username already exists
        if(username in list(self.df['username'])):
            client.send("Username already exists.".encode())
            return "Failed"

        # If the email is not in email format
        elif(re.search(reg, email) == None):
            client.send("Got not email format.".encode())
            return "Failed"
        else:
            client.send("Valid".encode())
            # Verifys the user's email
            #Server.email_verification(email)
            
            # Creates a folder for the new user with their signature and files.
            path = "C:\\Users\\idd\\Desktop\\Michals\\cyber\\Signatural\\Demo_project\\users\\" + username
            os.mkdir(path)
        
            # Gets and Saves the client's signature, names it after username
        
            # Enters details to database
            self.df.loc[len(self.df)] = [username,password,email,0,0]
            self.df.index += 1
            print(self.df)
            self.df.to_csv('C:\\Users\\idd\\Desktop\\Michals\\cyber\\Signatural\\Demo_project\\users_data.csv', index=False)
            return "Success"


    def email_verification(email):
        # check email verification python file
        pass

    def uploader(self, client, username):
        requested_signer = client.recv(1024).decode()
        # If requested user is connected to the system
        if(requested_signer in self.clients):
            message = username + " wants you to sign a PDF file. Do you accept?"
            self.clients[requested_signer].send(message.encode()) 
            response = self.clients[requested_signer].recv(1024).decode()
            
            # If signer accepts, the server gets the PDF file from the sender.
            if(response == "Yes"):
                client.send("request accepted".encode())
                path = r"C:\\Users\\idd\\Desktop\\Michals\\signatural\\users\\" + username + "\\"
                filename = Server.getFile(client,path)
                print("Got file: " + filename + "from: " + username + " !")

                # The server sends the file to the signer.
                Server.sendFile(self.clients[requested_signer],filename,path)
                print("Sent file: " + filename + " to: " + requested_signer +"!")

                # Gets notified if the signature was real or forged
                authenticity = client.recv(1024).decode()
                if(authenticity=="real"):
                    # Gets signed file from signer and sends it to the sender
                    signatureName = Server.getFile(self.clients[requested_signer],path)
                    Server.sendFile(client,signatureName,path)
                
            else:
                client.send("request denied".encode())
                
        else:
            client.send("User not connected.".encode())

    def getFile(sender,path):
        filename = sender.recv(1024).decode()
        path = path + filename
        with open(path,'wb') as f:
            while True:
                data = client.recv(1024)
                if not data:
                    break
                f.write(data)
        return filename

    def sendFile(getter,filename,path):
        getter.send(filename.encode())
        path = path + filename
        with open (path, 'rb') as f:
            while True:
                data=f.read(1024)
                if not data:
                    break
                getter.send(data.encode())
                
def main():
    server = Server("",54876)
    while True:
        server.get_connection()
    server.close()
    
main()
