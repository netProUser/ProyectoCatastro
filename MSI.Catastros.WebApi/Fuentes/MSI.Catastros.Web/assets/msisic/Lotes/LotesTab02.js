
var contIdLoteLindero = 4;

var URLFuente = ROOT + "Lotes/ListarFuentesColin";
$.post(URLFuente, function (data) {
    $('#CodigoFuente').children('option:not(:first)').remove();
    $.each(data, function (i, obj) {
        $('#CodigoFuente').append($('<option>').text(obj.Text).attr('value', obj.Value));
    });
});
function RegistrarLindero(lado) {
    $.get(ROOT + "Lotes/AgregarLindero/" + lado,
        function (response) {
        var id = "#modalRegistrarLindero";
        $(id).modal().html(response);

    });
};
$("#modalRegistrarLindero").on('shown.bs.modal', function () { $('#MedidaLadoCam').focus().select() });

tablaLinderos = $("#tablaLinderos").DataTable({
    "ajax": {
        "url": ROOT + "Lotes/CargarLinderos",
        "type": "POST",
        "datatype": "json",
        "data": function (d) {
            d.CodigoDistrito = $('#CodDist').val(); d.CodigoSector = $('#CodSect').val(); d.CodigoManzana = $('#CodManz').val(); d.CodigoLote = $('#CodLote').val();
            d.Estatico = Estatico; 
        }
    },
    "columns": [
        {
            'render': function (data, type, full, meta) {
                var disabled = (full.CodigoCorrelativo == "0001") ? "" : "";
                return '<button data-toggle="tooltip" title="Editar" ' + deshabilitar + ' class="btn mr-1 text-center btnEditLindero btn-default btn-xs glyphicon glyphicon-edit" type="button" ></button>' +
                '<button data-toggle="tooltip" ' + deshabilitar + ' title="Eliminar"  ' + disabled + ' class="btn mr-1 text-center btnDeleteLindero btn-default btn-xs glyphicon glyphicon-trash" type="button" ></button>';
            }, "className": "text-center"
        },
        { "data": "NombreLado", "name": "NombreLado", "className": "text-center" },
        //CAMBIOS NUEVOS CATASTRO GJLR-INI
        //Se comenta codigo original
        //{ "data": "NumeroLado", "name": "NumeroLado", "className": "text-center" },
        //CAMBIOS NUEVOS CATASTRO GJLR-FIN
        { "data": "MedidaLadoCam", render: function (data, type, full) { return parseFloat(data).toFixed(4); }, "name": "MedidaLadoCam",  "className": "text-right" },
        { "data": "MedidaLadoOfi", render: function (data, type, full) { return parseFloat(data).toFixed(4); }, "name": "MedidaLadoOfi",  "className": "text-right" },
        //CAMBIOS NUEVOS CATASTRO GJLR-INI
        //Se comenta codigo original
        //{ "data": "NombreFuente", "name": "TipoEdificacionNombreTipoEdificacion", "className": "text-center" },
        //CAMBIOS NUEVOS CATASTRO GJLR-FIN
        //{ "data": "NombreTipoColindante", "name": "NumTipoEdificacion", "className": "text-center" },
        //CAMBIOS NUEVOS CATASTRO GJLR-INI
        { "data": "CodigoVia", "name": "CodigoVia", "className": "text-center" },
        //CAMBIOS NUEVOS CATASTRO GJLR-FIN
        { "data": "ListaLoteColindantes", "name": "ListaLoteColindantes", "className": "text-center" },
        //CAMBIOS NUEVOS CATASTRO GJLR-INI
        //Se comenta codigo original
        //{ "data": "CodigoAlturaVia", "name": "CodigoAlturaVia", "className": "text-center" },
        //CAMBIOS NUEVOS CATASTRO GJLR-FIN
        //CAMBIOS NUEVOS CATASTRO GJLR-INI
        { "data": "CodigoFlatAvenida", "name": "CodigoFlatAvenida", "className": "text-center" },
        { "data": "CodigoFlatParque", "name": "CodigoFlatParque", "className": "text-center" },
        //CAMBIOS NUEVOS CATASTRO GJLR-FIN
        { "data": "CodigoCorrelativo", "name": "NumeroPuerta", "autoWidth": true, "className": "hide_column" },
        { "data": "CodigoLado", "name": "NumeroPuerta", "autoWidth": true, "className": "hide_column" },
        { "data": "CodigoColindante", "name": "NumeroPuerta", "autoWidth": true, "className": "hide_column" }     
    ],
    "language": { "lengthMenu": "", "info": "", "emptyTable": "" },
    "processing": true,
    "serverSide": false,
    "paging": false,
});

