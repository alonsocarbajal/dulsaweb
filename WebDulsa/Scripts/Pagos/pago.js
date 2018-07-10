$(document).ready(() => {
    $('.form-control').change(function (event) {
        if (event.target.id === 'LoteId' || event.target.id === 'PrototipoId')
        {
            var lote = $('#LoteId').val();
            var prototipo = $('#PrototipoId').val();
            if ((lote !== '') && (prototipo !== ''))
            {
                show();
                getLote(lote, prototipo); 
            }
        }

        function getLote(lote, prototipo) {
            var serviceURL = 'GetEtapa?loteId=' + lote;
            $.ajax({
                type: "Get",
                url: serviceURL,
                data: param = "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: successFunc,
                error: errorFunc
            });
        }
        
        function successFunc(data, status) {
            asignarValores(data);
        }
        function asignarValores(dato) {
            $('#excedente').html(dato.mtsExcedente ?'Si' : 'No');
            $('#mts-excedente').html(dato.mtsExcedente ? dato.mtsExcedente: 0);
            var lote = $('#LoteId').val();
            var prototipo = $('#PrototipoId').val();
            var valor = 0;
            switch (prototipo) {
                case 'DALIA':
                    valor = dato.Dalia;
                    break;
                case 'IRIS':
                    valor = dato.Iris;
                    break;
                case 'AZALEA':
                    valor = dato.Azalea;
                    break;
                case 'ORQUIDEA':
                    valor = dato.Orquidea;
                    break;
                case 'BUGAMBILIA':
                    valor = dato.Bugambilia;
                    break;
            }
            $('#precio-total').html(valor);
            $('#casa-modelo').html(prototipo);
            serviceURL = 'GetPrototipo?descripcion=' + prototipo;
            $.ajax({
                type: "Get",
                url: serviceURL,
                data: param = "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: successPrototipo,
                error: errorFunc
            });
        }
        function successPrototipo(dato, status) {
            $('#mts-construccion').html(dato.MetrosCuadrado);
            hide();
        }

        function errorFunc() {
            alert('Ocurrio un error al recuperar información');
        }
    })
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
        //var prototipo = $('#PrototipoId').val();
        //if (prototipo == '')
        //    return false;
        //var serviceURL = 'GetPrototipoId?descripcion=' + prototipo;
        //$.ajax({
        //    type: "Get",
        //    url: serviceURL,
        //    data: param = "",
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",
        //}).done((data) => {
        //    $('#PrototipoId').val(data.Id);
        //    console.log(event.target.submit());
        //    });
        //event.preventDefault();
    });
});