$(document).ready(function () {
        var buffer = $("#control").text().split(":");
        var username = buffer[1];
    if (buffer[0] == "user" && username.length > 0) {
        $("#control").hide();
        $("#loginForm").fadeOut(function () {
            $("#loggedForm").fadeIn();
        });
        sessionStorage.setItem("user", username);
        $("#welcome").text("Welcome " + username + "!");
    } else if (buffer[0] == "signup") {
        $("#control").text("Nice, you're all signed up! Login below to start.");
    }
});