import socket, threading, re, random
from urllib import response
import pandas as pd

class Server:
    def __init__(self,ip,port):
        self.socket = socket.socket()
        self.socket.bind((ip,port))
        self.socket.listen(5)
        self.clients = {} # dictionary of connected users and their client sockets
        #self.df = pd.read_csv(r"") # dataframe of: usernames, passwords, emails and signatures(path).
        print("Server initiallized.")
    
    def get_connection(self):
        client, addr = self.socket.accept()
        t = threading.Thread(target=Server.handle_client , args=(self,client,client_id,))
        client_id = len(self.clients)
        self.clients.update({client_id:client})

    def handle_client(self,client,client_id):
        action = client.recv(1024).decode()
        if(action=="Login"):
            username = Server.login(self, client,client_id)
        if(action=="Signup"):
            Server.signup(self,client)

        status = client.recv(1024).decode() # is the user an uploader / signer
        if(status=="uploader"):
            Server.uploader(self, client, username)
        if(status=="signer"):
            Server.signer(self, client, username) ####


    def login(self, client,client_id):
        username = client.recv(1024).decode()
        password = client.recv(1024).decode()
        while(self.df[username]!=password): ######
            client.send("Wrong username or password. Try again.".decode())
            username = client.recv(1024).decode()
            password = client.recv(1024).decode()
        
        # change id to username in clients dictionary
        self.clients[username] = self.clients[client_id]
        del self.clients[client_id]

        client.send("Logged in".encode())
        print(str(username) + " has logged in.")
        return username

    def signup(self, client):
        username = client.recv(1024).decode()
        while(username in self.df['username']):
            client.send("100".encode()) # Username already exists
            username = client.recv(1024).decode()
        client.send("200".encode()) # Username accepted
        
        password = client.recv(1024).decode()
        while(len(password) < 6 ):
            client.send("100".encode()) # Password has less than 6 chars
            password = client.recv(1024).decode()
        client.send("200".encode()) # Password accepted
        
        email = client.recv(1024).decode()
        reg = "[a-z0-9]+@[a-z]+\.[a-z]{2,3}" # Email format
        while(re.search(reg, email) == None):
            client.send("100".encode()) # Not in email format
            email = client.recv(1024).decode()
        client.send("200".encode()) # Email accepted
        # ADD EMAIL VERIFICATION!!!
        #signature = # Get png file and name it after username!!!
        # Enter to database!!!
        
    def email_verification():
        pass

    def uploader(self,client,username):
        requested_signer = client.recv(1024).decode()
        if(requested_signer in self.clients): # requested user is connected to the system
            message = username + " wants you to sign a PDF file. Do you accept?"
            self.clients[requested_signer].send(message.encode()) 
            response = self.clients[requested_signer].recv(1024).decode()
            if(response == "Yes"):
                client.send("request accepted".encode()) # clients sends his file name in response
                filename = client.recv(1024).decode()
                with open (filename, 'rb') as f:
                    while True:
                        data=f.read(1024)
                        if not data:
                            break
                        client.send(data)
            else:
                client.send("request denied".encode())
                
        else:
            client.send("User not connected.".encode())
            
        # get PDF file
        filename = self.client_soc.recv(1024).decode()
        with open(filename,'wb') as f:
            while True:
                data = self.client_soc.recv(1024)
                if not data:
                    break
                f.write(data)
        print("Got file: " + filename + " !")
    
def main():
    server = Server("127.0.0.1",12345)
    
main()