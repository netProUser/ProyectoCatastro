

/*
 * chosen-readonly - Readonly support for Chosen selects
 * @version v1.0.6
 * @link http://github.com/westonganger/chosen-readonly
 * @license MIT
 */

(function ($) {

    $.fn.chosenReadonly = function (isReadonly) {
        var elements = this.filter(function (i, item) {
            return $(item).data('chosen');
        });

        elements.on('chosen:updated', function () {
            var item = $(this);
            if (item.attr('readonly')) {
                var wasDisabled = item.is(':disabled');

                item.attr('disabled', 'disabled');
                item.data('chosen').search_field_disabled();

                if (wasDisabled) {
                    item.attr('disabled', 'disabled');
                } else {
                    item.removeAttr('disabled');
                }
            }
        });

        if (isReadonly) {
            elements.attr('readonly', 'readonly');
        } else if (isReadonly === false) {
            elements.removeAttr('readonly');
        }

        elements.trigger('chosen:updated');

        return this;
    };

}(window.jQuery || window.Zepto || window.$));

// 
// -- Funcionar para validar los mantenmientos al momento de grabar o editar
//
function validarFormulario(event, button, entidad) {
        event.preventDefault();
        button.attr('disabled', 'disabled');
        var url = $('#frm' + entidad).attr("action");
        var formData = $('#frm' + entidad).serialize();
        $.ajax({
            url: url, type: "POST", data: formData, dataType: "json",
            success: function (response) {
                if ( response.success )  {
                    $('#modal' + entidad).modal('toggle');
                    $('#tabla' + entidad).DataTable().ajax.reload();
                    var mensaje = ($('#frm' + entidad).find("#Estado").val() === 1) ? "Registro grabado correctamente" : "Registro modificado correctamente";
                    toastr.success(mensaje, "Mensaje del Sistema", { "progressBar": true });
                } else  {
                    toastr.error(response.responseText, "Mensaje del Sistema", { "progressBar": true });
                }
            },
            //error: function (response) {
            error: function (jqXHR, status, err) {
                //var result = jqXHR.responseJSON;
                var modelStateErrors = jqXHR.responseJSON;
                //var modelStateErrors = response.responseJSON;
                for (var i = 0; i < modelStateErrors.length; i++) {
                    $('span[data-valmsg-for="' + modelStateErrors[i].key + '"]').text(modelStateErrors[i].errors[0]).addClass('has-error');
                }
                //toastr.error("Se encontro un problema al momento de registrar", "Mensaje del Sistema", { "progressBar": true });
            },
            complete: function () {
                button.removeAttr('disabled');
            }
        });
}
function validarFormularioMant(event, button, entidad, entidad2) {
    event.preventDefault();
    button.attr('disabled', 'disabled');
    var url = $('#frm' + entidad).attr("action");
    var formData = $('#frm' + entidad).serialize();
    $.ajax({
        url: url, type: "POST", data: formData, dataType: "json",
        success: function (response) {
            if (response.success) {
                $('#modal' + entidad).modal('toggle');
                $('#tabla' + entidad2).DataTable().ajax.reload();
                var mensaje = ($('#frm' + entidad).find("#Estado").val() === 1) ? "Registro grabado correctamente" : "Registro modificado correctamente";
                toastr.success(mensaje, "Mensaje del Sistema", { "progressBar": true });
            } else {
                toastr.error(response.responseText, "Mensaje del Sistema", { "progressBar": true });
            }
        },
        //error: function (response) {
        error: function (jqXHR, status, err) {
            //var result = jqXHR.responseJSON;
            var modelStateErrors = jqXHR.responseJSON;
            //var modelStateErrors = response.responseJSON;
            for (var i = 0; i < modelStateErrors.length; i++) {
                $('span[data-valmsg-for="' + modelStateErrors[i].key + '"]').text(modelStateErrors[i].errors[0]).addClass('has-error');
            }
            //toastr.error("Se encontro un problema al momento de registrar", "Mensaje del Sistema", { "progressBar": true });
        },
        complete: function () {
            button.removeAttr('disabled');
        }
    });
}
function validarFormularioConArchivo(event, button, entidad) {
    event.preventDefault();
    button.attr('disabled', 'disabled');
    var url = $('#frm' + entidad).attr("action");
    var form = $('#frm' + entidad)[0];
    var dataString = new FormData(form);
    $.ajax({
        url: url,  //Server script to process data
        type: 'POST',
        xhr: function () {  // Custom XMLHttpRequest
            var myXhr = $.ajaxSettings.xhr();
            if (myXhr.upload) { // Check if upload property exists
                myXhr.upload.addEventListener('progress', progressHandlingFunction, false);
            }
            return myXhr;
        },
        success: function (response) {
            if (response.success) {
                $('#modal' + entidad).modal('toggle');
                $('#tabla' + entidad).DataTable().ajax.reload();
                var mensaje = ($('#frm' + entidad).find("#Estado").val() === 1) ? "Registro grabado correctamente" : "Registro modificado correctamente";
                toastr.success(mensaje, "Mensaje del Sistema", { "progressBar": true });
            } else {
                toastr.error(response.responseText, "Mensaje del Sistema", { "progressBar": true });
            }
        },
        error: function (response) {
            console.log(response);
            var modelStateErrors = response.responseJSON;
            if (modelStateErrors) {
                for (var i = 0; i < modelStateErrors.length; i++) {
                    $('span[data-valmsg-for="' + modelStateErrors[i].key + '"]').text(modelStateErrors[i].errors[0]).addClass('has-error');
                }
            } else {
                alert('Se detecto un problema validando el archivo subido');
            }

        },
        complete: function (response) {
            console.log(response)
            button.removeAttr('disabled');
        },
        data: dataString,
        cache: false,
        contentType: false,
        processData: false
    });
}
function validarFormularioManzanaUrbana(button, entidad, fin) {
    button.attr('disabled', 'disabled');
    var url = $('#frm' + entidad).attr("action");
    var formData = $('#frm' + entidad).serialize();
    $.ajax({
        url: url, type: "POST", data: formData, dataType: "json",
        success: function (response) {
            if (response.success) {
                if (fin) {
                    $('#modal' + entidad).modal('toggle');
                    $('#tabla' + entidad).DataTable().ajax.reload();
                    var mensaje = ($('#frm' + entidad).find("#Estado").val() === 1) ? "Registro grabado correctamente" : "Registro(s) modificado correctamente";
                    toastr.success(mensaje, "Mensaje del Sistema", { "progressBar": true });
                }
            } else {
                toastr.error(response.responseText, "Mensaje del Sistema", { "progressBar": true });
            }
        },
        error: function (response) {
            var modelStateErrors = response.responseJSON;
            for (var i = 0; i < modelStateErrors.length; i++) {
                $('span[data-valmsg-for="' + modelStateErrors[i].key + '"]').text(modelStateErrors[i].errors[0]).addClass('has-error');
            }
            //toastr.error("Se encontro un problema al momento de registrar", "Mensaje del Sistema", { "progressBar": true });
        },
        complete: function () {
            if (fin) {
                button.removeAttr('disabled');
            }
        }
    });
}
function progressHandlingFunction(e) {
    if (e.lengthComputable) {
        var percentComplete = Math.round(e.loaded * 100 / e.total);
        $("#FileProgress").css("width",
        percentComplete + '%').attr('aria-valuenow', percentComplete);
        $('#FileProgress span').text(percentComplete + "%");
    }
    else {
        $('#FileProgress span').text('unable to compute');
    }
}
function mostrarModal(id, focus) {
    $("#modal" + id).modal('show');
    if (focus) {
        $("#modal" + id).on('shown.bs.modal', function () { $('#' + focus).focus().select();});
    }
}

