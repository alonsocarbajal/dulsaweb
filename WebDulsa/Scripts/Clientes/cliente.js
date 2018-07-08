$(document).ready(() => {
    $('.prospeccion').change(function () {
        console.log($(this).val());
        if ($(this).val() === 'Negocio') 
            $('#prospeciones').show();
        else
            $('#prospeciones').hide();
        $(this).val(false);
        //switch () {
        //    case 'MKT':
        //        $("#radio_1").prop("checked", true);
        //        break;
        //}
    });

});