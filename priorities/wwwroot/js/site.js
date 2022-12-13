// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(".use-task").click(function () {
    var $row = $(this).closest("tr");

    var $name = $row.find("td").eq(1).text();
    var $desc = $row.find("td").eq(2).text();

    console.log("name: " + $name + " desc: " + $desc);

    var url = "@Url.Action("CompleteTask","Home")";

    var model = { Name: $name, Description: $desc };

    console.log(model);
    console.log(JSON.stringify(model));

    $.ajax({
        type: "POST",
        data: JSON.stringify(model),
        url: url,
        contentType: "application/json",
                dataType: "json",
            success: function(response) {
                alert("Response:" + response.Name + response.Description);
            },
        failure: function (response) {
            alert(respnse.responseText);
        },
        error: function (response) {
            alert(respnse.responseText);
        }

    });

    //$.post(url, model);
});