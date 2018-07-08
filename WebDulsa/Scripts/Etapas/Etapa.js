$(document).ready(() => {
    console.log('aaaa');
    show();
    setTimeout(function () { alert("Hello"); }, 3000);
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
        console.log(data);
        asignarCheckbox(data);
    }

    function errorFunc() {
        asignarCheckbox(undefined);
    }
    function asignarCheckbox(lista) {
        var template = '<div class="form-group row align-items-center"><div class="col-md-2"></div>';
        for (var i = 0; i < 24; i++) {
            if (i % 4 == 0) {
                template += '</div>';
                template += '<div class="form-group row align-items-center"><div class="col-md-2"></div>';
            }
            var isDisable = lista.find(l => l == (i+1)) ? 'disabled' : '';
            template += '<div class="col-md-2"><div class="form-check-inline ' +isDisable +'">';
            template += '<label class="form-check-label">';
            template += '<input type="checkbox" id="chklote' + i + '" class="form-check-input" ' + isDisable + '> Lote ' + (i + 1) + '</label>';
            template += '</div></div>';
        }
        template += '</div >';
        $('#contenedor').html(template);
        //hide();
    }
});