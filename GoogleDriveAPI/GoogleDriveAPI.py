# Authantication Flow
'''
To firstly give the application access to google drive -
authanticate the application with Google -
you need to run the authanticate() function once (1), then change it to
the start() function afterwards (2).
    1) Authanticate the app manually by opening the given url
       and entering the code shown there. It creates "credentials.json".
    2) Suthanticate automatically by loading "credentials.json".

'''
import sys
import webbrowser # Is needed only for the authanticate() function.
from pydrive.drive import GoogleDrive
from pydrive.auth import GoogleAuth

def authanticate():
    ''' Authorises the application with the user's code entered manually.
        Required once a day.'''
    from pydrive.auth import GoogleAuth
    gauth = GoogleAuth()
    auth_url = gauth.GetAuthUrl() # Create authentication url user needs to visit
    webbrowser.open(auth_url, new=1) # Open url in browser
    code=input() # Enter authorization code shown there manually
    gauth.Auth(code) # Authorize and build service from the code
    gauth.SaveCredentialsFile('credentials.json') # Save credentials.json
    global drive
    drive = GoogleDrive(gauth)

    
def start():
    ''' Authorises the application with google cloud platform. '''
    gauth = GoogleAuth()
    auth_url = gauth.GetAuthUrl() # Create authentication url user needs to visit

    gauth.LoadCredentialsFile("credentials.json")
    gauth.Authorize()
    gauth.SaveCredentialsFile("credentials.json")
    global drive
    drive = GoogleDrive(gauth)

def upload(filepath,title):
    ''' Uploads a specific file to google drive. '''
    #title = filepath.split('\\')[-1]
    textfile = drive.CreateFile({'title':title})
    textfile.SetContentFile(filepath)
    textfile.Upload()

def download(filename,path):
    ''' Downloads a specific file from google drive. '''
    try:
        files_dic = list_files()
        file = drive.CreateFile({'id': files_dic[filename]})
        file.GetContentFile(path+filename)
    except KeyError:
        print("File not found.")
    
def list_files():
    ''' Creates a dictionary of filenames and their file id on google drive. '''
    dic = {}
    file_list = drive.ListFile().GetList()
    for file in file_list:
        title = str(file['title'])
        file_id = str(file['id'])
        string = title + " : " + file_id
        dic[title] = file_id
    return dic

