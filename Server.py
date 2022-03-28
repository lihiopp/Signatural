import socket, threading, re, random
import pandas as pd
from nyaa.views.users import get_activation_link

class Server:
    def __init__(self,ip,port):
        self.socket = socket.socket()
        self.socket.bind((ip,port))
        self.socket.listen(5)
        self.clients = {} # dictionary of connected users and their client sockets
        self.df = pd.read_csv(r"") # dataframe of: usernames, passwords, emails and signatures(path).
        print("Server initiallized.")
    
    def get_connection(self):
        client, addr = self.socket.accept()
        t = threading.Thread(target=handle_client , args=(self,client,client_id,))
        client_id = random.randint(1,100000)
        self.clients.update({client_id:client})

    def handle_client(self,client,client_id):
        action = client.recv(1024).decode()
        if(action=="Login"):
            server.login(self, client,client_id)
        if(action=="Signup")
            server.signup(self,client)

        status = client.recv(1024).decode() # is user an uploader / signer
        if(status=="uploader"):
            server.uploader(self, client)
        if(status=="signer"):
            server.signer(self, client) ########


    def login(self, client,client_id):
        username = client.recv(1024).decode()
        password = client.recv(1024).decode()
        while(self.df[username]!=password):
            client.send("Wrong username or password. Try again.".decode())
            username = client.recv(1024).decode()
            password = client.recv(1024).decode()
        
        # change id to username in clients dictionary
        self.clients[username] = self.clients[client_id]
        del self.clients[client_id]

        client.send("Logged in".encode())
        print(str(username) + " has logged in.")

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
        signature = # Get png file and name it after username!!!
        # Enter to database!!!
        
    def email_verification():
        activation_link = get_activation_link(user)

        tmpl_context = {
            'activation_link': activation_link,
            'user': user
        }

        email_msg = email.EmailHolder(
            subject='Verify your {} account'.format(app.config['GLOBAL_SITE_NAME']),
            recipient=user,
            text=flask.render_template('email/verify.txt', **tmpl_context),
            html=flask.render_template('email/verify.html', **tmpl_context),
        )

    email.send_email(email_msg)

    def uploader(self,client):
        requested_signer = client.recv(1024).decode()
        # check if the signer is connected to the server, check if he wants to get PDF
        # if he isn't send a message, if doesn't exist send it too.
            
        # get PDF file
        filename = self.client_soc.recv(1024).decode()
        with open(filename,'wb') as f:
            while True:
                data = self.client_soc.recv(1024)
                if not data:
                    break
                f.write(data)
        print("Got file: " + filename + " !")