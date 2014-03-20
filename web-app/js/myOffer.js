function GetMyOffer(userId) {
  
    $.ajax({
        type: "POST",
        url: "WsTasks.asmx/MyOffer",
        data: "{" + "'userId':'" + userId + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("#myOfferResult").html(''); //clear search results
            //alert(data.d);
            //Write functionality to display data
            $("#myOfferResult").append(CreateTableView(data.d, 'CssClassName', true));
        },
        error: function (result) {
            alert("Error: " + result);
        }
    });
};

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

                    str += '<hr><div class="result-avatar" style="float:left; margin-right:10px; margin-left:15px; "><img src="Image.ashx?id=' + array[i]['UserID'] + '" id="imgProfile" class="img-rounded" style="width:50px; height:50px;"> </div>';
                }


                if (index === 'TaskTitle') {

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
};

$(document).ready(function () {

    var userId = $("#hdnUserId").val();

    GetMyOffer(userId);

});