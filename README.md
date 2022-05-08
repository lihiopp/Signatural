# Signatural: Signature Forgery Detection Software
This system is my final project of the Cyber/Softwar-Engineering major.
________________________________________________

## Introduction

In a world where there is a database of signatures of all citizens, there's a need in signing documents in government institutions and legal matters; to close deals.
In order to make counterfeiting more difficult, and also to enable signing papers from afar, I've created a system that identifies forgeries of signatures, verifies the authenticity of documents, and establishes a connection between the two sides of the deal.

## How it Works
The system runs a server, and its users are its clients, with whom it deals simultaniously. It establishes a connection between 2 users (it is the third party). One uploads a document that needs to be signed, and the other gets it. Then, the other user enters his signature. The system runs tests and compares the signature to one in its database. In case it turns out to be forged, meaning the one signing is not the person the signature belongs to, the system warns about it and does not allow the deal to be continued. In case the signature is authentic, it attaches it to the document, adds a watermark, and sends is to the uploader.


### links:
[structural_similarity](structural_similarity)
[SigNet](https://medium.com/swlh/signet-detecting-signature-similarity-using-machine-learning-deep-learning-is-this-the-end-of-1a6bdc76b04b)
[Structural Similarity Index](https://ourcodeworld.com/articles/read/991/how-to-calculate-the-structural-similarity-index-ssim-between-two-images-with-python)
[C# client](https://www.c-sharpcorner.com/article/socket-programming-in-C-Sharp/)
[backgroundWorker in c#](https://www.c-sharpcorner.com/uploadfile/mahesh/backgroundworker-in-C-Sharp/)

#### future tasks:
1. Fix multipule connections to one port problem.
1. Check client and server and see exceptions of modules... if needed: try to install Python64, torch at home.
3. Connect GUI to Client
4. Add thread to client + status variable.
5. Check MD5 hashing in c#
6. check drawSig and email verification!!!!
7. check whether os.mkdir() changes the current working directory.
8. Check about installer
9. Check the folders that the code opens and deals with, see if it's working
10. Store & run server in microsoft cloud ??? (or just use external IP of server?)
