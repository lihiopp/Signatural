import GoogleDriveAPI as drive
import sys


drive.start()
def main(func,filename,title):
    if(func=="upload"):
        drive.upload(filename,title)
    if(func=="download"):
        drive.download(filename,title)
    if(func=="list files"):
        dic = drive.list_files()
        num=0
        for x in dic.keys():
            if(filename in x):
                num = num+1
        print(num)


main(sys.argv[1],sys.argv[2],sys.argv[3])

