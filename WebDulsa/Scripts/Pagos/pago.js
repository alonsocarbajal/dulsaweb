$(document).ready(() => {
    $('.form-control').change(function (event) {
        if (event.target.id === 'LoteId' || event.target.id === 'PrototipoId')
        {
            var lote = $('#LoteId').val();
            var prototipo = $('#PrototipoId').val();
            if ((lote !== '') && (prototipo !== ''))
            {
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
                case 'Iris':
                    valor = dato.Iris;
                    break;
                case 'AZALEA':
                    valor = dato.Azalea;
                    break;
                case 'ORQUIDEA':
                    valor = dato.ORQUIDEA;
                    break;
                case 'BUGAMBILIA':
                    valor = dato.ORQUIDEA;
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
        }

        function errorFunc() {
            alert('Ocurrio un error al recuperar información');
        }
    })
});