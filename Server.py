import socket, threading, re, os
import pandas as pd
import enterSignatureWindow as drawSig
import email_verification as verify

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
        client_id = len(self.clients)

        # Creates a thread for each client and adds
        # them to the clients dictionary.
        t = threading.Thread(target=Server.handle_client ,
                             args=(self,client,client_id,))
        self.clients.update({client_id:client})

    def handle_client(self,client,client_id):
        # Handles the clients actions in the server
        try:
            while(True):
                action = client.recv(1024).decode()
                if(action=="Login"):
                    username = Server.login(self, client,client_id)
                if(action=="Signup"):
                    Server.signup(self,client)
                if(action=="Send file"):
                    Server.uploader(self,client,username)
                    
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
        while(username not in self.df['username']): ######
            client.send("Username doesn't exists. Try again.".decode())
            username = client.recv(1024).decode()
            password = client.recv(1024).decode()

        # while username and password don't match
        tmp = self.df.loc[['username'], ['password']] # get username and password columns from self.df
        while(password not in tmp['password']):
            client.send("Wrong username or password. Try again.".decode())
            username = client.recv(1024).decode()
            password = client.recv(1024).decode()
            
        # changes client_id to its username in clients dictionary
        self.clients[username] = self.clients[client_id]
        del self.clients[client_id]

        client.send("Logged in".encode())
        print(str(username) + " has logged in.")
        return username


    def signup(self, client):
        # Gets username from client
        username = client.recv(1024).decode()

        # While the username already exists: 100=invalid, 200=valid.
        while(username in self.df['username']):
            client.send("100".encode())
            username = client.recv(1024).decode()
        client.send("200".encode())
        
        # Creates a folder for the new user with their signature and files.
        path = "\\users\\ " + username
        os.mkdir(path)

        # Gets the password and the email
        password = client.recv(1024).decode()
        email = client.recv(1024).decode()
        
        reg = "[a-z0-9]+@[a-z]+\.[a-z]{2,3}" # Email format
        while(re.search(reg, email) == None):
            client.send("100".encode()) # Not in email format
            email = client.recv(1024).decode()
        client.send("200".encode()) # Email accepted

        # Verifys the email abd activates the account
        Server.email_verification(email)
        
        # Saves png file of the client's signature, names it after username
        drawSig.main(username)
        
        # Enters details to database, num of attempts and forgeries = 0!!!

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
    server = Server("127.0.0.1",12345)
    
main()
