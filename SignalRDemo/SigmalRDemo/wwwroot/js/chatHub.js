document.addEventListener("DOMContentLoaded", function () {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/chatHub")
        .build();

    connection.start().catch(function (err) {
        return console.error(err.toString());
    });

    connection.on("ReceiveMessage", function (user, message) {
        var msg = `<div><strong>${user}</strong></div><div id="message-area"><p class="disabled-border">${message}</p></div>`;
        var pp = document.getElementById("userInput").value;
        var li = document.createElement("div");
        li.innerHTML = msg;
        document.getElementById("messagesList").appendChild(li);

        if (pp != user) {
            li.classList.add("text-end");
        }
    });

    document.getElementById("sendButton").addEventListener("click", function (event) {
        var user = document.getElementById("userInput").value;
        var message = document.getElementById("messageInput").value;
        connection.invoke("SendMessage", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
})