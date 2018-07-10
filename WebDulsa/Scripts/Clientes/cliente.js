$(document).ready(() => {
     $(".currency").maskMoney({
        formatOnBlur: true, selectAllOnFocus: false, selectAllOnFocus: true, reverse: true, prefix: '$'
    });
    $('body').submit(function (event) {
        $('#Sueldo').val($('#Sueldo').maskMoney('unmasked')[0]);
    });
});