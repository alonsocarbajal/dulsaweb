$(document).ready(() => {
    show();
    $(".currency").maskMoney({
        formatOnBlur: true, selectAllOnFocus: false,  selectAllOnFocus: true, reverse: true, prefix: '$' });
    $('body').submit(function (event) {
        $('#Iris').val($('#Iris').maskMoney('unmasked')[0]);
        $('#PrecioM2Excedente').val($('#PrecioM2Excedente').maskMoney('unmasked')[0]);
        $('#MontoEsquina').val($('#MontoEsquina').maskMoney('unmasked')[0]);
        $('#Dalia').val($('#Dalia').maskMoney('unmasked')[0]);
        $('#Azalea').val($('#Azalea').maskMoney('unmasked')[0]);
        $('#Orquidea').val($('#Orquidea').maskMoney('unmasked')[0]);
        $('#Bugambilia').val($('#Bugambilia').maskMoney('unmasked')[0]);
        var listaSeleccionado = [];
        $('form input[type=checkbox]').each(function () {
            if (this.checked && !this.disabled) {
                console.log('a');
                listaSeleccionado.push($(this).val());
            }
        });
        if (listaSeleccionado.length == 0) {
            $('#error-lotes').show();
            event.preventDefault();
        }
        $('form').append('<input type="hidden" id="Lotes" name="Lotes" value="' + (listaSeleccionado) + '"/>');
       //$('Iris').val($('.form-control').maskMoney('unmasked')[0]);
       //$('Iris').val($('.form-control').maskMoney('unmasked')[0]);
       //$('Iris').val($('.form-control').maskMoney('unmasked')[0]);
       // $('Iris').val($('.form-control').maskMoney('unmasked')[0]);
        //event.preventDefault();
    });
    var serviceURL = 'GetlotesDisponibles';
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
        asignarCheckbox(data);
    }

    function errorFunc() {
        asignarCheckbox(undefined);
    }
    function asignarCheckbox(lista) {
        var template = '<div class="form-group row align-items-center"><div class="col-md-2"></div>';
        for (var i = 0; i < 84; i++) {
            if (i % 12 == 0) {
                template += '</div>';
                template += '<div class="form-group row align-items-center">';
            }
            var isDisable = lista.find(l => l == (i+1)) ? 'disabled' : '';
            template += '<div class="col-md-2"><div class="form-check-inline ' +isDisable +'">';
            template += '<label class="form-check-label">';
            template += '<input type="checkbox" id="chklote' + (i+1) + '" value="'+ (i+1) +'" class="form-check-input" ' + isDisable + '> Lote ' + (i + 1) + '</label>';
            template += '</div></div>';
        }
        template += '</div >';
        $('#contenedor').html(template);
        hide();
    }
});
