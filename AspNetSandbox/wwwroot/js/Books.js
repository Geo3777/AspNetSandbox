"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

connection.start().then(function () {
    console.log("Conection working");
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("BookCreated", function (book) {
    console.log(`Book Created: ${JSON.stringify(book)}`);

    $("tbody").append(`<tr>
                <td>
                    ${book.title}
                </td>
                <td>
                    ${book.author}
                </td>
                <td>
                    ${book.language}
                </td>
                <td>
                    <a href="/Books/Edit?id=${book.id}">Edit</a> |
                    <a href="/Books/Details?id=${book.id}">Details</a> |
                    <a href="/Books/Delete?id=${book.id}">Delete</a>
                </td>
            </tr >`);
});

