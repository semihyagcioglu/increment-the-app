function Offer(userId, taskId) {

    $.ajax({
        type: "POST",
        url: "WsTasks.asmx/Offer",
        data: "{" + "'userId':'" + userId + "','taskId':'" + taskId + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {

            if (msg.d == -1) {
               
                $("#warningMessage").text("Bu iş için daha önce teklif verdiniz...");
                $('#warningMessage').show();
            }
            else if (msg.d == 0) {
                alert("HATA");
              
                $("#warningMessage").text("Beklenmedik bir sorun oluştu");
                $('#warningMessage').show();

            }            
            else {
                    $("#warningMessagePostedTask").fadeIn();
                setTimeout(function () {
                    window.location.href = "Home.aspx";
                }, 3000);
              
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
              
        Offer(userId, taskId);
    });

});