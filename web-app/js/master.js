// Filename: master.js
// MasterPage javascript

//!!!For IE placeholder bug
//$(function() {
//    $('input, textarea').placeholder();
//});

$(window).load(function() {
    $.ajax({
        type: "POST",
        url: "WsUsers.asmx/UpdatePageIn",
        data: "{" + "'userId':'" + $("#hdnUserId").val() + "','page':'" + document.URL + "','ip':'" + $('#hdnUserIpAdress').val() + "','uniqueId':'" + $('#hdnSessionId').val() + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg) {

            if (msg.d == -1) {
            }

        },
        error: function() {
            //some error occured
        }
    });
});

$(window).unload(function() {

    $.ajax({
        type: "POST",
        async: false,
        url: "../WsUsers.asmx/UpdatePageOut",
        data: "{" + "'userId':'" + $("#hdnUserId").val() + "','uniqueId':'" + $('#hdnSessionId').val() + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg) {
            if (msg.d == -1) {
            }

        },
        error: function() {
            //some error occured
        }
    });
});