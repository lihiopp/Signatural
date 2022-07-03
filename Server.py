import socket, threading, re, os, time
import pandas as pd
from GoogleDriveAPI import GoogleDriveAPI
import addSigtoPDF as merge
import signet

class Server:
    def __init__(self,ip,port):
        self.socket = socket.socket()
        self.socket.bind((ip,port))
        self.socket.listen(5)
        # dictionary of connected users and their client sockets
        self.clients = {}
        # list of busy/unavailable and currently connected users to the system
        self.busy = []
        self.available = []
        self.df = pd.read_csv(os.getcwd() + "\\users_data.csv")
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
            action = action
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
                    print(username+ " is preaparing to send file...")
                    code = Server.upload(self,client,username)
                    while(code==-1):
                        code = Server.upload(self,client,username)
                if(action=="Sign file"):
                    print(action)
                    self.available.append(username)
                    print(username+ " is preaparing to sign file...")
                    
                action = client.recv(1024).decode()
                action = action
        except Exception as e:
            print(e)
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
        details = details.split(',')
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
            email = tmp["email"][tmp.index[0]]
        # If given password is not the one in the df
        if(password != str(user_password)):
            client.send("Invalid password.".encode())
            return -1
        
        else:
            client.send(("Logged in," + email).encode())
            response = client.recv(1024).decode()
            if(response=="Valid"):
                # Creates the activity graph for the user and sends it
                attempts = str(tmp["attempts"][tmp.index[0]])
                forgeries = str(tmp["forgeries"][tmp.index[0]])
                client.send((attempts+","+forgeries).encode())

                # Replace client_id with username in the clients dictionary
                self.clients[username] = self.clients[client_id]
                del self.clients[client_id]
                
                print(str(username) + " has logged in.")
                return username


    def ForgotPassword(self,client):
        email = client.recv(1024).decode()
        if(email not in list(self.df['email'])):
            client.send("Email doesn't exists.".encode())
            return -1
        else:
            client.send("Exists".encode())
            newPass = client.recv(1024).deocde()
            user_row_index = self.df.index[self.df["email"]==email]
            self.df.at[user_row_index,'password'] = newPass
            self.df.to_csv(os.getcwd() + "\\users_data.csv", index=False)
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

            # Creates a folder for the new user with their signature and attempted signatures.
            path = os.getcwd() + "\\users"
            if(os.path.exists(path) == False):
                os.mkdir(path)
            path = os.getcwd() +"\\users\\" + username
            os.mkdir(path)
            # Gets and Saves the client's signature, names it after his username
            path = path + "\\"
            try:
                current_dir = os.getcwd()
                os.chdir(current_dir+'\GoogleDriveAPI')
                GoogleDriveAPI.start()
            except:
                GoogleDriveAPI.authanticate()
                GoogleDriveAPI.start()
            finally:
                GoogleDriveAPI.download(username+'.png',path)
                os.chdir(current_dir)
            
            # Enters details to database
            self.df.loc[len(self.df)] = [username,password,email,0,0]
            self.df.index += 1
            self.df.to_csv(os.getcwd() + "\\users_data.csv", index=False)
            print(username + "signed in.")
            return "Success"


    def upload(self, client, username):
        # Adds the user to the busy users list.
        if(username not in self.busy):
            self.busy.append(username)
            
        requested_signer = client.recv(1024).decode()
        print(requested_signer)
        # If requested user is connected to the system
        if(requested_signer in self.clients):
            if((requested_signer in self.busy) or (requested_signer not in self.available)):
                client.send("User Unavailable.".encode())
                self.busy.remove(username)
                print(username + " looked for an unavailable user.")
                return -1
            else:
                message = username + " wants you to sign a PDF file. Do you accept?"
                socket = self.clients[requested_signer]
                response = "Yes"
                # If signer accepts, the server gets the PDF file from the sender
                if(response == "Yes"):
                    # Adds the signer to the busy users list
                    # and removes him from the available one.
                    
                    self.busy.append(requested_signer)
                    self.available.remove(requested_signer)
                    client.send("User available".encode())
                    print(username + " is sending a file to " + requested_signer)
                    sender_path = os.getcwd()+ r"\\users\\" + username + "\\"

                    # The server gets the file of the sender
                    filename = client.recv(1024).decode()
                    current_dir = os.getcwd()
                    os.chdir(current_dir+'\GoogleDriveAPI')
                    GoogleDriveAPI.start()
                    GoogleDriveAPI.download(filename,sender_path)
                    os.chdir(current_dir)
                    #

                    # The server sends the filename to the signer
                    # so that he can download it.
                    self.clients[requested_signer].send(filename.encode())
                    time.sleep(30)
                    # Gets the signature attempt of the signer
                    signer_path = os.getcwd()+ r"\\users\\" + requested_signer + "\\"
                    current_dir = os.getcwd()
                    os.chdir(current_dir+'\GoogleDriveAPI')
                    GoogleDriveAPI.download(requested_signer+"_sig.png",signer_path)
                    os.chdir(current_dir)
                    signatureName = requested_signer+"_sig.png"
                    #
                    
                    # Checks if the signature is real of forged
                    authenticity = signet.main(signer_path+requested_signer+'.png',signer_path+signatureName)
                    print(authenticity)
                    
                    # Updates activity status: attempts and forgeries
                    user_row_index = self.df.index[self.df["username"]==username]
                    self.df.at[user_row_index[0], 'attempts'] += 1
                    
                    if(authenticity=="real"):
                        # Adds signature to file
                        status = merge.start(sender_path+filename,signer_path+signatureName,1)
                        # Notifys signer that the signature is real
                        if(status=="Failed"):
                            self.clients[requested_signer].send("real,Failed".encode())
                            client.send("real,Failed".encode())
                            return
                        

                        # Renames the signed file (the result) according to the number of identical files
                        signed_filename = filename.split('.')[0]+"_signed."+filename.split('.')[1]
                        os.rename(sender_path+filename, sender_path+signed_filename)

                        # Uploads it to drive
                        os.chdir(current_dir+'\GoogleDriveAPI')
                        GoogleDriveAPI.upload(sender_path+signed_filename,signed_filename)
                        os.chdir(current_dir)

                        # Sends the name to the sender so that he can download it
                        self.clients[requested_signer].send(("real,Success,"+signed_filename).encode())
                        client.send(("real,Success,"+signed_filename).encode())
                        client.send(signed_filename.encode())
                    else:
                        # Notifies both users that the signature is forged
                        # and that the deal is off.
                        self.df.at[user_row_index[0], 'forgeries'] += 1
                        client.send("forged".encode())
                        self.clients[requested_signer].send("forged".encode())

                    # Save changes on dataframe
                    current_dir = os.getcwd()
                    os.remove(os.getcwd() + "\\users_data.csv")
                    self.df.to_csv(current_dir+"\\users_data.csv", index=False)
                    return "Success!"
                    
                else:
                    client.send("Request denied".encode())
                    return -1
                
        else:
            client.send("User not connected.".encode())
            self.busy.remove(username)
            return -1

        self.busy.remove(username)
        self.busy.remove(requested_signer)


def main():
    server = Server("",55876)
    while True:
        server.get_connection()
    server.close()
    
main()
