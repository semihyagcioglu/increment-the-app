// Filename: updateProfile.js
// Profile.aspx javascript file

function UpdateProfile(userId, name, surname, email, phone, adress, about, birthdate, gender) {

    var validated = true;
    var warningText = '';

    if (IsNullOrEmpty(name) == true) {

        $('#InputName').closest('.form-group').addClass("has-error");
        $('#InputName').focus();

        warningText = "Lütfen adınızı girin";
        validated = false;
    }
    if (IsNullOrEmpty(surname) == true && validated == true) {

        $('#InputSurname').closest('.form-group').addClass("has-error");
        $('#InputSurname').focus();

        warningText = "Lütfen soyadınızı girin...";
        validated = false;
    }
    if (IsNullOrEmpty(email) == true && validated == true) {

        $('#InputEmail').closest('.form-group').addClass("has-error");
        $('#InputEmail').focus();

        warningText = "Lütfen email adresinizi girin..";
        validated = false;
    }

        //if (validated == false) {

        //    $("#warningMessage").text(warningText);
        //    $("#warningMessage").show();
        //}
    else {

        $.ajax({
            type: "POST",
            url: "WsUsers.asmx/UpdateUser",
            data: "{" + "'userId':'" + userId + "','name':'" + name + "','surname':'" + surname + "','email':'" + email + "', 'phone':'" + phone + "','gender':'" + gender + "','birthdate':'" + birthdate + "','about':'" + about + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {

                if (msg.d == -1) {
                    $("#warningMessage").text('Profil güncelleme sırasında hata oluştu...');
                    $("#warningMessage").show();
                }
                else if (msg.d == -2) {
                    $("#warningMessage").text('Güncelleme sırasında beklenmeyen bir hata oluştu.');
                    $("#warningMessage").show();
                }
                else {
                    //Success
                    //window.location.href = 'Home.aspx';
                    alert('Güncelleme işlemi tamamlandı...');

                }

            },
            error: function () {
                //some error occured
                $("#warningMessage").text('Güncelleme sırasında beklenmeyen bir hata oluştu.');
                $("#warningMessage").show();
            }
        });

    }
}
$(document).ready(function () {

    $('#InputName').focus();

    //enter key event
    $("body").keypress(function (e) {
        if (e.which == 13) {
            $("#btnUpdateProfile").click();
        }
    });

    $("#btnUpdateProfile").click(function () {

        var userId = $(hdnUserId).val();
        var name = $("#InputName").val();
        var surname = $("#InputSurname").val();
        var email = $("#InputEmail").val();
        var phone = $("#InputPhone").val();
        var adress = $("#InputAdress").val();
        var about = $("#InputAbout").val();
        var birthdate = $("#InputBirthDate").val();
        var gender = $("#InputGender").val();

        UpdateProfile(userId, name, surname, email, phone, adress, about, birthdate, gender);
    });

});
