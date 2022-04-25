import threading, socket

class client:
    def __init__(self,ip,port):
        self.socket = socket.socket()
        self.socket.bind((ip,port))
        self.socket.connect((ip,port))
        print("Client Initialized and connected to server.")
    
    def registry(self,ip,port):
        
