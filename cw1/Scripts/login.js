/* LOGIN SCRIPT */
/* Gets username returned from controller and allows login persistence with sessionstorage. 
 * Also toggles different views for login homepage (sign up, login, or home).
 */

//When document is ready, check if a user's already logged in and proceed to log in.
$(document).ready(function () {
    checkLoggedUser();
    logIn();
});

/* Login function */
/* Checks if a user's already logged in; if not, get username from controller and add it to sessionStorage.*/
function logIn() {
    checkLoggedUser();
    var buffer = $("#control").text().split(":");   //split ViewBag.Message string (with format "user:username")
    var username = buffer[1];
    if (buffer[0] == "user" && username.length > 0) {   //check username is valid (i.e. ViewBag.Message isn't empty)
        $("#control").empty();  //clear ViewBag.Message string
        sessionStorage.setItem("user", username);   //add to SessionStorage
        displayLoggedHome(username);    //hide login form
    }
}

/* Logout function */
/* Deletes user key from SessionStorage. */
function logOut() {
    sessionStorage.removeItem("user");
    $("#loggedForm").fadeOut(function () {  
        $("#loginForm").fadeIn();   //show login form again
    })
}

/* Check user is logged function */
/* Checks a user is already saved in SessionStorage (i.e. a user's logged in)*/
function checkLoggedUser() {
    var user = sessionStorage.getItem("user");
    if (user != null) {
        displayLoggedHome(user);    //if a user is logged in, hide login form
    }
}

/**
 * Display home function
 * Hides login form
 * @param {any} user
 */
function displayLoggedHome(user) {
    $("#loginForm").fadeOut(function () {
        $("#loggedForm").fadeIn();
        $("#welcome").text("Welcome " + user + "!");
    });
}