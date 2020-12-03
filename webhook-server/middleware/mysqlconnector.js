const { query } = require('express');
var mysql = require('mysql');

var con = mysql.createConnection({
    host: "localhost",
    user: "chatbot",
    password: "1234",
    port: 3306,
    database: "chatbotdb"
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

function insert(connection, table, msgID, msgSenderID, msgReceiverID, msgTime, readTime, msgText, callback) {

    msgTime = convertTime(msgTime);
    readTime = convertTime(readTime);
    var sql = "INSERT into " + table + "(msgID, msgSenderID, msgReceiverID, msgTime, readTime, msgText) VALUES (" +
        "'" + msgID + "', '" + msgSenderID + "', '" + msgReceiverID + "', '" + msgTime + "', '" + readTime + "', '" + msgText + "')";
    connection.query(sql, function(err, result) {
        if (err) throw err;
        if (callback) return callback(result.affectedRows);
    });
}

function remove(connection, table, msgID, callback) {
    var sql = "DELETE FROM " + table + " WHERE msgID = '" + msgID + "'";
    connection.query(sql, function(err, result) {
        if (err) throw err;
        if (callback) return callback(result.affectedRows);
    });
}

async function getClientChat(connection, table, clientID, callback) {
    let sql = "SELECT * FROM " + table + " WHERE msgSenderID = '" + clientID + "' OR msgReceiverID = '" + clientID + "'";
    // var sql = "SELECT * FROM " + table + " WHERE msgSenderID = '" + clientID + "' OR msgReceiverID = '" + clientID + "' ORDER BY msgTime ASC";
    await connection.query(sql, function(err, result) {
        if (err) throw err;
        if (callback) return callback(result);
    });
}

// getClientChat(con, 'chatcontent', '3181701225285372', function(result) {
//     console.log(result);
//     resultQuery = result;
//     // console.log(resultQuery);
// });

// insert(table = 'chatcontent',
//     msgID = 'm_L67mhQ1uH27Yli9YuYddp3Hn3Ua5CKDbLkEknIX3eV2EzTrIyI2RwE9SSJ5XfVCaKGnCjGVhUPBGguHikQVonA',
//     sessionID = '101714355046687',
//     msgSenderID = '3181701225285372',
//     msgReceiverID = '101714355046687',
//     msgTime = 1603307367129,
//     readTime = 1603307367346,
//     msgText = '1');

module.exports = {
    insert,
    remove
};