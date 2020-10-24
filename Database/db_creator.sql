CREATE DATABASE chatbotDB;

USE chatbotDB;

CREATE TABLE chatContent(
	msgID varchar(90) PRIMARY KEY,
    msgSenderID varchar(20) NOT NULL,
    msgReceiverID varchar(20) NOT NULL,
    msgTime datetime NOT NULL,
    readTime dateTime NOT NULL,
    msgText TEXT
)