// 
// -- Funcionar para eliminar los mantenimientos
//
function eliminarFormulario(event, button, entidad) {
    event.preventDefault();
    button.attr('disabled', 'disabled');
    var url = $('#frmEliminar' + entidad).attr("action");
    var formData = $('#frmEliminar' + entidad).serialize();
    $.post(url, formData,
    function (response) {
        if (response.success) {
            $('#tabla' + entidad).DataTable().ajax.reload();
            $('#modalEliminar' + entidad).modal('toggle');
            toastr.success("Registro Eliminado Correctamente", "Mensaje del Sistema", { "progressBar": true });
        } else {
            toastr.error(response.responseText, "Mensaje del Sistema", { "progressBar": true });
        }
        console.log(response);
    }).always(function () {
        button.removeAttr('disabled');
    });
}

//
//--
//
function validarFormularioGenerarSolicitud(event, button, entidad) {
    event.preventDefault();
    button.attr('disabled', 'disabled');
    var url = $('#frm' + entidad).attr("action");
    var formData = $('#frm' + entidad).serialize();
    $.ajax({
        url: url, type: "POST", data: formData, dataType: "json",
        success: function (response) {
            console.log(formData);
            if (response.success) {
                //$('#modal' + entidad).modal('toggle');
                //$('#tabla' + entidad).DataTable().ajax.reload();
                var mensaje = ($('#frm' + entidad).find("#Estado").val() === 1) ? "Registro grabado correctamente" : "Registro modificado correctamente";
                toastr.success(mensaje, "Mensaje del Sistema", { "progressBar": true });
            } else {
                toastr.error(response.responseText, "Mensaje del Sistema", { "progressBar": true });
            }

        },
        error: function (response) {
            console.log(response);
            var modelStateErrors = response.responseJSON;
            for (var i = 0; i < modelStateErrors.length; i++) {
                $('span[data-valmsg-for="' + modelStateErrors[i].key + '"]').text(modelStateErrors[i].errors[0]).addClass('has-error');
            }
            //toastr.error("Se encontro un problema al momento de registrar", "Mensaje del Sistema", { "progressBar": true });
        },
        complete: function () {
            button.removeAttr('disabled');
        }
    });
}

