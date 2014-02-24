function SearchTask(task) {

    var validated = true;
    var warningText = '';

    if (IsNullOrEmpty(task) == true && validated == true) {

        $('#InputSearchTask').closest('.form-group').addClass("has-error");
        $('#InputSearchTask').focus();

        warningText = "Lütfen aranacak anahtar kelimeyi girin..";
        validated = false;
    }
    else {
        alert(task);

        $.ajax({
            type: "POST",
            url: "WsTasks.asmx/SearchTask",
            data: "{" + "'task':'" + task + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                
                    window.location.href = 'Home.aspx';
                
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

    $('#InputSearchTask').focus();

    //enter key event
    $("body").keypress(function (e) {
        if (e.which == 13) {
            $("#btnSearchTask").click();
        }
    });

    $("#btnSearchTask").click(function () {

        var task = $("#InputSearchTask").val();       

        SearchTask(task);
    });

});