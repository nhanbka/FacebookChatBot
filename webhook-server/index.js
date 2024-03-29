'use strict';

// Imports dependencies and set up http server
const { v4: uuidv4 } = require('uuid');
const express = require('express');
const request = require('request');
const nconf = require('nconf');
const mysql = require('mysql');
const io = require('socket.io-client');
const List = require("collections/list");
const axios = require('axios');
const bodyParser = require('body-parser');
const app = express().use(bodyParser.json()); // creates express http server

const mySQLdb = require('./middleware/mysqlconnector');
let curentUnhandledUser = new List();
nconf.argv().env();
nconf.file({ file: 'config.json' });

// For socket.io communication
const socket = io('http://localhost:3000', {
    reconnectionDelayMax: 5000
});
socket.on("owner_answer", data => {
    console.log(data.responseMess);
    let response = { "text": data.responseMess };
    sendFacebookMess(data.senderID, response);
});
socket.on("finish_handle", data => {
    console.log("Finish Handle" + data.fininshID);
    if (curentUnhandledUser.has(data.fininshID))
        curentUnhandledUser.delete(data.fininshID);
});
// ----------------------------

// Sets server port and logs message on success
app.listen(process.env.PORT || nconf.get('PORT'),
    () => console.log('webhook is listening at port ' + nconf.get('PORT')));

// Creates the endpoint for our webhook 
app.post('/webhook', (req, res) => {

    let body = req.body;

    // Checks this is an event from a page subscription
    if (body.object === 'page') {
        // Iterates over each entry - there may be multiple if batched
        body.entry.forEach(function(entry) {
            // Gets the message. entry.messaging is an array, but 
            // will only ever contain one message, so we get index 0
            let webhook_event = entry.messaging[0];
            console.log("------------------------------");
            console.log("Receive Message:\n");
            console.log(webhook_event);

            // Check if the event is a message or postback and
            // pass the event to the appropriate handler function
            if (webhook_event.message) {
                // Get the message info
                let messageID = webhook_event.message.mid;
                let sender_psid = webhook_event.sender.id;
                let receiver_psid = webhook_event.recipient.id;
                let messsageTime = webhook_event.timestamp;
                let deliveredTime = entry.time;
                let messageText = webhook_event.message.text;
                try {
                    mySQLdb.insert('chatcontent', messageID, sender_psid, receiver_psid, messsageTime, deliveredTime, messageText);
                } catch (err) {
                    console.log(err)
                } finally {
                    handleMessage(sender_psid, receiver_psid, messsageTime, deliveredTime, messageText);
                }
            } else if (webhook_event.postback) {
                handlePostback(sender_psid, webhook_event.postback);
            }
        });

        // Returns a '200 OK' response to all requests
        res.status(200).send('EVENT_RECEIVED');
    } else {
        // Returns a '404 Not Found' if event is not from a page subscription
        res.sendStatus(404);
    }
});

// Adds support for GET requests to our webhook
app.get('/webhook', (req, res) => {

    // Your verify token. Should be a random string.
    let VERIFY_TOKEN = nconf.get('VERIFY_TOKEN');

    // Parse the query params
    let mode = req.query['hub.mode'];
    let token = req.query['hub.verify_token'];
    let challenge = req.query['hub.challenge'];

    // Checks if a token and mode is in the query string of the request
    if (mode && token) {
        // Checks the mode and token sent is correct
        if (mode === 'subscribe' && token === VERIFY_TOKEN) {
            // Responds with the challenge token from the request
            console.log('WEBHOOK_VERIFIED');
            res.status(200).send(challenge);
        } else {
            // Responds with '403 Forbidden' if verify tokens do not match
            res.sendStatus(403);
        }
    }
});

// Handles messages events
function handleMessage(msgSenderID, msgReceiverID, msgTime, readTime, msgText) {
    let response;

    // Check if the message contains text
    console.log(msgText);
    if (msgText) {
        let responseText;
        // Create the payload for a basic text message
        var data = JSON.stringify({ 'text': msgText });
        var config = {
            method: 'post',
            url: 'http://127.0.0.1:5000/CategorizeText',
            headers: {
                'Content-Type': 'application/json'
            },
            data: data
        };
        // Send message to NLP API Server to handle message
        axios(config)
            .then(res => {
                let resText = res.data;
                if (resText != 'Tư vấn chăm sóc khách hàng') {
                    response = {
                        "text": resText
                    }
                    sendFacebookMess(msgSenderID, response);
                } else {
                    if (!curentUnhandledUser.has(msgSenderID)) {
                        responseText = `Câu hỏi sẽ được chuyển qua cho hỗ trợ viên, bạn vui lòng đợt trong ít phút.`
                        response = {
                            "text": responseText
                        }
                        curentUnhandledUser.add(msgSenderID);
                        sendFacebookMess(msgSenderID, response);
                    }
                    socket.emit("unhandled_message", {
                        id: msgSenderID,
                        message: msgText
                    })
                }
            })
            .catch(err => {
                console.log(err);
            })
    }
}

// Handles messaging_postbacks events
function handlePostback(sender_psid, received_postback) {

}

// Sends response messages via the Send API
function sendFacebookMess(sender_psid, response) {
    // Construct the message body
    let request_body = {
        "recipient": {
            "id": sender_psid
        },
        "message": response
    }
    console.log(request_body);
    // Send the HTTP request to the Messenger Platform
    request({
            "uri": "https://graph.facebook.com/v2.6/me/messages",
            // "qs": { "access_token": process.env.PAGE_ACCESS_TOKEN },
            "qs": {
                "access_token": nconf.get("PAGE_ACCESS_TOKEN")
            },
            "method": "POST",
            "json": request_body
        },
        (err, res, body) => {
            if (!err) {
                console.log('message sent!');
            } else {
                console.error("Unable to send message:" + err);
            }
        }
    );
    mySQLdb.insert('chatcontent', "m_" + uuidv4() + uuidv4(), nconf.get('PAGE_ID'), sender_psid, new Date(Date.now() + 1000), new Date(Date.now() + 1000), response.text);
}