$("#tablaLinderos tbody").on('click', 'button.btnEditLindero', function (event) {
    var cell = this;
    var data = tablaLinderos.row($(this).parents('tr')).data();
    var enlace = ROOT + 'Lotes/AgregarLindero';
    $.post(enlace,
        {
            CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(),
            NumeroLado: data.NumeroLado, Codigo: data.CodigoCorrelativo, CodigoLado: data.CodigoLado, Estatico: Estatico
        }
        , function (response) {
            var id = "#modalRegistrarLindero"; $(id).modal().html(response);
        });
});
$("#tablaLinderos tbody").on('click', 'button.btnDeleteLindero', function (event) {
    var cell = this;
    var data = tablaLinderos.row($(this).parents('tr')).data();
    var CodigoTipoSolicitud = $('#CodigoTipSol').val();
    var NumeroSolicitud = $('#CodigoNumSol').val();
    var CodigoPeriodo = $('#Periodo').val()
    var CodigoCorrel = data.CodigoCorrelativo;
    var enlace = ROOT + 'Lotes/EliminarLindero';
    console.log('Data', data);
    if (ValidarEliminarColindante(data.CodigoColindante, data.NombreColindante)) {
        bootbox.confirm({
            title: "Mensaje del Sistema", message: "¿Esta seguro de borrar el registro?",
            buttons: { confirm: { label: '<i class="fa fa-trash"></i> Eliminar ', className: "btn btn-danger" }, cancel: { label: '<i class="fa fa-times"></i> Cancelar' } },
            callback: function (result) {
                if (result) {
                    $.post(enlace,
                    {
                        CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(),
                        NumeroLado: data.NumeroLado, CodigoLado: data.CodigoLado, Codigo: data.CodigoCorrelativo, Estatico: Estatico
                    }
                    , function (response) {
                        tablaLinderos.ajax.reload();
                        RecuperarNormaUrbana();
                        toastr.success("Registro eliminado correctamente", "Mensaje del Sistema", { "progressBar": true });
                    });
                }
            }
        });
    }
});

