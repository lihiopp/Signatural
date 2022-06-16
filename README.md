# Signatural: Signature Forgery Detection Software
Signature forgery detection sofware that enables sending and digital signing of files.
________________________________________________

## Introduction

Signing papers is needed in every aspect of our daily lives, though it only takes a couple of seconds. To save the long way a person has to go just to sign a document, there's a need in a digital paper signing softwar. Also, in a world where the demand for protecting one's personal identity arises, making signature counterfeiting harder is important. As a part of my graduation project in the Cyber major, I have created a system that establishes a connection between two clients, enables signing on papers and detects forgery attempts. It stores all files in google drive.

## Technologies:
Please note that this project runs on windows and supports PDF files only.
 * Python 3.8 (64 bit)
 * .net framework 4.8 (using c#)
 * tkinter 8.6.12
 * Google Drive API v3
 * pydrive
 * PuMyPDF 1.19.6
 * scikit-image 0.19.3
 * torch 1.11.0

## Installation
To setup this project, install it locally and follow the following steps.

```git clone https://github.com/lihiopp/Signatural.git```

### Install Packcages
On the **server** machine:
```
$ pip install pydrive
$ pip install PuMyPDF
$ pip install scikit-image
$ pip install torch
```
On the **client** machine: ```pip install pydrive```

### Get Google Drive's API ready
To start using Google Drive's API that is used in this project, you need to get authantication for Google Services APIs. These guidelines are meant to get authantication to use the google drive account that I have created for ***this project only***. In case you are intrested in using your own drive account or start your own application, [view here](https://d35mpxyw7m7k7g.cloudfront.net/bigdata_1/Get+Authentication+for+Google+Service+API+.pdf).
  1. Run the authantication() function in the GoogleDriveAPI.py library.
  2. A website was opened in your browser. Click "continue" and copy the given code. Paste it in your terminal and press enter.
  3. Once you get "Authantication Successful" output you are good to go.

Please note that this manual authantication is needed every once in a while because of Google's security requirements, otherwise you will get a credentials error. With each running of the code this process is done automaticaly. Also, there is a 100 authantications limit for the same reason.

### Arrange Data Base
A users_data.csv file contains the details of the system's signed users. Create one on the server machine before your first running in this format:
```
# Python Implementation 
import pandas as pd
import numpy as np

data = np.array([['your_name', 'your_password', 'your_email',0,0]])
df = pd.DataFrame(data,columns=['username', 'password', 'email','attempts','forgeries'])
df.to_csv("users_data.csv")
```

## Implementation
### Signet: forgery detection
The system performs offline handwritten signature verification of the static type. That is, it uses 2 signature drawings, it does not monitor them whilst the signer is signing. To perform such thing, this project used image processing methods and the mathematical modules: [Structure Similarity](https://ourcodeworld.com/articles/read/991/how-to-calculate-the-structural-similarity-index-ssim-between-two-images-with-python) and [Mean Squared Error](https://www.freecodecamp.org/news/machine-learning-mean-squared-error-regression-line-c7dde9a26b93/).

![MSE](https://cdn-media-1.freecodecamp.org/images/hmZydSW9YegiMVPWq2JBpOpai3CejzQpGkNG)
![SSIM](https://miro.medium.com/max/1400/0*N-h0ov6YYCJ_tm4U.png)


These provied % of similarity: **low SSIM means forgery, while low MSE means real.** Combining the two, I've set a range in which the result is either "real" or "forged".


### Email verification
Using an SMTP server, we are able to send emails in gmail using python. If you are interested in implementing this in your code, lower the security level of your google account:

```>> Go to your Google Account >> Security >> Turn On "Less secure app access" >> Save```


## References:
[SigNet](https://medium.com/swlh/signet-detecting-signature-similarity-using-machine-learning-deep-learning-is-this-the-end-of-1a6bdc76b04b)

[Structural Similarity Index](https://ourcodeworld.com/articles/read/991/how-to-calculate-the-structural-similarity-index-ssim-between-two-images-with-python)

[C# client](https://www.c-sharpcorner.com/article/socket-programming-in-C-Sharp/)

[backgroundWorker in c#](https://www.c-sharpcorner.com/uploadfile/mahesh/backgroundworker-in-C-Sharp/)
