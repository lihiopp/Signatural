from skimage.metrics import structural_similarity
import numpy as np
from PIL import Image


def mse(A, B):
    """
        Computes Mean Squared Error between two images. (A and B)
        
        Arguments:
            A: numpy array
            B: numpy array
        Returns:
            err: float
    """
    
    # sigma(1, n-1)(a-b)^2)
    err = np.sum((A - B) ** 2)
    
    # mean of the sum (r,c) => total elements: r*c
    err /= float(A.shape[0] * B.shape[1])
    
    return err

def ssim(A, B):
    """
        Computes SSIM between two images.
        
        Arguments:
            A: numpy array
            B: numpy array
            
        Returns:
            score: float
    """
    
    return structural_similarity(A.flatten(), B.flatten())

def main():
    real_img = Image.open('real1.png')
    realnp = np.asarray(real_img)
    test_img = Image.open('test1.png')
    testnp = np.asarray(test_img)

    testnp.resize(realnp.shape)
    
    print("mse:",mse(realnp,testnp))
    print("ssim:",ssim(realnp,testnp))

main()
