function ResetPassword(email) {

    var validated = true;
    var warningText = '';

    if (IsNullOrEmpty(email) == true && validated == true) {

        $('#Email').closest('.form-group').addClass("has-error");
        $('#Email').focus();

        warningText = "Mail Adresi Bulunamadı";
        validated = false;
    }
    else {
        //alert(task);

        $.ajax({
            type: "POST",
            url: "WsUsers.asmx/RestPassword",
            data: "{" + "'email':'" + email + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {

                var warningText = "Mail Adresi Bulunamadı";
             
                validated = false;

            },
            error: function () {
                //some error occured
                $("#warningMessage").text('Password sıfırlama sırasında hata oluştu..');
                $("#warningMessage").show();
            }
        });
    }
}

$(document).ready(function () {

    $('#Email').focus();

    //enter key event
    $("body").keypress(function (e) {
        if (e.which == 13) {
            $("#btnResetPassword").click();
        }
    });

    $("#btnResetPassword").click(function () {

        var email = $("#Email").val();

        ResetPassword(email);
    });

});