import os
import sys
from email.message import EmailMessage
from email.utils import make_msgid
import mimetypes
import smtplib
from captcha.image import ImageCaptcha
import string    
import random

def send_email(username, emailaddr):
    ''' Creates a verification email and sends it to the registered user' gmail account.'''
    # create the mail intself.
    msg = EmailMessage()
    msg['Subject'] = 'Verify Your Account!'
    msg['From'] = 'Signatural Team <signaturalteam@gmail.com>'
    msg['To'] = '{name} <{mail}>'.format(name = username, mail = emailaddr)
    msg.set_content('Enter the code in the required place to activate your account: 12345')

    # creates a png of random characters - the verification code
    try:
        smtpserver = smtplib.SMTP_SSL('smtp.gmail.com', 465)
        smtpserver.ehlo()
        smtpserver.login("signaturalteam", "zurwyvbisqaptulk") # special password to enable python to send mails.
        smtpserver.sendmail("Signatural Team <signaturalteam@gmail.com>", "signaturalteam@gmail.com", msg.as_string())
        smtpserver.close()
        return 12345
        
    except:

verification_code = ""
def send_verify(username, emailaddr):
    '''Sends mail and returns the required verification code.'''
    global verification_code
    verification_code = send_email(username, emailaddr)
    return verification_code

def check_verify(code, client):
    '''Checks the verifiction code entered by the user, to see if it matches the one in the sent verification email.'''
    print("Got verification code. Checking validity.")
    input_text = code # verification code the user enters.
    global verification_code
    print(verification_code)
    print("Got: ",input_text, ", Expected: ",verification_code)
    if input_text == verification_code:
        client.send("Valid".encode())
    else:
        client.send("Invalid".encode())

def main(func, username, email):
    if(sys.argv[1]=="send_verify"):
        print(send_verify(username,email))
    elif(sys.argv[1]=="check_verify"):
        check_verify(code, client)

main(sys.argv[1],sys.argv[2],sys.argv[3])
