

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