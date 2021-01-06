from pyvi import ViTokenizer, ViPosTagger, ViUtils
import pandas as pd
import re
import pickle


def get_stopwords():
    file = pd.read_csv('data/stopwords.csv')
    stopwords = file['stopwords'].values

    return stopwords


stopwords = get_stopwords()


def pos_tagging_text(word):
    result = ViPosTagger.postagging(word)
    list_accept = [['N'], ['V'], ['Nc'], ['Ny'], ['Np'], ['Nu']]

    return result[1] in list_accept


def clean_text(data):
    result = []

    for line in data:
        try:
            # bao hanh --> bảo hành
            middle = ViUtils.add_accents(line)
        except:
            middle = line

        # split words
        middle = ViTokenizer.tokenize(middle)

        # remove punctuation
        middle = re.sub(r'\W', ' ', middle)  # remove puntuaction
        middle = re.sub(r'\d', ' ', middle)  # remove digits

        # delete ư, ô,....
        middle = ViUtils.remove_accents(middle)
        middle = middle.lower()

        # delete redundant spaces
        middle = str(middle)
        middle = re.sub(r'\s\s+', ' ', middle.strip())

        # remove stopwords
        line_clean = ''

        for word in middle.split(' '):
            word = re.sub(r"b'", '', word)
            word = re.sub(r'\W', ' ', word)
            word = re.sub(r'\s\s+', ' ', word.strip())

            if len(word) > 1:
                if word not in stopwords and pos_tagging_text(word):
                    line_clean += word + ' '

        result.append(line_clean.strip())

    return result
