"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

connection.start().then(function () {
    console.log("Conection working");
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("BookCreated", function (user, message) {
    console.log('Book Created: ${JSON.stringify(book)}');
});