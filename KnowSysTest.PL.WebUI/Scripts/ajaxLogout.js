/// <reference path="jquery-1.9.1.js" />
/// <reference path="jquery-1.9.1.intellisense.js" />
/// <reference path="~/Scripts/bootstrap.js" />
(function () {
    $("#AuthenticationManager").on("click",
        ".ajax-button",
        function (e) {
            "use strict";
            e.preventDefault();
            var $this = $(this),
                url = $this.attr("href");

            $.ajax({
                url: url,
                success: function (data) {
                    $("#ModalTitle").text("Logout");
                    $("#ModalBody").html(data);
                    $("#ModalWindow").modal();
                },
                error: function (xhr) {
                    console.log(xhr);
                }
            });
        });
})();