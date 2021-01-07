const { query } = require('express');
const mysql = require('mysql');
const nconf = require('nconf');
nconf.argv().env();
nconf.file({ file: 'config.json' });

const conn = mysql.createConnection({
    host: nconf.get('DATABASE_HOST'),
    user: nconf.get('DATABASE_USER'),
    password: nconf.get('DATABASE_PASS'),
    port: nconf.get('DATABASE_PORT'),
    database: nconf.get('DATABASE_NAME')
});
conn.connect(err => {
    if (err) throw err;
    console.log("MySQL database connected at port " + nconf.get('DATABASE_PORT') + "!");
});

function convertTime(time) {
    var processTime = new Date(time);

    let date = ("0" + processTime.getDate()).slice(-2);
    let month = ("0" + (processTime.getMonth() + 1)).slice(-2);
    let year = processTime.getFullYear();
    let hours = processTime.getHours();
    let minutes = processTime.getMinutes();
    let seconds = processTime.getSeconds();
    returnResult = "" + year + "-" + month + "-" + date + " " + hours + ":" + minutes + ":" + seconds;

    return returnResult;
}

function insert(table, msgID, msgSenderID, msgReceiverID, msgTime, readTime, msgText, callback) {

    msgTime = convertTime(msgTime);
    readTime = convertTime(readTime);
    var sql = "INSERT into " + table + "(msgID, msgSenderID, msgReceiverID, msgTime, readTime, msgText) VALUES (" +
        "'" + msgID + "', '" + msgSenderID + "', '" + msgReceiverID + "', '" + msgTime + "', '" + readTime + "', '" + msgText + "')";
    conn.query(sql, function(err, result) {
        if (err) throw err;
        if (callback) return callback(result.affectedRows);
    });
}

function remove(table, msgID, callback) {
    var sql = "DELETE FROM " + table + " WHERE msgID = '" + msgID + "'";
    conn.query(sql, function(err, result) {
        if (err) throw err;
        if (callback) return callback(result.affectedRows);
    });
}

async function getClientChat(table, clientID, callback) {
    let sql = "SELECT * FROM " + table + " WHERE msgSenderID = '" + clientID + "' OR msgReceiverID = '" + clientID + "'";
    await conn.query(sql, function(err, result) {
        if (err) throw err;
        if (callback) return callback(result);
    });
}

module.exports = {
    insert,
    remove
};