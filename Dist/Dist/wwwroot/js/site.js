$(function() {
    $("#proposedDate").datepicker();

    // Load Grid
    $("#appointmentGrid").load("/Home/Appointments", function () {

        // Confirm handler
        $("a[data-id]").on("click", function (event) {
            event.preventDefault();
            var row = $("tr[data-id=" + $(this).data("id") + "]")
            var api = $(this).prop("href");
            row.addClass("table-success");
            var jqxhr = $.get(api, function () {
                row.fadeOut(800);
            })
                .fail(function () {
                    row.removeClass("table-success").addClass("table-danger");
                });
        })
        // Change appointment handler
        $("a[data-change-id]").on("click", function (event) {
            event.preventDefault();
            var row = $("tr[data-id=" + $(this).data("change-id") + "]")
            row.addClass("table-warning");
            $("#changeId").val($(this).data("change-id"));
            $("#api").val($(this).prop("href"));

        })


    });

    function cleanUp(id) {
        if (id != "") {
            var row = $("tr[data-id=" + id + "]")
            row.removeClass("table-warning");
            $("#changeId").val("");;
            $("#api").val("");
            $("#proposedDate").val("Pick Date");
            $("#proposedTime option:eq(0)").prop('selected', true);
            $("#proposedDate").removeClass("is-invalid");
            $("#proposedTime").removeClass("is-invalid");
        }
    }

    $("#btnChange").on("click", function (event) {

        var valid = true;
        if ($("#proposedDate").val() == "Pick Date") {
            valid = false;
            $("#proposedDate").addClass("is-invalid");
        }
        if ($("#proposedTime").children("option:selected").val() == "Pick Time") {
            valid = false;
            $("#proposedTime").addClass("is-invalid");
        }

        if (!valid)
            return;

        var id = $("#changeId").val();
        var row = $("tr[data-id=" + id + "]")
        var data = $("form").serialize()
        var api = $("#api").val();
        var jqxhr = $.post(api,data, function (event) {
            cleanUp(id);
            row.addClass("table-info");
            $("a[data-change-id=" + id + "]").fadeOut(50);
            $("a[data-id=" + id + "]").fadeOut(50);
            $("label[data-id=" + id + "]").fadeIn(50);
            $('#changeModal').modal("hide");
        })
            .fail(function () {
                row.removeClass("table-success").addClass("table-danger");
            });

    })

    $('#changeModal').on('hidden.bs.modal', function (e) {
        var id = $("#changeId").val();
        cleanUp(id);
    })
})