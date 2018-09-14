

$(document).on("click", "#search-btn", function () {
    showLoadingScreen();
    var url = $('#search-btn').data('url');
    var name = $("input[name=name]").val();
    var parent = $("select[name=parentForSearch]").val();
    var status = $("select[name=status]").val();
    $.get(url, { name: name, parent: parent, status: status })
        .done(function (data) {
            hideLoadingScreen();
            $('#list-data').html("");
            $('#list-data').html(data);
        });
});
$(document).on("click", "#reset-btn", function () {
    showLoadingScreen();
    var url = $('#search-btn').data('url');
    $(".tables table input").val("");
    $(".tables table select").each(function () {
        $(this).val($(this).find("option:first").val());
    });
    $.get(url)
        .done(function (data) {
            hideLoadingScreen();
            $('#list-data').html("");
            $('#list-data').html(data);
        });
});

$(document).on("click", "#link-delete", function () {
    var id = $(this).data("id");
    $(document).on("click", "#delete", function () {
        showLoadingScreen();
        $.ajax({
            url: '/Delete',
            type: 'post',
            success: function (data) {
                if (data.status == "SUCCESS") {

                    $.ajax({
                        url: '/_PartialBo',
                        data: {
                            id: id
                        },
                        beforeSend: function () {

                        },
                        success: function (res) {
                            hideLoadingScreen();
                            $('#list-data').html(res);
                            if (res.status = "SUCCESS") {
                                alertModalMini("Delete successfully!", "success");
                            }

                        },
                        error: function () {
                            alertModalMini("Đã có lỗi xảy ra ", "error");
                        }
                    })
                } else {
                    hideLoadingScreen();
                    alertModalMini("Không thể xóa vì bộ này có chứa các họ.", "error");
                }

            },
            error: function () {
                alertModalMini("Đã có lỗi xảy ra ", "error");
            },
        });

        $("#myModal-delete").modal("hide");

    });
})