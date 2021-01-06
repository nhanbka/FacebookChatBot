import numpy as np
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.model_selection import train_test_split
from tensorflow import keras
import tensorflow as tf
from sklearn.metrics.pairwise import cosine_similarity
import os
import processing_text
import pandas as pd


# File data
DATASET = 'data/dataset_collections.csv'
checkpoint_path = "data/cp.ckpt"

table = pd.read_csv(DATASET)
labels = table['class'].values
texts = table['text'].values

# pre-processing text
text_data = processing_text.clean_text(texts)

# using tf_idf to compute the weight of word
vectorizer = TfidfVectorizer(analyzer='word')
vectorizer.fit(text_data)
X = vectorizer.transform(text_data)
vector_inputs = X.todense()

SHAPE = len(vectorizer.get_feature_names())

label_inputs = []
for label in labels:
    middle = np.zeros(8)  # have 8 cluster
    index = int(label)
    middle[index - 1] = 1  # one hot vector
    label_inputs.append(middle)

# split data
test_percent = 0.1
X_train, X_test, y_train, y_test = train_test_split(vector_inputs, label_inputs, test_size=test_percent,
                                                    random_state=42)

X_train = np.asarray(X_train)
X_test = np.asarray(X_test)
X_train = np.reshape(X_train, (-1, X_train.shape[1], 1))
X_test = np.reshape(X_test, (-1, X_test.shape[1], 1))
y_train = np.asarray(y_train)
y_test = np.asarray(y_test)


def create_model():
    # create model ANN
    model_ann = keras.Sequential()
    model_ann.add(keras.layers.Input((SHAPE, 1)))
    model_ann.add(keras.layers.Flatten())
    # model_ann.add(keras.layers.Dense(512, activation='sigmoid'))
    model_ann.add(keras.layers.Dense(256, activation='sigmoid'))
    model_ann.add(keras.layers.Dropout(0.3))
    # model_ann.add(keras.layers.Dense(128, activation='sigmoid'))
    model_ann.add(keras.layers.Dense(64, activation='sigmoid'))
    # model_ann.add(keras.layers.Dense(32, activation='sigmoid'))
    model_ann.add(keras.layers.Dense(8, activation='sigmoid'))

    model_ann.compile(optimizer='adam', loss=tf.keras.losses.BinaryCrossentropy(), metrics=['acc'])

    return model_ann


def train_model():

    model_ann = create_model()

    # create checkpoint to save model

    # Create a callback that saves the model's weights
    cp_callback = tf.keras.callbacks.ModelCheckpoint(filepath=checkpoint_path,
                                                     save_weights_only=True,
                                                     verbose=1)

    model_ann.fit(X_train, y_train,
                  validation_data=(X_test, y_test),
                  epochs=50,
                  callbacks=[cp_callback])


def call_model_ann():
    model_ann = create_model()
    model_ann.load_weights(checkpoint_path)
    predict = model_ann.predict(X_test)
    for i in range(10):
        x = [y_test[i]]
        y = [predict[i]]
        x = np.asarray(x)
        y = np.asarray(y)
        print(cosine_similarity(x, y))

    label_predict = []
    for i in predict:
        index = np.zeros(8)
        for num in range(len(i)):
            if i[num] >= 0.5:
                index[num] = 1
                break
        label_predict.append(index)

    print('Accuracy =', np.mean(label_predict == y_test))


def test_model_user(text):
    texts = [text]
    # clean text from user enter
    texts = processing_text.clean_text(texts)

    # using tf-idf vectorizer
    X = vectorizer.transform(texts)
    vector = X.todense()

    vector = np.asarray(vector)
    vector = np.reshape(vector, (-1, vector.shape[1], 1))

    model_ann = create_model()
    model_ann.load_weights(checkpoint_path)
    predict = model_ann.predict(vector)

    label_predict = []
    for i in predict:
        index = -1
        for num in range(len(i)):
            if i[num] >= 0.5:
                index = num
                break
        label_predict.append(index)

    return label_predict[0]










