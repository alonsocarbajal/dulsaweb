$(document).ready(() => {
    $(".currency").maskMoney({
        formatOnBlur: true, selectAllOnFocus: false, selectAllOnFocus: true, reverse: true, prefix: '$'
    });
    $('body').submit(function (event) {
        $('#Precio').val($('#Precio').maskMoney('unmasked')[0]);
    });
});