var app = require('express')();
var http = require('http').createServer(app);
var io = require('socket.io')(http);

io.on('connection', (socket) => {
    console.log("New user connected");
    socket.on('disconnect', () => {
        console.log("User disconnected");
    });
    socket.on("unhandled_message", (data) => {
        console.log("New unhandled message: ");
        console.log(data.id);
        console.log(data.message);
        io.sockets.emit("new_unhandled_id", {
            id: data.id,
            message: data.message
        });
    });
    socket.on("hi", data => {
        console.log(data);
    });
    socket.on("owner_answer", data => {
        console.log(data);
        io.sockets.emit("owner_answer", JSON.parse(data));
        // console.log(data);
    })
    socket.on("finish_handle", data => {
        console.log(data);
        io.sockets.emit("finish_handle", JSON.parse(data));
    })
});

http.listen(3000, () => {
    console.log("listening on port 3000");
});