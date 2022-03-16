function checkJson() {
    var username = $("#loginUsername").val();
    var password = $("#loginPassword").val();
    $.getJSON("/Content/yo.json", function (data) {
        alert("ok")
        $.each(data, function (key, val) {
            alert(val)
            //if (username == val[0]) {
            //    if (password == val[1]) {
            //        alert("Logged!");
            //    } else {
            //        alert("Wrong password");
            //    }
            //} else {
            //    alert("User not found");
            //}
        });
    }).fail(function (data) {
        alert("ERROR getting data")
    });
}