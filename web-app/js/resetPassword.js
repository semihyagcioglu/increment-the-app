function ResetPassword(email) {

    var validated = true;
    var warningText = '';

    if (IsNullOrEmpty(email) == true && validated == true) {

        $('#bodyContent_Email').closest('.form-group').addClass("has-error");
        $('#bodyContent_Email').focus();

        warningText = "Mail Adresi Bulunamadı";
        validated = false;
    }
    else {
        //alert(task);

        $.ajax({
            type: "POST",
            url: "WsUsers.asmx/ResetPassword",
            data: "{" + "'email':'" + email + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {

                if (msg.d == -1) {

                    $("#warningMessage").text(email + ' adresi bulunamadı..');
                    $("#warningMessage").show();
                    $("#successMessage").hide();
                }
                else {


                    $("#successMessage").text(email + ' adresinize yeni parolanız gönderilmiştir...');
                    $("#successMessage").show();
                    $("#warningMessage").hide();
                }

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

    $('#bodyContent_Email').focus();

    //enter key event
    $("body").keypress(function (e) {
        if (e.which == 13) {
            $("#btnResetPassword").click();
        }
    });

    $("#btnResetPassword").click(function () {

        var email = $("#bodyContent_Email").val();

        ResetPassword(email);
    });

});