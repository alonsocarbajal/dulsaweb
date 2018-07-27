$(document).ready(() => {
    //$("#precio-total").maskMoney({
    //    formatOnBlur: true, selectAllOnFocus: false, selectAllOnFocus: true, reverse: true, prefix: '$'
    //});
    $('.form-control').change(function (event) {
        if (event.target.id === 'LoteId' || event.target.id === 'PrototipoId')
        {
            var lote = $('#LoteId').val();
            console.log($(this).val());
            var prototipo = $('#PrototipoId').val();
            if ((lote !== '') && (prototipo !== ''))
            {
                show();
                getLote(lote, prototipo); 
            }
        }

        function getLote(lote, prototipo) {
            var serviceURL = window.location.origin + '/pagos/GetEtapa?loteId=' + lote;
            $.ajax({
                type: "Get",
                url: serviceURL,
                data: param = "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (datos) {
                    asignarValores(datos);
                }, error: function (error) {
                    hide();
                }
            });
        }

        function asignarValores(dato) {
            $('#excedente').html(dato.MtsExcedente ?'Si' : 'No');
            $('#mts-excedente').html(dato.MtsExcedente ? dato.MtsExcedente : 0);

            var lote = $('#LoteId').val();
            var prototipo = $('#PrototipoId').val();
            var precioxm2 = 0;
            var mtexcedente = 0;
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

            
            
            var precioxm2 = dato.PrecioM2Excedente;
            console.log(precioxm2);
            var mtexcedente = dato.MtsExcedente;
            console.log(mtexcedente);
            console.log(valor);
            valor += dato.EsEsquina ? dato.MontoEsquina : 0;
            var total = (precioxm2 * mtexcedente) + valor;
            console.log(total);
            
            //alert(new Intl.NumberFormat().format(total));
            $('#precio-total').html(new Intl.NumberFormat().format(total));
            //$('#precio-total').html(total);
            //$("#precio-total").maskMoney({
            //    formatOnBlur: true, selectAllOnFocus: false, selectAllOnFocus: true, reverse: true, prefix: '$'
            //});
            $('#casa-modelo').html(prototipo);
            serviceURL = 'GetPrototipo?descripcion=' + prototipo;
            $.ajax({
                type: "Get",
                url: serviceURL,
                data: param = "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: successPrototipo
            });
        }
        function successPrototipo(dato, status) {
            $('#mts-construccion').html(dato.MetrosCuadrado);
            hide();
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
    });
    
});