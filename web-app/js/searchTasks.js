function SearchTask(task) {

    var validated = true;
    var warningText = '';

    if (IsNullOrEmpty(task) == true && validated == true) {

        $('#bodyContent_InputSearchTask').closest('.form-group').addClass("has-error");
        $('#bodyContent_InputSearchTask').focus();

        warningText = "Lütfen aranacak anahtar kelimeyi girin..";
        validated = false;
    }
    else {
        //alert(task);

        $.ajax({
            type: "POST",
            url: "WsTasks.asmx/SearchTask",
            data: "{" + "'searchTask':'" + task + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                
                PageMethods.set_path("SearchTask.aspx");
                PageMethods.SearchTask2Json = function (msg) {
                    PageMethods._staticInstance.SearchTask2Json(msg.d);
                }

                    //window.location.href = 'Home.aspx';
                
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

    $('#bodyContent_InputSearchTask').focus();

    //enter key event
    $("body").keypress(function (e) {
        if (e.which == 13) {
            $("#btnSearchTask").click();
        }
    });

    $("#btnSearchTask").click(function () {

        var task = $("#bodyContent_InputSearchTask").val();

        SearchTask(task);
    });

});