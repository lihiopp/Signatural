import fitz, sys

def start(file,signature):
    doc = fitz.open(file)
    rect = fitz.Rect(200, 20, 400, 204)   # put thumbnail in upper left corner
    pix = fitz.Pixmap(signature)    # an image file
    for page in doc:
        page.insert_image(rect, pixmap = pix)
        break
    doc.saveIncr()
    doc.close()

start(sys.argv[1],sys.argv[2])