// 
// -- Opciones predefinidas de datatable
//
$.extend(true, $.fn.DataTable.defaults, {
    language: {
        "lengthMenu": "Mostrando _MENU_ registros por página",
        "zeroRecords": "",
        "info": "Mostrando página _PAGE_ de _PAGES_",
        "infoEmpty": "",
        "infoFiltered": "(filtrado de _MAX_ total de registros)",
        "search": "Buscar",
        "searchPlaceholder": "",
        "paginate": {
            "first": "Primero",
            "last": "Último",
            "next": "Siguiente",
            "previous": "Anterior"
        },
        "emptyTable": "No se han encontrado registros en la tabla",
        "loadingRecords": "Cargando...",
        "processing": "Procesando...",
    },
    responsive: {
        details: false
    },
    dom: 'Bfrtip',
    searching: false,
    ordering: false,
    processing: true,
    serverSide: true,
    pageLength: 10,
});

$(document).ready(function () {
    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        $($.fn.dataTable.tables(true)).css('width', '100%');
        $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
    });
});

$(function () {
    // 
    // -- Funcionar cargar los tooltip
    //
    $("body").tooltip({ selector: '[data-toggle=tooltip]' });
    //$('input').keyup(function () {this.value = this.value.toLocaleUpperCase()});
})

function LeftZero(number, width) {
    // 
    // -- Agregar ceros a la izquierda param1: numero, param2: digitos.
    //
    var numberOutput = Math.abs(number); /* Valor absoluto del número */
    var length = number.toString().length; /* Largo del número */
    var zero = "0"; /* String de cero */

    if (width <= length) {
        if (number < 0) {
            return ("-" + numberOutput.toString());
        } else {
            return numberOutput.toString();
        }
    } else {
        if (number < 0) {
            return ("-" + (zero.repeat(width - length)) + numberOutput.toString());
        } else {
            return ((zero.repeat(width - length)) + numberOutput.toString());
        }
    }
}

function DecimalZero(number) {
    var str = number + "";
    var dot = str.lastIndexOf('.');
    var isDecimal = dot !== -1;
    var integer = isDecimal ? str.substr(0, dot) : str;
    var decimals = isDecimal ? str.substr(dot + 1) : "";
    decimals = pad(decimals, 2, 0);
    var result = integer + '.' + decimals;
    return result;
}

function pad(input, length, padding) {
    var str = input + "";
    return (length <= str.length) ? str : pad(str + padding, length, padding);
}

function lpad(input, length, padding) {
    var str = input + "";
    return (length <= str.length) ? str : lpad(padding + str, length, padding);
}

function tableToJson(table) {
    var data = [];
    var i = 0;
    // first row needs to be headers
    var headers = [];
    for (i = 0; i < table.rows[0].cells.length; i++) {
        headers[i] = table.rows[0].cells[i].innerHTML.toLowerCase().replace(/ /gi, '');
    }
    data.push(headers);
    // go through cells
    for (i = 1; i < table.rows.length; i++) {

        var tableRow = table.rows[i];
        var rowData = {};

        for (var j = 0; j < tableRow.cells.length; j++) {

            rowData[headers[j]] = tableRow.cells[j].innerHTML;

        }

        data.push(rowData);
    }

    return data;
}

function ZeroIzqCaracter(number, width) {
    //var numberOutput = Math.abs(number); /* Valor absoluto del número */
    var length = number.toString().length; /* Largo del número */
    var zero = "0"; /* String de cero */
    var totalzero = "";


    for (var j = 0; j < width; j++) {
        totalzero = zero.concat(totalzero);
    }

        if (length < width) {
            var cant = width - length;
            for (var i = 0; i < cant; i++) {
                number = zero.concat(number);
                //number = zero + number.toString();
            }

        }



        if (totalzero === number) {
            return '';
        }
    
    return number;
}

function validate_fechaMayorQue(fechaInicial, fechaFinal) {
    var valuesStart = fechaInicial.split("/");
    var valuesEnd = fechaFinal.split("/");

    // Verificamos que la fecha inicial no sea mayor que la fecha final
    var dateStart = new Date(valuesStart[2], (valuesStart[1] - 1), valuesStart[0]);
    var dateEnd = new Date(valuesEnd[2], (valuesEnd[1] - 1), valuesEnd[0]);
    if (dateStart > dateEnd) {
        return 0;
    }
    return 1;
}

function validate_fechaMayorIgualQue(fechaInicial, fechaFinal) {
    var valuesStart = fechaInicial.split("/");
    var valuesEnd = fechaFinal.split("/");

    // Verificamos que la fecha inicial no sea mayor o igual a la fecha final
    var dateStart = new Date(valuesStart[2], (valuesStart[1] - 1), valuesStart[0]);
    var dateEnd = new Date(valuesEnd[2], (valuesEnd[1] - 1), valuesEnd[0]);
    if (dateStart >= dateEnd) {
        return 0;
    }
    return 1;
}



