function showLoadingScreen() {
    $('body').addClass('loading');
}

function hideLoadingScreen() {
    $('body').removeClass('loading');
}
function alertModalMini(message, type) {
    $('#alertModalMini .modal-body').html(message);
    if (!type) {
        //do nothing
    } else if (type == 'error') {
        $('#alertModalMini .modal-body').css('color', 'red');
    } else if (type == 'success') {
        $('#alertModalMini .modal-body').css('color', 'green');
    } else {
        $('#alertModalMini .modal-body').css('color', type);
    }
    $('#alertModalMini').modal('show');
}

$(document).on("change", "#file", function () {
    var allowedExtensions = /(\.jpg|\.bmg|\.png|\.gif|\.jpeg)$/i;
    var fileUpload = $(this).get(0);
    var files = fileUpload.files;
    if (fileUpload.files.length > 0 && !allowedExtensions.exec(fileUpload.value)) {
        alertModalMini('Invalid image format', 'error');
    }
    else {
        var reader = new FileReader();
        reader.onload = function (e) {
            $("img[name=view-file]").attr("src", e.target.result);
            $("img[name=view-file]").show();
        }
        reader.readAsDataURL(this.files[0]);
    }
});
$(document).on("click", "img[name=view-file]", function () {
    $("#file-edit").trigger("click");
    $(document).on("change", "#file-edit", function () {
        var allowedExtensions = /(\.jpg|\.bmg|\.png|\.gif|\.jpeg)$/i;
        var fileUpload = $(this).get(0);
        var files = fileUpload.files;
        if (fileUpload.files.length > 0 && !allowedExtensions.exec(fileUpload.value)) {
            alertModalMini('Invalid image format', 'error');
        }
        else {
            var reader = new FileReader();
            reader.onload = function (e) {
                $("img[name=view-file]").attr("src", e.target.result);

            }
            reader.readAsDataURL(this.files[0]);
        }
    });
})

