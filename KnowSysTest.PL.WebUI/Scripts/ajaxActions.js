/// <reference path="jquery-1.9.1.js" />
/// <reference path="jquery-1.9.1.intellisense.js" />
/// <reference path="~/Scripts/bootstrap.js" />
(function () {
    $("#DTOContainer").on("click",
        ".ajax-button",
        function (e) {
            "use strict";
            e.preventDefault();
            var $this = $(this),
                form = this.form,
                id = $this.data("id"),
                title = $this.data("title");

            $.ajax({
                type: $(form).attr("method"),
                url: $(form).attr("action"),
                data: { "Id": id },
                success: function (data) {
                    $("#ModalTitle").text(title);
                    $("#ModalBody").html(data);
                    $("#ModalWindow").modal();
                },
                error: function (xhr) {
                    console.log(xhr);
                }
            });
            debugger;
        });
})();