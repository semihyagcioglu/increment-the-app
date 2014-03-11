// Filename: updateProfile.js
// Profile.aspx javascript file

function UpdateProfile(userId, name, surname, email, phone, address, about, birthdate, gender) {

    var validated = true;
    var warningText = '';

    if (IsNullOrEmpty(name) == true) {

        $('#bodyContent_InputName').closest('.form-group').addClass("has-error");
        $('#bodyContent_InputName').focus();

        warningText = "Lütfen adınızı girin";
        validated = false;
    }
    if (IsNullOrEmpty(surname) == true && validated == true) {

        $('#bodyContent_InputSurname').closest('.form-group').addClass("has-error");
        $('#bodyContent_InputSurname').focus();

        warningText = "Lütfen soyadınızı girin...";
        validated = false;
    }
    if (IsNullOrEmpty(email) == true && validated == true) {

        $('#bodyContent_InputEmail').closest('.form-group').addClass("has-error");
        $('#bodyContent_InputEmail').focus();

        warningText = "Lütfen email adresinizi girin..";
        validated = false;
    }

        if (validated == false) {

            $("#warningMessage").text(warningText);
            $("#warningMessage").show();
        }
    else {

        $.ajax({
            type: "POST",
            url: "WsUsers.asmx/UpdateUser",
            data: "{" + "'userId':'" + userId + "','name':'" + name + "','surname':'" + surname + "','email':'" + email + "','address':'" + address + "', 'phone':'" + phone + "','gender':'" + gender + "','birthdate':'" + birthdate + "','about':'" + about + "'}",
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
                    alert('Güncelleme işlemi tamamlandı...');
                    window.location.href = 'Profile.aspx';

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

    //enter key event
    $("body").keypress(function (e) {
        if (e.which == 13) {
            $("#btnUpdateProfile").click();
        }
    });

    //var gender = "1";

    $('#bodyContent_Male').click(function () {
        $('#bodyContent_Female').prop('checked', false);
        //alert('erkek');
    });

    $('#bodyContent_Female').click(function () {

        $('#bodyContent_Male').prop('checked', false);
         //alert('kız');

    });

    $("#btnUpdateProfile").click(function () {

        var userId = $("#hdnUserId").val();
        var name = $("#bodyContent_InputName").val();
        var surname = $("#bodyContent_InputSurname").val();
        var email = $("#bodyContent_InputEmail").val();
        var phone = $("#bodyContent_InputPhone").val();
        var address = $("#bodyContent_InputAdress").val();
        var about = $("#bodyContent_InputAbout").val();
        var birthdate = $("#bodyContent_InputBirtDay").val();
        var gender;

        if (document.getElementById('bodyContent_Male').checked) {
            gender = 1;//Erkek     
        } else {
            gender = 2;//Kadın  
        }


        //if ($("#bodyContent_Male").val() == 'checked') {

        //    gender = 1;//Erkek            
        //}

        //if ($("#bodyContent_Female").val() == 'checked') {

        //    gender = 2;//Kadın     
        //}

        UpdateProfile(userId, name, surname, email, phone, address, about, birthdate, gender);
    });

});
