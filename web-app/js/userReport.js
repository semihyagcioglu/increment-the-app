function GetUser() {
    alert("aaa");

    $.ajax({
        type: "POST",
        url: "WsUsers.asmx/GetUser",
        data: "{" + "'userId':'" + userId + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("#myUsers").html(''); //clear search results
            //alert(data.d);
            //Write functionality to display data
            $("#myUsers").append(CreateTableView(data.d, 'CssClassName', true));
        },
        error: function (result) {
            alert("Error: " + result);
        }
    });
};


$(document).ready(function () {

    GetUser();

});