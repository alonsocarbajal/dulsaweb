$(document).ready(() => {
    //console.log('prototipo seleccionado');
    //$('#dato-prototipo').hide();
    $('#Descripcion').change(function () {
        if ($(this).val() !== '') {
            //console.log($('#dato-prototipo').show());
            //$('#dato-prototipo').show();
            var serviceURL = 'GetPrototipo?Descripcion=' + $(this).val();
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
            //$('#dato-prototipo').html('');
            //$('#dato-prototipo').hide();
            $('#version').val('');
        }


        function successFunc(data, status) {
            var body = data.Version;
            $('#version').val(body);
        }

        function errorFunc() {
            alert('error');
        }
    });
});