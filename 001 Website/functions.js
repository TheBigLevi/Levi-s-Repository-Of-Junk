var usernameFormat = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/;
var emailFormat = /@/;
var cookieCredentials = [];

function initialize() {

    if (checkelem("username")) { document.getElementById("username").value = fetchCookie("_username"); }
    if (checkelem("password")) { document.getElementById("password").value = fetchCookie("_password"); }
    if (checkelem("email")) { document.getElementById("email").value = fetchCookie("_email"); }
    alert("Page Loaded");
}

function checkelem(elem) {
    var element = document.getElementById(elem);
    if (typeof (element) != 'undefined' && element != null) {
        return true;
    }
    return false;
}

function saveCredentialsRegister() {

    //evt.preventDefault();

    var m_username = document.getElementById("username").value;
    var m_password = document.getElementById("password").value;
    var m_email = document.getElementById("email").value;

    alert("Variables working")

    if ((m_username == "") || (usernameFormat.test(m_username)) || (m_username.length < 8)) {
        alert("Username invalid. Please use values of a - z, A - Z and 0 - 9 and it must consists of atleast 8 characters!")
        return;
    } else if ((m_password == "") || (m_password.length < 8)) {
        alert("Password invalid. Please have atleast 8 characters in your password!")
        return;
    } else if ((m_email == "") || ((emailFormat.test(m_email)) == false)) {
        alert("Email invalid. Please use a proper email!")
        return;
    } else {

        setCookie("_username", m_username);
        setCookie("_password", m_password);
        setCookie("_email", m_email);

        alert("Account created. You will be redirected shortly!")

        loadLogin();
    }
}

function setCookie(m_field, m_input) {

    var expirationAttribute = new Date();
    expirationAttribute.setTime(expirationAttribute.getTime() + (m_expir * 24 * 60 * 60 * 1000));
    var m_expir = "expires=" + expirationAttribute.toUTCString();
    document.cookie = m_field + "=" + m_input + ";" + m_expir + ";path=/";
    alert(document.cookie)
}

function fetchCookie(m_field) {
    var name = m_field + "=";
    //var cookies_without_spaces = cookies_with_spaces.replace(/\s/g, "");
    var cookieArray = document.cookie.split(";");
    for (var i = 0; i < cookieArray.length; i++) {
        var cookies = cookieArray[i];
        while (cookies.charAt(0) == ' ')
            cookies = cookies.substring(1);
        if (cookies.indexOf(name) == 0)
            return cookies.substring(name.length, cookies.length);
    }
    return "";
}

function loadLogin() {
    self.location = "login.html";
}

function loadRegister() {
    self.location = "register.html";
}

function subscriptionSelect() {

}