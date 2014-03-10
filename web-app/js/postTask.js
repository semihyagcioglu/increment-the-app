﻿// Filename: postTask.js
// postTask.aspx javascript file

function InsertPostTask(userId, title, detail, privateNotes, location, date, hour, money) {

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

        $('#Location').closest('.form-group').addClass("has-error");
        $('#Location').focus();

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

        $('#taskPrice').closest('.form-group').addClass("has-error");
        $('#taskPrice').focus();

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
            data: "{" + "'userId':'" + userId + "','taskTitle':'" + title + "','taskDetail':'" + detail + "','privateNotes':'" + privateNotes + "', 'date':'" + date + "','hour':'" + hour + "','location':'" + location + "','money':'" + money + "'}",
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
                    $("#warningMessagePostedTask").fadeIn();
                    setTimeout(function () {
                        window.location.href = 'Home.aspx';
                    }, 3000);


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
        var privateNotes = $("#PrivateNotes").val();
        var location = $("#Location").val();
        var date = $("#datepicker").val();
        var hour = $("#InsertHour").val();
        var money = $("#taskPrice").val();
        var userId = $(hdnUserId).val();

        InsertPostTask(userId, title, detail, privateNotes, location, date, hour, money);
    });

});
