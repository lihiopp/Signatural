# Signatural: Signature Forgery Detection Software
This system is my final project of the Cyber/Softwar-Engineering major.
________________________________________________

## Introduction

In a world where there is a database of signatures of all citizens, there's a need in signing documents in government institutions and legal matters; to close deals.
In order to make counterfeiting more difficult, and also to enable signing papers from afar, I've created a system that identifies forgeries of signatures, verifies the authenticity of documents, and establishes a connection between the two sides of the deal.

## How it Works
The system runs a server, and its users are its clients, with whom it deals simultaniously. It establishes a connection between 2 users (it is the third party). One uploads a document that needs to be signed, and the other gets it. Then, the other user enters his signature. The system runs tests and compares the signature to one in its database. In case it turns out to be forged, meaning the one signing is not the person the signature belongs to, the system warns about it and does not allow the deal to be continued. In case the signature is authentic, it attaches it to the document, adds a watermark, and sends is to the uploader.


### links:
[versign package](https://github.com/saifkhichi96/versign-core).

[sigver module](https://github.com/luizgh/sigver).

[kaggle (datasets)](https://www.kaggle.com/divyanshrai/handwritten-signatures).

[Add image to PDF file](https://stackabuse.com/working-with-pdfs-in-python-adding-images-and-watermarks/).

[EPS converter API](https://www.api2convert.com/docs/getting_started/api_key.html)


###### current errors & future tasks:
1. Need to check out example.py of versign and figure what -1 / 1 stand for.
2. Decide whether to use an eps converter's API or install Ghostscript.
3. Install python 64bit version - and install torch package.
4. Try to install versign & fitz at home.
5. Create GUI using c#
6. Store & run server in microsoft cloud.
