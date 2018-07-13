$(document).ready(() => {
    $('.fprospeccion').change(function () {
        console.log($(this).val());
        if ($(this).val() === 'MKT') 
            $('#div-opcionMkt').show();
        else
            $('#div-opcionMkt').hide();
        //$(this).val(false);
        //switch () {
        //    case 'MKT':
        //        $("#radio_1").prop("checked", true);
        //        break;
        //}
    });

    
        //$("#datepicker").datepicker();
   
    $(".currency").maskMoney({
        formatOnBlur: true, selectAllOnFocus: false, selectAllOnFocus: true, reverse: true, prefix: '$'
    });
    $('body').submit(function (event) {
        $('#Sueldo').val($('#Sueldo').maskMoney('unmasked')[0]);
    });
});