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
            success: function (data) {
                if (data.d == -1) {
                    $("#searchResult").html(''); 
                    $("#ResultTotal").html('');
                    $("#warningMessage").text('Aradığınız kriterlere uygun kayıt bulunamadı...');
                    $("#warningMessage").show();
                }
                else {
                    $("#searchResult").html(''); //clear search results
                    $("#warningMessage").hide();
                    //Write functionality to display data
                    $("#searchResult").append(CreateTableView(data.d, 'CssClassName', true));
                }
               
            },
            error: function (result) {
                alert("Error: " + result);
            }
        });
    }

    // This function creates a standard table with column/rows
    // Parameter Information
    // objArray = Anytype of object array, like JSON results
    // theme (optional) = A css class to add to the table (e.g. <table class="<theme>">
    // enableHeader (optional) = Controls if you want to hide/show, default is show
    function CreateTableView(objArray, theme, enableHeader) {

        // set optional theme parameter
        if (theme === undefined) {
            theme = ''; //default theme
        }

        if (enableHeader === undefined) {
            enableHeader = true; //default enable headers
        }

        // If the returned data is an object do nothing, else try to parse
        var array = typeof objArray != 'object' ? JSON.parse(objArray) : objArray;

        var str = '<div class="' + theme + '">';
        
        $("#ResultTotal").text('Bulunan sonuç : ' + array.length);
        $("#ResultTotal").show();

        // table head
        //if (enableHeader) {
        //    str += '<thead><table><tbody><tr>';
        //    for (var index in array[0]) {
        //        str += '<th scope="col">' + index + '</th>';
        //        break;
        //    }
        //    str += '</tr></tbody></table></thead>';
        //}


    //    <div class="result">

    //  <div class="result-avatar">
    //    <img alt="Ydnr5yfbjch" src="https://d3bzqalhiutipz.cloudfront.net/avatars/396910/tiny/yDnr5YfbJCH.png">
    //  </div>

    //  <div class="title">
    //    <a href="/tasks/pickup-and-deliver-soup-care-pkg-to-sick-friend">Pickup and deliver soup &amp; care pkg to sick friend</a>
    //  </div>

    //  <div class="result-content">
    //    I'm in California and my BFF is sick. I'd love to send a task rabbit to bring a care package :)...
    //  </div>

    //</div>

        // table body
        str += '';
        for (var i = 0; i < array.length; i++) {
            str += (i % 2 == 0) ? '<div class="result">' : '<div class="result">';

            for (var index in array[i]) {

               
                if (array[i][index] == null) {
                    str += '<div> </div>';
                }
                else {
                    if (index === 'UserID') {
                        //test
                        str += '<hr><div class="result-avatar" style="float:left; margin-right:10px; "><img alt src="Image.ashx?id=' + array[i][index] + '" id="imgProfile" class="img-rounded" style="width:50px; height:50px;"> </div>';
                    }

                    

                    if (index === 'TaskTitle')
                    {

                        str += '<div class="title" style="float:left; "><a href="/TaskDetails.aspx?id=' + array[i]['ID'] + '">' + array[i][index] + '</a></div><br>';
                       
                    }

                    if (index === 'TaskDetail') {

                        str += '<div class="detail" style="display:block;"> ' + array[i][index] + ' </div>';

                    }
                
                }
            }
            str += '</div>';
        }
        str += '</div>';
        return str;
    }
}



$(document).ready(function () {

    $('#bodyContent_InputSearchTask').focus();
      
    $("#bodyContent_InputSearchTask").keypress(function (e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            $("#btnSearchTask").click();
        }
    });

    $("#btnSearchTask").click(function () {

        var task = $("#bodyContent_InputSearchTask").val();

        SearchTask(task);
    });

});