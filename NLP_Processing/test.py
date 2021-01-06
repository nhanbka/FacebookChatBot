import own_create_model
import processing_output


# train my model using tf-idf and ANN
own_create_model.train_model()


# call and test moder pretrained

own_create_model.call_model_ann()

# test model with the text input from user
print("Try to ask something >>> ", end=' ')
text = input()
while True:
    output = own_create_model.test_model_user(text)
    print(processing_output.label_to_text(output))

    if len(text) != 0:
        print("Try to ask something >>> ", end=' ')
        text = input()
    else:
        break



