$(document).ready(() => {
    $(".form-control").maskMoney({
        formatOnBlur: true, selectAllOnFocus: false, selectAllOnFocus: true, reverse: true, prefix: '$'
    });
    var serviceURL = window.location.origin + '/pagos/GetPaqueteObras?descripcion=';
    $.ajax({
        type: "Get",
        url: serviceURL,
        data: param = "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (datos) {
            var template = '';
            for (var i = 0; i < datos.length; i++) {
                template = '   <div class="form-group row align-items-end">' +
                    '<div class="col-md-1"><input hidden  id="pU' + datos[i].Id +'" value="'+datos[i].Precio+'"/></div>' +
                    '<div class="col-4">' + datos[i].Concepto + '</div>';
                template += datos[i].Tipo === 'M2' ?
                    '<div class="col-2"><input class="form-control" type="number" id="mt2' + datos[i].Id + '"/></div><div class="col-2"></div>' :
                    '<div class="col-2"></div><div class="col-2"><input class="form-control" type="number" id="pza' + datos[i].Id + '"/></div>';
                template += '<div class="col-2"><input class="form-control" id="total' + datos[i].Id + '" data-symbol="$" data-thousands="." data-decimal="," readonly/></div>' +
                    '</div>';
                $('#contenedor-paquetes').append(template);
            }

        }, error: function (error) {
            console.log(error);
        }
    });
    $(document).on('keyup', function (evt) {
        var id = evt.target.id.substring(3, evt.target.id.length);
        cantidad = $('#' + evt.target.id).val();
        var pU = $('#pU' + id).val();
        var total = parseFloat(pU) * parseFloat(cantidad);
        //$('#total' + id).val(total);
        $('#total' + id).maskMoney('mask', total, {
            formatOnBlur: true, selectAllOnFocus: false, selectAllOnFocus: true, reverse: true, prefix: '$'
        });
        //$('#total' + id).val(new Intl.NumberFormat().format(total));
    });
});