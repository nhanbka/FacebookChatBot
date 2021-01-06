from sklearn.svm import SVC
import pickle
import time
import os
import numpy as np
from sklearn.feature_extraction.text import CountVectorizer
from sklearn.feature_extraction.text import TfidfTransformer
from sklearn.linear_model import LogisticRegression
from sklearn.pipeline import Pipeline

# Link save model
MODEL_PATH = 'data/'


def build_and_run_svm(X_train, y_train):
    start_time = time.time()
    text_clf = Pipeline([('vect', CountVectorizer(ngram_range=(1, 1),
                                                  max_df=0.8,
                                                  max_features=None)),
                         ('tfidf', TfidfTransformer()),
                         ('clf', SVC(gamma='scale'))
                         ])
    text_clf = text_clf.fit(X_train, y_train)

    # train_time = time.time() - start_time
    # print('Done training SVM in', train_time, 'seconds.')

    # Save model
    pickle.dump(text_clf, open(os.path.join(MODEL_PATH, "svm.pkl"), 'wb'))


def build_and_run_logistic(X_train, y_train):
    start_time = time.time()
    text_clf = Pipeline([('vect', CountVectorizer(ngram_range=(1, 1),
                                                  max_df=0.8,
                                                  max_features=None)),
                         ('tfidf', TfidfTransformer()),
                         ('clf', LogisticRegression(solver='lbfgs',
                                                    multi_class='auto',
                                                    max_iter=10000))
                         ])
    text_clf = text_clf.fit(X_train, y_train)

    # train_time = time.time() - start_time
    # print('Done training Linear Classifier in', train_time, 'seconds.')

    # Save model
    pickle.dump(text_clf, open(os.path.join(MODEL_PATH, "linear_classifier.pkl"), 'wb'))


def test_model(X_test, y_test):
    model = pickle.load(open(os.path.join(MODEL_PATH, "svm.pkl"), 'rb'))
    y_pred = model.predict(X_test)
    # print("True label:    ", y_test[:20])
    # print("Predict label: ", y_pred[:20])
    # print('SVM, Accuracy =', np.mean(y_pred == y_test))


def test_model_user(X_test):
    model = pickle.load(open(os.path.join(MODEL_PATH, "svm.pkl"), 'rb'))
    y_pred = model.predict(X_test)
    return y_pred
