$(document).ready(function () {
        var buffer = $("#control").text().split(":");
        var username = buffer[1];
    if (buffer[0] == "user" && username.length > 0) {
        $("#control").hide();
        $("#loginForm").fadeOut(function () {
            $("#loggedForm").fadeIn();
        });
        setCookie("username", username, 1);
        localStorage.setItem("user", username);
        $("#welcome").text("Welcome " + username + "!");
    } else if (buffer[0] == "signup") {
        $("#control").text("Nice, you're all signed up! Login below to start.");
    }
});

function setCookie(cname, cvalue, exdays) {
    const d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}