"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();


connection.on("BroadcastMessage", function (deviceId, sensorId, message) {
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //var encodedMsg = user + " says " + msg;
    ///var li = document.createElement("li");
    //li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);
    AddEditExpenses(deviceId, sensorId, message);
    $('.alert').show();
});

connection.start().then(function () {
    console.log('start');
}).catch(function (err) {
    return console.error(err.toString());
});


var AddEditExpenses = function (deviceId, sensorId, message) {
    var url = "/Devices/Notify/" + deviceId;
    $('#title').html(message);

    $("#expenseFormModelDiv").load(url, function () {
        $("#expenseFormModel").modal("show");

    });
}