$(document).ready(() => {
    $('#LoteId').change(function (event) {
        console.log($(this).val());
        var template = '<p class="text-center"><strong>Casa modelo:<></strong></p>' +
            '<p class="text-center" > <strong>m<sup>2</sup> de construcción:</strong></p >' +
            '<p class="text-center"><strong>Excedente:</strong></p>' +
            '<p class="text-center"><strong>m<sup>2</sup> de excedente:</strong></p>' +
            '<p class="text-center"><strong>Precio total:</strong></p>';
        var serviceURL = 'GetEtapa?loteId='+$(this).val();

        $.ajax({
            type: "Get",
            url: serviceURL,
            data: param = "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successFunc,
            error: errorFunc
        });

        function successFunc(data, status) {
            asignarValores(data);
        }
        function asignarValores(dato) {
            var template = '<p class="text-center"><strong>Casa modelo:'+dato.+'</strong></p>' +
                '<p class="text-center" > <strong>m<sup>2</sup> de construcción:</strong></p >' +
                '<p class="text-center"><strong>Excedente:</strong></p>' +
                '<p class="text-center"><strong>m<sup>2</sup> de excedente:</strong></p>' +
                '<p class="text-center"><strong>Precio total:</strong></p>';
            $('#card-informacion').html(template);
        }

        function errorFunc() {
            asignarCheckbox(undefined);
        }
    })
});