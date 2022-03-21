import fitz

doc = fitz.open("example.pdf")
rect = fitz.Rect(200, 20, 400, 204)   # put thumbnail in upper left corner
pix = fitz.Pixmap("real.png")    # an image file
for page in doc:
    page.insert_image(rect, pixmap = pix)
    break
doc.saveIncr()
doc.close()
