import fitz

def start(file,signature,pageNum):
    doc = fitz.open(file)
    rect = fitz.Rect(330, 560, 530, 764) # coordinates: (x0, y0, x1, y1) - buttom right
    pix = fitz.Pixmap(signature)# an image file
    if(pageNum > len(doc) or pageNum==0):
        return "Failed"
    for page in range(len(doc)):
        if(page+1==pageNum):
            doc[page].insert_image(rect, pixmap = pix)
            break
    doc.saveIncr()
    doc.close()
    return "Success"

