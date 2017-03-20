/// <reference path="jquery-1.9.1.js" />
/// <reference path="jquery-1.9.1.intellisense.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="customValidateHelper.js" />
/// <reference path="~/Scripts/bootstrap.js" />

$(document).ready(function () {
    "use strict";
    // validate signup form on keyup and submit
    $("#OnValidate").validate({
        rules: {
            Answer: {
                required: true
            },
            //AnswerCheckbox: {
            //    required: true
            //},
            //AnswerRadio: {
            //    required: true
            //},
            Description: {
                required: true
            },
            Question: {
                required: true
            },
            Title: {
                required: true
            }
        },
        messages: {
            AnswerCheckbox: {
                required: "Choose atleast one"
            },
            AnswerRadio: {
                required: "Choose one"
            }
        },
        showErrors: function (errorMap, errorList) {

            // Clean up any tooltips for valid elements
            $.each(this.validElements(),
                function(index, element) {
                    var $element = $(element);
                    var $parent = $element.parent();

                    $element.data("title", "") // Clear the title - there is no error associated anymore
                        .removeClass("error")
                        .tooltip("destroy");

                    $parent.removeClass("has-error");
                });

            // Create new tooltips for invalid elements
            $.each(errorList,
                function(index, error) {
                    var $element = $(error.element);
                    var $parent = $element.parent();

                    $element
                        .tooltip("destroy") // Destroy any pre-existing tooltip so we can repopulate with new tooltip content
                        .data("title", error.message)
                        .addClass("error")
                        .tooltip(); // Create a new tooltip based on the error messsage we just set in the title

                    $parent.addClass("has-error");
                });
        }
    });
});
