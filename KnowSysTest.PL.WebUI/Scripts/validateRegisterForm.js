/// <reference path="jquery-1.9.1.js" />
/// <reference path="jquery-1.9.1.intellisense.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="customValidateHelper.js" />

$(document).ready(function () {
    "use strict";

    $("#RegisterForm").validate({
        onkeyup: false, //turn off auto validate whilst typing
        onfocusout: false,
        rules: {
            login: {
                required: true,
                minlength: 3,
                alphanumeric: true,
                remote: {
                    url: "/Pages/Users/ValidateLogin.cshtml",
                    type: "post",
                    error: function(xhr) {
                        console.log(xhr);
                    }
                }
            },
            password: {
                required: true,
                rangelength: [8, 50],
                pwcheck: true
            }
        },
        messages: {
            login: {
                required: "Enter a login",
                minlength: jQuery.validator.format("Enter at least {0} characters"),
                remote: jQuery.validator.format("Login \"{0}\" is already in use")
            },
            password: {
                required: "Provide a password",
                rangelength: jQuery.validator.format("Password should be between {0} and {1} characters long")
            }
        }
    });
});