function ActualizarCodigo(element) {
    var id = element.id;
    var valor = $('#CodigoViaAnterior').val();
    if (!valor) {
        $('#CodigoViaAnterior').val(element.value);
        if ($('#CodigoTipoColind').val() === "010001") {
            $('#CodigoAlturaVia').removeAttr('disabled');
        } else {
            $('#CodigoAlturaVia').attr('disabled', 'disabled');
        }
        $.post(ROOT + 'Lotes/ListarAlturaVia', function (data) {
            $('#CodigoAlturaVia').children('option:not(:first)').remove();
            $.each(data, function (i, obj) {
                $('#CodigoAlturaVia').append($('<option>').text(obj.Text).attr('value', obj.Value));
            });
        });
    } else {
        var veri = ValidarColindante(valor, 1, $("#CodigoViaAnterior option:selected").text())
        if (veri == true) {
            if ($('#CodigoTipoColind').val() === "010001") {
                $('#CodigoAlturaVia').removeAttr('disabled');
            } else {
                $('#CodigoAlturaVia').attr('disabled', 'disabled');
            }
            $.post(ROOT + 'Lotes/ListarAlturaVia', function (data) {
                $('#CodigoAlturaVia').children('option:not(:first)').remove();
                $.each(data, function (i, obj) {
                    $('#CodigoAlturaVia').append($('<option>').text(obj.Text).attr('value', obj.Value));
                });
            });
        }
    }
}
function ValidarColindante(valor, tipo, nombre) {
    if (nombre) {
        var contLind = 0;
        $.each(tablaLinderos.data(), function (index, Item) {
            console.log('Compare', nombre.toUpperCase().replace(/\s+/g, ""), Item.NombreColindante.toUpperCase().replace(/\s+/g, ""));
            if (nombre.toUpperCase().replace(/\s+/g, "") === Item.NombreColindante.toUpperCase().replace(/\s+/g, "")) {
                contLind++;
            }
        });
        console.log('CONTADOR', contLind)
        if (contLind > 1) {
            return true;
        }
    }

    var tablaMunicipalTemp = tablaMunicipalAsignado.data();
    var contador = 0;
    if ($('#CodigoCorrelativo').val()) {
        $.each(tablaMunicipalTemp, function (index, Item) {
            
            if (valor === Item.CodigoManzanaVia + '-' + Item.CodigoVia) {
                if (tipo === 1) {
                    $('#CodigoColindante').val(valor);
                    toastr.warning("No puede modificar esta Vía porque esta siendo utilizada en Ubicación y/o Entradas", "Mensaje del Sistema", { "progressBar": true });
                } else {
                    toastr.warning("No puede eliminar esta Vía porque esta siendo utilizada en Ubicación y/o Entradas", "Mensaje del Sistema", { "progressBar": true });
                }
                contador++;
                return false;
            }
        });
        var tablaRetiroTemp = tablaRetiroMunicipal.data();
        $.each(tablaRetiroTemp, function (index, Item) {
            if (valor === Item.CodigoManzanaVia + '-' + Item.CodigoVia) {
                if (tipo === 1) {
                    $('#CodigoColindante').val(valor);
                    toastr.warning("No puede modificar esta Vía porque esta siendo utilizada en Retiro Municipal", "Mensaje del Sistema", { "progressBar": true });
                }
                else { toastr.warning("No puede eliminar esta Vía porque esta siendo utilizada en Retiro Municipal", "Mensaje del Sistema", { "progressBar": true }); }
                contador++;
                return false;
            }
        });
    }
    return (contador === 0) ? true : false;
}

function ValidarEliminarColindante(valor,  nombre) {
    if (nombre) {
        var contLind = 0;
        $.each(tablaLinderos.data(), function (index, Item) {
            if (nombre.toUpperCase().replace(/\s+/g, "") === Item.NombreColindante.toUpperCase().replace(/\s+/g, "")) {
                contLind++;
            }
        });
        if (contLind > 1) {
            return true;
        }
    }
    var tablaMunicipalTemp = tablaMunicipalAsignado.data();
    var contador = 0;
        $.each(tablaMunicipalTemp, function (index, Item) {
            if (valor === Item.CodigoManzanaVia + '-' + Item.CodigoVia) {
                toastr.warning("No puede eliminar esta Vía porque esta siendo utilizada en Ubicación y/o Entradas", "Mensaje del Sistema", { "progressBar": true }); 
                contador++;
                return false;
            }
        });
        var tablaRetiroTemp = tablaRetiroMunicipal.data();
        $.each(tablaRetiroTemp, function (index, Item) {
            if (valor === Item.CodigoManzanaVia + '-' + Item.CodigoVia) {
                 toastr.warning("No puede eliminar esta Vía porque esta siendo utilizada en Retiro Municipal", "Mensaje del Sistema", { "progressBar": true });
                contador++;
                return false;
            }
        });
    
    return (contador === 0) ? true : false;
}