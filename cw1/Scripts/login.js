$(document).on("click", "#loginSubmit", function () {
    var password = $("#loginPassword").val();
    var username = $("#loginUsername").val();
    var arr = [];
    $.getJSON("/Content/users.json", function (data) {
        $.each(data, function (key, val) {
            if (username) {
                if (username == val[0]) {
                    if (password == val[1]) {
                        alert("Logged in!")
                    } else {
                        alert("Wrong password")
                    }
                } else {
                    alert("Username not found");
                }
            } else {
                alert("Please insert valid username");
            }
        });
    }).fail(function (data) {
        alert("FAILED to fetch data");
    })
});