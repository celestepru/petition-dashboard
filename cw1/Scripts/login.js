$(document).ready(function () {
    var buffer = $("#control").text().split(":");
    var username = buffer[1];
    if (username.length > 0) {
        $("#control").hide();
        $("#loginForm").fadeOut(function () {
            $("#loggedForm").fadeIn();
        })
        localStorage.setItem("user", username);
        $("#welcome").text("Welcome " + username + "!");
    }
});