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