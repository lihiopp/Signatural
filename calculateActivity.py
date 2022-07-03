import sys, os
from matplotlib import pyplot as plt
import numpy as np

attempts = int(sys.argv[1])
forgeries = int(sys.argv[2])
y = np.array([attempts-forgeries,forgeries])
plt.pie(y,labels=["Real Signatures","Forgeries"])
plt.savefig(os.getcwd()+r"\activity.png", bbox_inches='tight')
