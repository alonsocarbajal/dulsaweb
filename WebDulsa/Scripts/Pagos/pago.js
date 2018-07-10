$(document).ready(() => {
    $(".currency").maskMoney({
        formatOnBlur: true, selectAllOnFocus: false, selectAllOnFocus: true, reverse: true, prefix: '$'
    });
    $('body').submit(function (event) {
        $('#MontoApartado').val($('#MontoApartado').maskMoney('unmasked')[0]);
        $('#MontoEnganche').val($('#MontoEnganche').maskMoney('unmasked')[0]);
        $('#ImportePago1').val($('#ImportePago1').maskMoney('unmasked')[0]);
        $('#ImportePago2').val($('#ImportePago2').maskMoney('unmasked')[0]);
        $('#ImportePago3').val($('#ImportePago3').maskMoney('unmasked')[0]);
        $('#ImportePago4').val($('#ImportePago4').maskMoney('unmasked')[0]);
        $('#ImportePago5').val($('#ImportePago5').maskMoney('unmasked')[0]);
    });

    console.log('cliente seleccionado');

    $('#LoteId').change(function () {
        if ($(this).val() !== '') {
            var serviceURL = 'GetEtapa?loteId=' + $(this).val() + '&PrototipoId=' + $(this).val();
            $.ajax({
                type: "Get",
                url: serviceURL,
                data: param = "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: successFunc,
                error: errorFunc

            });
        } else {
            $('#dato-precio').html('');
        }


        function successFunc(data, status) {
            var body = 

            $('#dato-precio').html(body);
            //console.log(body);
        }

        function errorFunc() {
            alert('error');
        }
});