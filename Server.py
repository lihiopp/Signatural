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
        #self.df = pd.read_csv(r"") # dataframe of: usernames, passwords, emails and signatures(path), num of attempts, num of forgeries.
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
                if(action=="Signup"):
                    Server.signup(self,client)
                if(action=="Send file"):
                    Server.uploader(self,client,username)

                action = client.recv(1024).decode()
        except RuntimeError:
            # Connection was cut off, closes the socket
            # and deletes it from the clients dictionary
            try:
                client.close()
                del self.clients[username]
            except KeyError:
                # client hasn't logged in yet and still has
                # an id instead of a username as the dictionary key.
                del self.clients[client_id]
                


    def login(self, client,client_id):
        # Get username and passord from client
        username = client.recv(1024).decode()
        password = client.recv(1024).decode()

        # while username doesn't exists
        if(username not in self.df['username']): ######
            client.send("Username doesn't exists. Try again.".decode())
            return

        else:
            # Get password of user from the dataframe
            user_row_index = self.dataFrame.index[self.dataFrame["username"]==username]
            user_password = self.dataFrame.iloc[user_row_index]["password"]

        # If given password is not the one in the df
        if(password != user_password):
            client.send("Wrong username or password. Try again.".decode())

        else:
            # changes client_id key to the client's username in clients dictionary
            self.clients[username] = self.clients[client_id]
            del self.clients[client_id]

            client.send("Logged in".encode())
            print(str(username) + " has logged in.")
            return username


    def signup(self, client):
        reg = "[a-z0-9]+@[a-z]+\.[a-z]{2,3}" # Email format
        
        # Gets user details from client
        username = client.recv(1024).decode()
        password = client.recv(1024).decode()
        email = client.recv(1024).decode()
        
        # If the username already exists
        if(username in self.df['username']):
            client.send("Invalid1".encode())
            return

        # If the email is not in email format
        if(re.search(reg, email) == None):
            client.send("Invalid2".encode())
        
        else:
            client.send("Valid".encode())

            # Verifys the user's email
            Server.email_verification(email)
            
            # Creates a folder for the new user with their signature and files.
            path = "\\users\\ " + username
            os.mkdir(path)
        
            # Saves the client's signature, names it after username
            drawSig.main(username)
        
            # Enters details to database
            df = pd.DataFrame([username, password, email, 0, 0],
                              columns=['username', 'password','email',
                                       'attempts','forgeries'])
            self.df = pd.concat([self.df, df])
            self.df.to_csv('C:\\Users\\idd\\Desktop\\Michals\\cyber\\Signatural\\project\\users_data.csv', index=False)
            # check if needs to press ok when asked about replace existing file

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
                filename = client.recv(1024).decode()
                path = r"C:\\Users\\idd\\Desktop\\Michals\\signatural\\users\\" + username + "\\" + filename
                with open(path,'wb') as f:
                    while True:
                        data = self.client_soc.recv(1024)
                        if not data:
                            break
                        f.write(data)
                print("Got file: " + filename + "from: " + username + " !")

                # The server sends the file to the signer.
                self.clients[requested_signer].send(filename.encode())
                with open (path, 'rb') as f:
                    while True:
                        data=f.read(1024)
                        if not data:
                            break
                        self.clients[requested_signer].send(data.encode())
                print("Sent file: " + filename + " to: " + requested_signer +"!")
            else:
                client.send("request denied".encode())
                
        else:
            client.send("User not connected.".encode())
        
    
def main():
    while True:
        server = Server("127.0.0.1",32619)
        server.get_connection()
    
main()
