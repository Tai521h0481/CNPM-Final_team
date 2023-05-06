/*$(document).ready(function () {
});

function UserLogin() {
    var logObj = {
        usr_username: $('#username').val(),
        usr_password: $('#password').val(),
    }

    $ajax({
        url: "/Login/UserValidate",
        type: "POST",
        data: JSON.stringify(logObj),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result == true) {
                alert("Login Succesfull");
                LoginRedirect();
            } else {
                alert("Username or password is incorrect");

            }

        }
    })

}

function LoginRedirect() {
    url = "/DemoList/List";
    window.location = url;
}*/