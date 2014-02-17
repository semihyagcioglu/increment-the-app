// Filename: postTask.js
// postTask.aspx javascript file

function InsertPostTask(title, detail, location, date, money) {

    var validated = true;
    var warningText = '';

    if (IsNullOrEmpty(title) == true) {

        $('#InputTitle').closest('.form-group').addClass("has-error");
        $('#InputTitle').focus();

        warningText = "Lütfen Yapılmak İstenen İş Giriniz...";
        validated = false;
    }
    if (IsNullOrEmpty(detail) == true && validated == true) {

        $('#InputTitleDetail').closest('.form-group').addClass("has-error");
        $('#InputTitleDetail').focus();

        warningText = "Lütfen yapılacak işin detaylarını girin...";
        validated = false;
    }
    if (IsNullOrEmpty(location) == true && validated == true) {

        $('#Inputlocation').closest('.form-group').addClass("has-error");
        $('#Inputlocation').focus();

        warningText = "Lütfen işin yapılmasını istediğiniz yeri seçiniz..";
        validated = false;
    }
    if (IsNullOrEmpty(date) == true && validated == true) {

        $('#datepicker').closest('.form-group').addClass("has-error");
        $('#datepicker').focus();

        warningText = "Lütfen Tarih Seçin...";
        validated = false;
    }
    if (IsNullOrEmpty(money) == true && validated == true) {

        $('#InputMoney').closest('.form-group').addClass("has-error");
        $('#InputMoney').focus();

        warningText = "Lütfen Ne kadar Ödemeyi Düşündüğünüzü Girin...";
        validated = false;
    }

    if (validated == false) {

        $("#warningMessage").text(warningText);
        $("#warningMessage").show();
    }
    else {

        $.ajax({
            type: "POST",
            url: "WsUsers.asmx/PostTask",
            data: "{" + "'taskTitle':'" + title + "','taskDetail':'" + detail + "','date':'" + date + "','location':'" + location + "','money':'" + money + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {

                if (msg.d == -1) {
                    $("#warningMessage").text('Bu iş bilgileri daha önceden kaydedilmiştir...');
                    $("#warningMessage").show();
                }
                else if (msg.d == -2) {
                    $("#warningMessage").text('Kayıt sırasında beklenmeyen bir hata oluştu.');
                    $("#warningMessage").show();
                }
                else {
                    //Success
                    window.location.href = 'Home.aspx';

                }

            },
            error: function () {
                //some error occured
                $("#warningMessage").text('Kayıt sırasında beklenmeyen bir hata oluştu.');
                $("#warningMessage").show();
            }
        });

    }
}
$(document).ready(function () {

    $('#InputTitle').focus();

    //enter key event
    $("body").keypress(function (e) {
        if (e.which == 13) {
            $("#btnTaskSave").click();
        }
    });

    $("#btnTaskSave").click(function () {

        var title = $("#InputTitle").val();
        var detail = $("#InputTitleDetail").val();
        var location = $("#Inputlocation").val();
        var date = $("#datepicker").val();
        var money = $("#InputMoney").val();

        InsertPostTask(title, detail, location, date, money);
    });

});
