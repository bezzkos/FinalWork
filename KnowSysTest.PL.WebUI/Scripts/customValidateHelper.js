/// <reference path="jquery-1.9.1.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="jquery-1.9.1.intellisense.js" />

$.validator.addMethod("alphanumeric", function (value, element) {
    return this.optional(element) || /^\w+$/i.test(value);
}, "Letters, numbers, and underscores only please");

$.validator.addMethod("pwcheck", function (value) {
    return /^[A-Za-z0-9\d=!\-@._*]*$/.test(value) // consists of only these
        &&
        /[A-Z]/.test(value) // has a uppercase letter
        &&
        /[0-9]/.test(value);
}, "Password allowed to contain only A-Z a-z 0-9 @ * _ - . ! symbols, should be atleast one digit and one uppercase letter");

// add * to required field labels
$("label.required").append("&nbsp;<strong>*</strong>&nbsp;");