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
        data: "{" + "'userId':'" + $("#ctl00_hdnUserId").val() + "','page':'" + document.URL + "','ip':'" + $('#ctl00_hdnUserIpAdress').val() + "','uniqueId':'" + $('#ctl00_hdnSessionId').val() + "'}",
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
        data: "{" + "'userId':'" + $("#ctl00_hdnUserId").val() + "','uniqueId':'" + $('#ctl00_hdnSessionId').val() + "'}",
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