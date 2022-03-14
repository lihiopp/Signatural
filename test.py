import os
from versign import VerSign


# Load training data
train_data = r"C:\Users\student\Desktop\try\trainsig"# folder containing training data (only genuine samples)
x_train = [os.path.join(train_data, f) for f in sorted(os.listdir(train_data))]

# Load test data and labels
test_data = r"C:\Users\student\Desktop\try\testsig"# folder containing test data
x_test = [os.path.join(test_data, f) for f in sorted(os.listdir(test_data))]
x_names = os.listdir(test_data)

# Train a writer-dependent model from training data
v = VerSign('models/signet.pth', (150, 200))
v.fit(x_train)

# Predict labels of test data
y_pred = v.predict(x_test,x_names)
print(y_pred)
