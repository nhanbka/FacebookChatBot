'use strict';

// Imports dependencies and set up http server
const { v4: uuidv4 } = require('uuid');
const
    express = require('express'),
    request = require('request'),
    bodyParser = require('body-parser'),
    nconf = require('nconf'),
    mysql = require('mysql'),
    app = express().use(bodyParser.json()); // creates express http server
const mySQLdb = require('./middleware/mysqlconnector');

nconf.argv().env();
nconf.file({ file: 'config.json' });

var conn = mysql.createConnection({
    host: "localhost",
    user: "chatbot",
    password: "1234",
    port: 3307,
    database: "chatbotdb"
});
conn.connect(function(err) {
    if (err) throw err;
    console.log("MySQL database connected!");
});

// Sets server port and logs message on success
app.listen(process.env.PORT || nconf.get('PORT'), () => console.log('webhook is listening'));

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
                mySQLdb.insert(conn, 'chatcontent', messageID, sender_psid, receiver_psid, messsageTime, deliveredTime, messageText);

                handleMessage(sender_psid, receiver_psid, messsageTime, deliveredTime, messageText);
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
    if (msgText) {
        let responseText;
        // Create the payload for a basic text message
        if (msgText.toLowerCase().includes("start")) {
            responseText = `Hello. Welcome to the chatbot`;
            response = {
                "text": responseText
            }
        } else if (msgText.toLowerCase().includes("price")) {
            responseText = `Please select the product code you want to consult the price.`;
            response = {
                "text": responseText
            }
        } else {
            responseText = `For this question, I will forward to the supporter.`
            response = {
                "text": responseText
            }
        }
        mySQLdb.insert(conn, 'chatcontent', "m_" + uuidv4() + uuidv4(), msgReceiverID, msgSenderID, Date.now(), Date.now(), responseText);
    }

    // Sends the response message
    callSendAPI(msgSenderID, response);
}

// Handles messaging_postbacks events
function handlePostback(sender_psid, received_postback) {

}

// Sends response messages via the Send API
function callSendAPI(sender_psid, response) {
    // Construct the message body
    let request_body = {
        "recipient": {
            "id": sender_psid
        },
        "message": response
    }

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
        });
}