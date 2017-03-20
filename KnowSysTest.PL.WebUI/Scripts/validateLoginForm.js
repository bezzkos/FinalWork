/// <reference path="jquery-1.9.1.js" />
/// <reference path="jquery-1.9.1.intellisense.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="customValidateHelper.js" />

$(document).ready(function () {
    "use strict";

    $("#LoginForm").validate({
        onkeyup: false, //turn off auto validate whilst typing
        onfocusout: false,
        rules: {
            login: {
                required: true
            },
            password: {
                required: true,
                remote: {
                    url: "/Pages/Users/ValidateUser.cshtml",
                    type: "post",
                    data: {
                        "login": function () {
                            return $('#LoginForm :input[name="login"]').val();
                        }
                    },
                    error: function (xhr) {
                        console.log(xhr);
                    }
                }

            }
        },
        messages: {
            login: {
                required: "Enter a login"
            },
            password: {
                required: "Enter a password",
                remote: "Login or password is incorrect"
            }
        }
    });
});