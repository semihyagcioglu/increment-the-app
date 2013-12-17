// Filename: login.js
// Login.aspx javascript file

function GetCookie(c_name) {
    var i, x, y, ARRcookies = document.cookie.split(";");
    for (i = 0; i < ARRcookies.length; i++) {
        x = ARRcookies[i].substr(0, ARRcookies[i].indexOf("="));
        y = ARRcookies[i].substr(ARRcookies[i].indexOf("=") + 1);
        x = x.replace(/^\s+|\s+$/g, "");
        if (x == c_name) {
            return unescape(y);
        }
    }
}

function SetCookie(cookieName, cookieValue, nDays) {
    var today = new Date();
    var expire = new Date();
    if (nDays == null || nDays == 0) nDays = 1;
    expire.setTime(today.getTime() + 3600000 * 24 * nDays);
    document.cookie = cookieName + "=" + escape(cookieValue) + ";expires=" + expire.toGMTString();
}

function SetCookieValues() {

    var email = GetCookie("email");
    var password = GetCookie("password");

    if (email) {
        $('#emailInfo').val(email);
    }
    if (password) {
        $('#passwordInfo').val(password);
    }
}

function Login(email, password) {

    var validated = true;

    if (IsNullOrEmpty(email) == true) {

        $('#emailInfo').closest('.form-group').addClass("has-error");
        $('#emailInfo').focus();
        
        $("#warningMessage").text('Email adresinizi giriniz.');
        $('#warningMessage').show();
        
        validated = false;
    }
    if (IsNullOrEmpty(password) == true) {

        $('#passwordInfo').closest('.form-group').addClass("has-error");

        if (validated == true) {

            $('#passwordInfo').focus();
            
            $("#warningMessage").text('Şifrenizi giriniz.');
            $('#warningMessage').show();
        }
        validated = false;
    }
    
    //alert(email);
    //alert(password);

    if (validated == true) {
        
        $('#emailInfo').closest('.form-group').removeClass("has-error");
        $('#passwordInfo').closest('.form-group').removeClass("has-error");
        $('#warningMessage').hide();
        
        $.ajax({
            type: "POST",
            url: "WsUsers.asmx/LogIn",
            data: "{" + "'email':'" + email + "','password':'" + password + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(msg) {

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
                    //console.log(msg.d);
                    SetCookie("email", email, 5);
                    SetCookie("password", password, 5);

                    parent.window.location.href = 'Home.aspx';

                }
            },

            error: function() {
                $("#warningMessage").text('Hata oluştu.');
                $('#warningMessage').show();
            }
        });
    }
}

$(document).ready(function() {

    $('#emailInfo').focus();
    SetCookieValues();
    
    //enter key event
    $("body").keypress(function(e) {
        if (e.which == 13) {
            $("#btnLogin").click();
        }
    });
    
    $("#btnLogin").click(function() {
        var email = $("#emailInfo").val();
        var password = $("#passwordInfo").val();

        //alert(email);
        Login(email, password);
    });

});