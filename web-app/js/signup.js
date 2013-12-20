// Filename: signup.js
// Signup.aspx javascript file

function CheckEmailCharacters(mail) {
    //check for valid email
    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    if (reg.test(mail) == false) {
        return false;
    }
    return true;
}

function CheckPasswordCharacters(password) {
    //check pass characters
    if ((password.indexOf("'") > -1) || (password.indexOf("^") > -1) || (password.indexOf("#") > -1)) {
        return false;
    }
    return true;
}

function CheckPasswordLength(password) {

    var min = 4;
    var max = 16;
    
    if (password.length < min || password.length > max) {
        return false;
    }
    return true;
}

function RegisterUser(name, surname, email, password) {
    
    var validated = true;
    var warningText = '';
    
    if (IsNullOrEmpty(name) == true) {

        $('#nameInfo').closest('.form-group').addClass("has-error");
        $('#nameInfo').focus();

        //$("#warningMessage").text("hata");
        //$("#warningMessage").show();
        warningText = "Lütfen adınızı giriniz.";
        validated = false;
    }
    if (IsNullOrEmpty(surname) == true && validated==true ) {

        $('#surnameInfo').closest('.form-group').addClass("has-error");
        $('#surnameInfo').focus();
        
        warningText = "Lütfen soyadınızı giriniz.";
        validated = false;
    }
    if (CheckEmailCharacters(email) == false && validated == true) {

        $('#emailInfo').closest('.form-group').addClass("has-error");
        $('#emailInfo').focus();

        warningText = "Geçersiz email adresi.";
        validated = false;
    }
    if (CheckPasswordCharacters(password) == false && validated == true) {

        $('#passwordInfo').closest('.form-group').addClass("has-error");
        $('#passwordInfo').focus();

        warningText = "Şifreniz ',^,# vb. karakterleri içeremez.";
        validated = false;
    }
    if (CheckPasswordLength(password) == false && validated == true) {
    
        $('#passwordInfo').closest('.form-group').addClass("has-error");
        $('#passwordInfo').focus();

        warningText = "Şifreniz 4 ile 16 karakter arasında olmalı.";
        validated = false;
    }

    if (validated == false) {

        $("#warningMessage").text(warningText);
        $("#warningMessage").show();
    }
    else{

        $.ajax({
            type: "POST",
            url: "WsUsers.asmx/CreateNewUser",
            data: "{" + "'userName':'" + name + "','userSurname':'" + surname + "','email':'" + email + "','password':'" + password + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(msg) {

                if (msg.d == -1) {
                    $("#warningMessage").text('Bu mail adresi ile daha önceden kayıt yapılmış.');
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
            error: function() {
                //some error occured
                $("#warningMessage").text('Kayıt sırasında beklenmeyen bir hata oluştu.');
                $("#warningMessage").show();
            }
        });

    }
}
$(document).ready(function() {

    $('#nameInfo').focus();

    //enter key event
    $("body").keypress(function(e) {
        if (e.which == 13) {
            $("#btnSignUp").click();
        }
    });

    $("#btnRegister").click(function() {

        var name = $("#nameInfo").val();
        var surname = $("#surnameInfo").val();
        var email = $("#emailInfo").val();
        var password = $("#passwordInfo").val();

        RegisterUser(name, surname, email, password);
    });

});
