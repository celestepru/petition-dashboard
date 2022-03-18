$(document).ready(function () {
    checkLoggedUser();
    logIn();
});

function logIn() {
    checkLoggedUser();
    var buffer = $("#control").text().split(":");
    var username = buffer[1];
    if (buffer[0] == "user" && username.length > 0) {
        $("#control").empty();
        sessionStorage.setItem("user", username);
        displayLoggedHome(username);
    }
}

function logOut() {
    sessionStorage.removeItem("user");
    $("#loggedForm").fadeOut(function () {
        $("#loginForm").fadeIn();
    })
}

function checkLoggedUser() {
    var user = sessionStorage.getItem("user");
    if (user != null) {
        displayLoggedHome(user);
    }
}

function displayLoggedHome(user) {
    $("#loginForm").fadeOut(function () {
        $("#loggedForm").fadeIn();
        $("#welcome").text("Welcome " + user + "!");
    });
}