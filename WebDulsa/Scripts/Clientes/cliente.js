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
   

});