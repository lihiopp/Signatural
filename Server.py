import socket, threading, re, os
import pandas as pd
from matplotlib import pyplot as plt

class Server:
    def __init__(self,ip,port):
        self.socket = socket.socket()
        self.socket.bind((ip,port))
        self.socket.listen(5)
        # dictionary of connected users and their client sockets
        self.clients = {}
        # list of busy/unavailable currently connected users to the system
        self.busy = [] 
        self.df = pd.read_csv(r"C:\Users\idd\Desktop\Michals\cyber\Signatural\Demo\users_data.csv")
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
            action = action[1:-1]
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
                    code = Server.upload(self,client,username)
                    while(code==-1):
                        code = Server.upload(self,client,username)

                action = client.recv(1024).decode()
                action = action[1:-1]
        except:
            # Connection was cut off, closes the socket
            # and deletes it from the clients dictionary
            try:
                client.close()
                del self.clients[username]
            except:
                # client hasn't logged in yet and still has
                # an id instead of a username as the dictionary key.
                del self.clients[client_id]

                
    def login(self, client,client_id):
        # Get username and password from client, or forgot password
        # statement from client
        details = client.recv(1024).decode()
        if(details=="Forgot Password"):
            while(code==-1):
                code = Server.ForgotPassword(self,client)
            return "Out"
        details = details[1:-1].split(',')
        username = details[0]
        password = details[1]

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
            user_email = tmp["email"][tmp.index[0]]
        # If given password is not the one in the df
        if(password != str(user_password)):
            client.send("Invalid password.".encode())
            return -1
        
        else:
            client.send("Logged in".encode())
            # Sends the user's email in order to perform email verification
            client.send(user_email.encode())
            response = "Valid"#client.recv(1024).decode()
            if(response=="Valid"):
                # changes client_id key to the client's username in clients dictionary
                self.clients[username] = self.clients[client_id]
                del self.clients[client_id]
                #sends number of signingn attempts and number of forgeries
                attepmts = tmp["attempts"][tmp.index[0]]
                forgeries = tmp["forgeries"][tmp.index[0]]
                string = str([attempts,forgeries])
                client.send(string.encode())

                plt.plot(range(attempts),range(forgeries), color = 'Orange')
                plt.xlabel("Num of attempts")
                plt.ylabel("Num of forgeries")
                plt.title("Number of forged signatures out of total attempts")
                path = "C:\\Users\\idd\\Desktop\\Michals\\cyber\\Signatural\\Demo\\" + username
                plt.savefig(path + "\\username"+"_graph.png")
                Server.sendFile(client,"username"+"_graph.png",path)
                
                print(str(username) + " has logged in.")
                return username

    def ForgotPassword(self,client):
        email = client.recv(1024).decode()
        if(email not in list(self.df['email'])):
            client.send("Email doesn't exists.".encode())
            return -1
        else:
            client.send("Exists".encode())
            response = client.recv(1024).deocde()
            if(response =="valid"):
                newPass = client.recv(1024).deocde() #####
                user_row_index = self.df.index[self.df["email"]==email]
                self.df.at[user_row_index,'password'] = newPass
                self.df.to_csv(r"C:\Users\idd\Desktop\Michals\cyber\Signatural\Demo\users_data.csv", index=False)
                return 0                
        

    def signup(self, client):
        reg = "[a-z0-9]+@[a-z]+\.[a-z]{2,3}" # Email format
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
        elif(email in list(self.df['email'])):
            client.send("Email is already taken.".encode())
            return "Failed"

        # If the email is not in email format
        elif(re.search(reg, email) == None):
            client.send("Got not email format.".encode())
            return "Failed"
        else:
            client.send("Valid".encode())
            response = client.recv(1024).deocde()
            if(response=="Valid"):
                # Creates a folder for the new user with their signature and files.
                path = "C:\\Users\\idd\\Desktop\\Michals\\cyber\\Signatural\\Demo\\users\\" + username
                os.mkdir(path)
        
                # Gets and Saves the client's signature, names it after username
                path = path + "\\"
                signatureName = Server.getFile(client,path)
            
                # Enters details to database
                self.df.loc[len(self.df)] = [username,password,email,0,0]
                self.df.index += 1
                self.df.to_csv(r"C:\Users\idd\Desktop\Michals\cyber\Signatural\Demo\users_data.csv", index=False)
                return "Success"


    def upload(self, client, username):
        # Adds the user to the busy users list.
        if(username not in self.busy):
            self.busy.append(username)

        requested_signer = client.recv(1024).decode()
        # If requested user is connected to the system
        if(requested_signer in self.clients):
            if(requested_signer in self.busy):
                client.send("User Unavailable.".encode())
                return -1
            else:
                message = username + " wants you to sign a PDF file. Do you accept?"
                self.clients[requested_signer].send(message.encode()) 
                response = self.clients[requested_signer].recv(1024).decode()
            
                # If signer accepts, the server gets the PDF file from the sender
                if(response == "Yes"):
                    # Adds the signer to the busy users list.
                    if(requested_signer not in self.busy):
                        self.busy.append(requested_signer)

                    client.send("Request accepted".encode())
                    path = r"Demo\\users\\" + username + "\\"

                    # The server gets the wanted file from the sender
                    filename = Server.getFile(client,path)
                    print("Got file: " + filename + "from: " + username + " !")

                    # The server sends the file to the signer.
                    Server.sendFile(self.clients[requested_signer],filename,path)
                    print("Sent file: " + filename + " to: " + requested_signer +"!")

                    # Gets the signature attempt of the signer
                    signatureName = Server.getFile(self.clients[requested_signer],path)

                    # Checks if the signature is real of forged
                    authenticity = signet.main()
                    
                    if(authenticity=="real"):
                        # Gets signed file from signer
                        self.clients[requested_signer].send("real".encode())
                        filename = Server.getFile(self.clients[requested_signer],path)

                        # Sends it to the sender
                        client.send("real".encode())
                        Server.sendFile(client,filename,path)
                    else:
                        # Notifies both users that the signature is forged
                        # and that the deal is off.
                        client.send("forged".encode())
                        self.clients[requested_signer].send("forged".encode())

                    return "Success!"
                    
                else:
                    client.send("Request denied".encode())
                    return -1
                
        else:
            client.send("User not connected.".encode())
            return -1

        self.busy.pop(username)
        self.busy.pop(requested_signer)


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
    server = Server("",55876)
    while True:
        server.get_connection()
    server.close()
    
main()
