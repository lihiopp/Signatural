# Signatural: Signature Forgery Detection Software
This system is my final project of the Cyber/Softwar-Engineering major.
________________________________________________

## Introduction

In a world where there is a database of signatures of all citizens, there is a need in signing documents in government institutions and legal matters; to close deals.
In order to make counterfeiting more difficult, and also to enable signing papers from afar, I've created a system that identifies forgeries of signatures, verifies the authenticity of documents, and establishes a connection between the two sides of the deal.

## How it Works
The system runs a server, and its users are its clients, with whom it deals simultaniously. It establishes a connection between 2 users (it is the third party). One uploads a document that needs to be signed, and the other gets it. Then, the other user enters his signature. The system runs tests and compares the signature to one in its database. In case it turns out to be forged, meaning the one signing is not the person the signature belongs to, the system warns about it and does not allow the deal to be continued. In case the signature is authentic, it attaches it to the document, adds a watermark, and sends is to the uploader.


###### links:
[versign package](https://github.com/saifkhichi96/versign-core).
--> need to check the example.py file to see what -1/1 mean (what the predictions return for genuine/ forged).

[sigver module](https://github.com/luizgh/sigver).

[kaggle (datasets)](https://www.kaggle.com/divyanshrai/handwritten-signatures).
