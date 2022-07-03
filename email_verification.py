import os, sys, random
import smtplib
from email.mime.multipart import MIMEMultipart
from email.mime.text import MIMEText

def send(email):
    mail_content = '''Hello,
Thank you for joining us! We are more than happy to welcome you to our family :)
Just one more thing! Please enter the following code to the text box in our app,
so that we can verify that it is you and activate your account.
If your do not know what we are talking about, please ignore this email. Thank you!"
Code: '''
    code = str(random.randint(0, 3000))
    mail_content += code
    #The mail addresses and password
    sender_address = 'signaturalteam@gmail.com'
    sender_pass = '326195542'
    receiver_address = email
    #Setup the MIME
    message = MIMEMultipart()
    message['From'] = sender_address
    message['To'] = receiver_address
    message['Subject'] = 'Verify your email address and account!' #The subject line
    #The body and the attachments for the mail
    message.attach(MIMEText(mail_content, 'plain'))
    #Create SMTP session for sending the mail
    session = smtplib.SMTP('smtp.gmail.com', 587) #use gmail with port
    session.starttls() #enable security
    session.login(sender_address, sender_pass) #login with mail_id and password
    text = message.as_string()
    session.sendmail(sender_address, receiver_address, text)
    session.quit()
    print(code)

send(sys.argv[1])
