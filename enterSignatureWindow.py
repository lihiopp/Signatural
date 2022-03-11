import tkinter as tk
from PIL import ImageGrab

def create_window():
    root = tk.Tk()
    root.title("Enter Signature Here:")
    root.geometry('400x250+400+200') #set dimensions & place of window
    return root


coordinates=["x","y"] #coordinates (x,y) of mouse
def mmove(event):
    '''Saves the mouse's cordinates and prints them.'''
    coordinates[0]= event.x
    coordinates[1]= event.y
    print(event.x,event.y)


def draw(event):
    '''Draws signature on canvas according to mouse movements.'''
    newCoordsx = event.x
    newCoordsy = event.y
    canvas.create_line(coordinates[0],coordinates[1],newCoordsx,newCoordsy,fill="black")

def clearScreen():
    '''Clears canvas.'''
    canvas.delete("all")
    
def saveSignature():
    '''Saves the signature as a png file.'''
    #canvas.postscript(file="signature1.eps", colormode='color')
    #img = Image.open("signature1" + '.eps')
    #img.save("signature1" + '.eps', 'eps')
    
    root.destroy()


def create_canvas(root):
    '''Createa a canvas inside the window.'''
    canvas = tk.Canvas(root,width=400, height=200, bg = "white", cursor="cross")
    canvas.pack()
    tk.Label(root, text="Draw your signature, enter 'Done!' when finished.").pack()
    return canvas

def create_buttons():
    '''Creates a clear & done buttons.'''
    button_clear = tk.Button(text = "Clear", command = clearScreen)
    button_clear.pack(side="left", fill="both",expand=True)

    button_done = tk.Button(text = "Done!", command = saveSignature)
    button_done.pack(side="right", fill="both",expand=True)


def main():
    global root
    root = create_window()
    root.bind('<Motion>', mmove)#binds event=motion to the window and mmove
    global canvas
    canvas = create_canvas(root)
    create_buttons()
    
    #coordinates of mouse movements on canvas are sent to mmove function
    canvas.bind("<Motion>", mmove)
    #coordinates of next mouse movements are sent to draw function
    canvas.bind("<B1-Motion>", draw)
    root.mainloop() #open final window on screen


main()
