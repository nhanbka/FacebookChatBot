import pandas as pd
import processing_text
import classify_model
import processing_output
import own_create_model
import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import LabelEncoder
from flask import Flask, request
import json
app = Flask(__name__)

def loadData():
    global num_class
    global labels
    global texts
    global text_data

    # File data
    DATASET = 'data/dataset_collections.csv'    
    num_class = 9

    table = pd.read_csv(DATASET)
    labels = table['class'].values
    texts = table['text'].values

    # pre-processing text
    text_data = processing_text.clean_text(texts)

def trying_build_model(test_percent):
    # split data to training data and test data  # = 0.1

    X_train, X_test, y_train, y_test = train_test_split(text_data, label_data, test_size=test_percent, random_state=42)

    # encode label
    label_encoder = LabelEncoder()
    label_encoder.fit(y_train)

    y_train = label_encoder.transform(y_train)
    y_test = label_encoder.transform(y_test)

    # build model using svm
    classify_model.build_and_run_svm(X_train, y_train)

    # test model
    classify_model.test_model(X_test, y_test)

    return classify_model

@app.route('/CategorizeText', methods = ['POST'])
def CategorizeText():
    requestParam = json.loads(request.data.decode('utf-8'))

    input_text = [requestParam['text']]
    test_percent_list = [0.05, 0.1, 0.15, 0.2]
    input_text = processing_text.clean_text(input_text)
    count_arr = np.zeros(num_class)
    for test_percent in test_percent_list:
        classify_model = trying_build_model(test_percent)
        output = classify_model.test_model_user(input_text)
        count_arr[int(output[0])] += 1

    print("After 4 training, result is ", count_arr)
    max_count = 0
    value_search = -1
    for i in range(len(count_arr)):
        if max_count < count_arr[i]:
            max_count = count_arr[i]
            value_search = i

    result = processing_output.label_to_text(value_search)
    print(result)
    return result

if __name__ == '__main__':
    loadData()
    # rename label into text
    label_data=[]
    for label in labels:
        label_data.append('_label_' + str(label))
    
    app.run(debug = True)


# test model with the text input from user
# print("Try to ask something >>> ", end=' ')
# text = input()
# test_percent_list = [0.05, 0.1, 0.15, 0.2]
# while True:
#     input_text = [text]
#     input_text = processing_text.clean_text(input_text)
#     count_arr = np.zeros(num_class)
#     for test_percent in test_percent_list:
#         classify_model = trying_build_model(test_percent)
#         output = classify_model.test_model_user(input_text)
#         count_arr[int(output[0])] += 1

#     print("After 4 training, result is ", count_arr)
#     max_count = 0
#     value_search = -1
#     for i in range(len(count_arr)):
#         if max_count < count_arr[i]:
#             max_count = count_arr[i]
#             value_search = i

#     print(processing_output.label_to_text(value_search))

#     if len(text) != 0:
#         print("Try to ask something >>> ", end=' ')
#         text = input()
#     else:
#         break