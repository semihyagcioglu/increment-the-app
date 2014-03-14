function Offer(userId, taskId) {

    $.ajax({
        type: "POST",
        url: "WsTasks.asmx/Offer",
        data: "{" + "'userId':'" + userId + "','taskId':'" + taskId + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {

            if (msg.d == 0) {
                //console.log(msg.d);
                $("#warningMessage").text("Kullanıcı adı ya da şifre hatalı");
                $('#warningMessage').show();
            }
            else if (msg.d == -1) {
                alert("HATA");
                //console.log(msg.d);
                $("#warningMessage").text("Beklenmedik bir sorun oluştu");
                $('#warningMessage').show();

            }
            else {
               
                parent.window.location.href = 'Home.aspx';

            }
        },

        error: function () {
            $("#warningMessage").text('Hata oluştu.');
            $('#warningMessage').show();
        }
    });
};


$(document).ready(function () {
      
    $("#btnOffer").click(function () {
        var userId = $("#hdnUserId").val();
        var taskId = $("#bodyContent_TaskDetailsId").val();

        //alert(email);
        Offer(userId, taskId);
    });

});