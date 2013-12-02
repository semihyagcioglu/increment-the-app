  
//Login - Signup Checks
function CheckEmailValidation(mail) {

    //check for valid email
    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    if (reg.test(mail) == false) {
        $("#signupWarning").text('GeÃ§ersiz email adresi...');
        document.getElementById('signupWarning').style.display = 'block';
        return false;
    }
    return true;

}

function CheckPasswordValidation(password) {

    if (password.length < 4 || password.length > 16) {
        $("#signupWarning").text('Åifreniz 4 ile 16 karakter arasÄ±nda olmalÄ±.');
        document.getElementById('signupWarning').style.display = 'block';
        return false;
    }
    $("#txtPassRep").attr('class', 'normal');

    //check pass characters
    if ((password.indexOf("'") > -1) || (password.indexOf("^") > -1) || (password.indexOf("#") > -1)) {
        $("#signupWarning").text("Åifreniz ',^,# vb. karakterleri iÃ§eremez.");
        document.getElementById('signupWarning').style.display = 'block';
        return false;
    }

    return true;
}

function CheckSignupInputs(name, surname, mail, password) {
    //Check for signup

    var retVal = true;

    if (name == "") {

        $("#signUsernameControl").addClass('error');
        $("#signUsernameControl").focus();

        $("#signupWarning").text("Eksik bilgilerinizi giriniz.");
        document.getElementById('signupWarning').style.display = 'block';

        retVal = false;

    }

    if (surname == "" && retVal == true) {

        $("#signupWarning").text("Eksik bilgilerinizi giriniz.");
        document.getElementById('signupWarning').style.display = 'block';

        $("#signUsersurnameControl").addClass('error');
        $("#signUsersurnameControl").focus();

        retVal = false;
    }

    if (mail == "" && retVal == true) {

        $("#signupWarning").text("Eksik bilgilerinizi giriniz.");
        document.getElementById('signupWarning').style.display = 'block';

        $("#signEmailControl").addClass('error');
        $("#signEmailControl").focus();

        retVal = false;
    }

    if (retVal == true && CheckEmailValidation(mail) == false) {

        $("#signEmailControl").addClass('error');
        $("#signEmailControl").focus();

        retVal = false;
    }

    if (password == "" && retVal == true) {

        $("#signupWarning").text("Eksik bilgilerinizi giriniz.");
        document.getElementById('signupWarning').style.display = 'block';

        $("#signPasswordControl").addClass('error');
        $("#signPasswordControl").focus();

        retVal = false;
    }

    if (retVal == true && CheckPasswordValidation(password) == false) {

        $("#signPasswordControl").addClass('error');
        $("#signPasswordControl").focus();

        retVal = false;
    }

    return retVal;
}

				
function registerUser() {

    var name = $("#SignUsername").val();
    var surname = $("#SignUsersurname").val();
    var mail = $("#SignEmail").val();
    var password = $("#SignPassword").val();

    if (CheckSignupInputs(name, surname, mail, password)) {

        $.ajax({
            type: "POST",
            url: "wsUser.asmx/CreateNewUser",
            data: "{" + "'userName':'" + name + "','userSurname':'" + surname + "','email':'" + mail + "','password':'" + password + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(msg) {

                if (msg.d == -1) {
                    $("#signupWarning").text('Bu mail adresi ile daha Ã¶nceden kayÄ±t yapÄ±lmÄ±ÅŸ.');
                    document.getElementById('signupWarning').style.display = 'block';
                }
                else if (msg.d == -2) {
                    $("#signupWarning").text('KayÄ±t sÄ±rasÄ±nda beklenmeyen bir hata oluÅŸtu.');
                    document.getElementById('signupWarning').style.display = 'block';
                }
                else {
                    //Success
                    parent.window.location.href = 'Default.aspx';

                }

            },
            error: function() {
                //some error occured
                $("#signupWarning").text('KayÄ±t sÄ±rasÄ±nda beklenmeyen bir hata oluÅŸtu.');
                document.getElementById('signupWarning').style.display = 'block';
            }
        });

    }
}

$(document).ready(function() {

    // empty for now
					
});
					 
$("#btnSignUp").click(function(e) {

    e.preventDefault();
    registerUser();
