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
    msg.set_content('Enter the code below in the required place to activate your account.')

    image_cid1 = make_msgid(domain='signatural.lihiopp.logo')
    image_cid2 = make_msgid(domain='signatural.lihiopp.twitter')
    image_cid3 = make_msgid(domain='signatural.lihiopp.instagram')
    image_cid4 = make_msgid(domain='signatural.lihiopp.youtube')
    image_cid5 = make_msgid(domain='signatural.lihiopp.tempverify')
    image_cid6 = make_msgid(domain='signatural.lihiopp.contactus')
    image_cid7 = make_msgid(domain='signatural.lihiopp.decoration')

    file = open(os.path.join(sys.path[0], "verify\\index.html"), "r")
    msg.make_related()
    new_file = file.read().replace("{name}", username).replace("{image_cid1}", image_cid1[1:-1]).replace("{image_cid2}", image_cid2[1:-1]).replace("{image_cid3}", image_cid3[1:-1]).replace("{image_cid4}", image_cid4[1:-1]).replace("{image_cid5}", image_cid5[1:-1]).replace("{image_cid6}", image_cid6[1:-1]).replace("{image_cid7}", image_cid7[1:-1])
    msg.add_alternative(new_file, subtype='html')

    # creates a png of random characters - the verification code
    verify = ImageCaptcha(width = 560, height = 180)
    ran = ''.join(random.choices(string.ascii_uppercase + string.digits, k = 10))    
    captcha_text = str(ran)
    data = verify.generate(captcha_text) 
    verify.write(captcha_text, os.path.join(sys.path[0], "verify\\tempverify.png"))

    # adds the required pictures to the email we want to send.
    with open(os.path.join(sys.path[0], "verify\\logo.png"), 'rb') as img:
        maintype, subtype = mimetypes.guess_type(img.name)[0].split('/')
        msg.get_payload()[1].add_related(img.read(), 
                                             maintype=maintype, 
                                             subtype=subtype, 
                                             cid=image_cid1)
    with open(os.path.join(sys.path[0], "verify\\twitter.png"), 'rb') as img:
        maintype, subtype = mimetypes.guess_type(img.name)[0].split('/')
        msg.get_payload()[1].add_related(img.read(), 
                                             maintype=maintype, 
                                             subtype=subtype, 
                                             cid=image_cid2)
    with open(os.path.join(sys.path[0], "verify\\instagram.png"), 'rb') as img:
        maintype, subtype = mimetypes.guess_type(img.name)[0].split('/')
        msg.get_payload()[1].add_related(img.read(), 
                                             maintype=maintype, 
                                             subtype=subtype, 
                                             cid=image_cid3)
    with open(os.path.join(sys.path[0], "verify\\youtube.png"), 'rb') as img:
        maintype, subtype = mimetypes.guess_type(img.name)[0].split('/')
        msg.get_payload()[1].add_related(img.read(), 
                                             maintype=maintype, 
                                             subtype=subtype, 
                                             cid=image_cid4)
    with open(os.path.join(sys.path[0], "verify\\tempverify.png"), 'rb') as img:
        maintype, subtype = mimetypes.guess_type(img.name)[0].split('/')
        msg.get_payload()[1].add_related(img.read(), 
                                             maintype=maintype, 
                                             subtype=subtype, 
                                             cid=image_cid5)
    with open(os.path.join(sys.path[0], "verify\\contact.png"), 'rb') as img:
        maintype, subtype = mimetypes.guess_type(img.name)[0].split('/')
        msg.get_payload()[1].add_related(img.read(), 
                                             maintype=maintype, 
                                             subtype=subtype, 
                                             cid=image_cid6)
    with open(os.path.join(sys.path[0], "verify\\decor.png"), 'rb') as img:
        maintype, subtype = mimetypes.guess_type(img.name)[0].split('/')
        msg.get_payload()[1].add_related(img.read(), 
                                             maintype=maintype, 
                                             subtype=subtype, 
                                             cid=image_cid7)

    # sends the email and returns the chosen verifiction code
    try:
        smtpserver = smtplib.SMTP_SSL('smtp.gmail.com', 465)
        smtpserver.ehlo()
        smtpserver.login("signaturalteam", "zurwyvbisqaptulk") # special password to enable python to send mails.
        smtpserver.sendmail("Signatural Team <signaturalteam@gmail.com>", "signaturalteam@gmail.com", msg.as_string())
        smtpserver.close()
        print('Email sent!')
        os.remove(os.path.join(sys.path[0], "verify\\tempverify.png"))
        return(captcha_text)
    except:
        print('Something went wrong...')


verification_code = ""
def send_verify(username, emailaddr):
    '''Sends mail and returns the required verification code.'''
    print("Sending verification email...")
    global verification_code
    verification_code = send_email(username, emailaddr) 

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