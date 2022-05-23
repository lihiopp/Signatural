from skimage.metrics import structural_similarity
import numpy as np
from PIL import Image

def mse(A, B):
    """
        Computes Mean Squared Error between two images.
        Arguments:
            A: numpy array of image 1.
            B: numpy array of image 2.
        Returns:
            err: float.
    """
    
    # sigma(1, n-1)(a-b)^2)
    err = np.sum((A - B) ** 2)
    
    # mean of the sum (r,c) => total elements: r*c
    err /= float(A.shape[0] * B.shape[1])
    return err

def ssim(A, B):
    """
        Computes Structure Similarity between two images.
        Arguments:
            A: numpy array of image 1.
            B: numpy array of image 2.
        Returns:
            score: float.
    """
    return structural_similarity(A.flatten(), B.flatten())

def main(signature1,signature2):
    # Open images as numpy arrays.
    real_img = Image.open(signature1)
    realnp = np.asarray(real_img)
    test_img = Image.open(signature2)
    testnp = np.asarray(test_img)
    
    # Make sure the images have the same size.
    testnp.resize(realnp.shape)
    mse = mse(realnp,testnp)
    ssim = ssim(realnp,testnp)
    if(mse < 0.3 and ssim > 0.7)
        return "real"
    else
        return "forged"
