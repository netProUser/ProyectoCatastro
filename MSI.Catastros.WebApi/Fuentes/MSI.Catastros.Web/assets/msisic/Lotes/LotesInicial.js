/// <reference path="LotesInicial.js" />

$('.tabs').tabslet();
$(".chosen-seleccionar").chosen({ width: "100%", placeholder_text_single: "Seleccione una opción" });

$('body').on('keyup', 'input', function () {
    this.value = this.value.toLocaleUpperCase()
});
$('#FiltrarCodigoDistrito').val('31');

//var iniTab02 = 0;
var iniTab04 = 0, iniTab06 = 0;


pickmeup('#FechaResolucion', { format: 'd/m/Y' });

function OcultarOverlay(nombre, mostrar) {
    if (mostrar) {
        $(nombre).LoadingOverlay("show")
        setTimeout(function () {
            if ($('.loadingoverlay').length > 0) { 
                if (nombre === '#tab-4') { iniTab04 = 1; };
                if (nombre === '#tab-6') { iniTab06 = 1; };
                $(nombre).LoadingOverlay("hide"); ActGrab();
            }
        }, 12000);
    }
}


$("#file-0a").fileinput({
    language: "es",
    uploadUrl: ROOT + "Lotes/GrabarImagen",
    uploadExtraData:  function (previewId, index) {
        var model = {CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val()};
        return model;
    },
    maxFileCount: 1,
    allowedFileExtensions: ["jpg", "png", "gif"],
});
// DATOS A ELIMINAR
//$('#FiltrarCodigoTipoSolicitud').val("010003");
//$('#FiltrarNumeroSolicitud').val("000396");
// DATOS A ELIMINAR
$('.numero').number(true, 4, '.', '');

var modifLote = false;
var selecLote = false;

SeleccionarUnidadCatastral();

var tablaMunicipalAsignado;
var tablaRetiroMunicipal;
var tablaLicencias;
var ValidarTab2 = 0;

//CAMBIOS NUEVOS CATASTRO GJLR-INI
var tablaRetiroMunicipalNew;
var tablaJardinAislamientoNew;
var tablaAreaPublicaNew;
var tablaAnchoViaNew;
var tablaLoteReferenciaNew;
//CAMBIOS NUEVOS CATASTRO GJLR-FIN
/*
|--------------------------------------------------------------------------
| TABLAS - Plugin Datatables
|--------------------------------------------------------------------------
*/
var tablaUnidadCatastral = $("#tablaUnidadCatastral").DataTable({
    "ajax": {
        "url": ROOT + "Lotes/CargarSolUnidad", "type": "POST", "datatype": "json",
        "data": function (d) {
            d.FiltrarCodigoTipoSolicitud = $('#CodigoTipSol').val();
            d.FiltrarNumeroSolicitud = $('#CodigoNumSol').val();
            d.FiltrarCodigoPeriodo = $('#Periodo').val();
            d.FiltrarCodigoTipoDocumentoReg = $('#FiltrarCodigoTipoDocumentoReg').val();
        }
    },
    "language": { "lengthMenu": "", "info": "", "emptyTable": "" },
    "processing": true, "serverSide": false, "paging": false,
    "columns": [
        { "data": "CodigoDistrito", "className": "text-center", "width": "15%" }, { "data": "CodigoSector", "className": "text-center" },
        { "data": "CodigoManzana", "className": "text-center" }, { "data": "CodigoLote", "className": "text-center" },
        { "data": "Referencia", "className": "text-center" }, { "data": "EstadoUnidad", "className": "text-center" }, { "data": "FlagTrabajo", "className": "hide_column" },
        { "data": "Bloqueado", "className": "hide_column" },
        { "data": "FlagUsuario", "className": "hide_column" },
        {
            'render': function (data, type, full, meta) {
                if (full.Referencia && full.EstadoUnidad === "T") {
                    return '<button data-toggle="tooltip" title="Eliminar" ' + deshabilitar + ' class="btn mr-1 text-center btnBorrarLote btn-default  glyphicon glyphicon-minus" type="button" ></button>';
                } else {
                    return '';
                }
            }, "className": "text-center"
        },
    ]
});

var tablaUnidadCatastralRef = $("#tablaUnidadCatastralRef").DataTable({
    "ajax": {
        "url": ROOT + "Lotes/CargarSolUnidad", "type": "POST", "datatype": "json",
        "data": function (d) {
            d.FiltrarCodigoTipoSolicitud = $('#CodigoTipSol').val();
            d.FiltrarNumeroSolicitud = $('#CodigoNumSol').val();
            d.FiltrarCodigoPeriodo = $('#Periodo').val();
            d.FiltrarCodigoTipoDocumentoReg = $('#FiltrarCodigoTipoDocumentoReg').val();
            d.FiltrarReferencia = "1";
        }
    },
    "language": { "lengthMenu": "", "info": "", "emptyTable": "" }, "processing": true, "serverSide": false, "paging": false, "iDeferLoading": 0,
    "columns": [
        { "data": "CodigoDistrito", "className": "text-center", "width": "15%" }, { "data": "CodigoSector", "className": "text-center" },
        { "data": "CodigoManzana", "className": "text-center" }, { "data": "CodigoLote", "className": "text-center" },
        { "data": "Referencia", "className": "text-center" }, { "data": "EstadoUnidad", "className": "text-center" }, { "data": "FlagTrabajo", "className": "hide_column" },
        { 'render': function () { return ''; } },
    ]
});

var tablaUnidadCatastralEstatico = $("#tablaUnidadCatastralEstatico").DataTable({
    "ajax": {
        "url": ROOT + "Lotes/CargarSolUnidadEstatico", "type": "POST", "datatype": "json",
        "data": function (d) {
            d.FiltrarCodigoDistrito = $('#FiltrarCodigoDistrito').val();
            d.FiltrarCodigoSector = $('#FiltrarCodigoSector').val();
            d.FiltrarCodigoManzana = $('#FiltrarCodigoManzana').val();
            d.FiltrarCodigoLote = $('#FiltrarCodigoLote').val();
            d.Estatico = true;
        }
    },
    "language": { "lengthMenu": "", "info": "", "emptyTable": "" }, "processing": true, "serverSide": false,
    "scrollY": "400px",
    "scrollCollapse": true,
    "paging": false,
    "columns": [
        { "data": "CodigoDistrito", "className": "text-center", "width": "15%" }, { "data": "CodigoSector", "className": "text-center" },
        { "data": "CodigoManzana", "className": "text-center" }, { "data": "CodigoLote", "className": "text-center" },
        { "data": "Referencia", "className": "text-center" }, { "data": "EstadoUnidad", "className": "text-center" }, { "data": "FlagTrabajo", "className": "hide_column" },
        {
            'render': function (data, type, full, meta) {
                if (full.Referencia ) {
                    return '<button data-toggle="tooltip" title="Eliminar" class="btn mr-1 text-center btnBorrarLote btn-default  glyphicon glyphicon-minus" type="button" ></button>';
                } else {
                    return '';
                }
            }, "className": "text-center"
        },
    ]
});

var tablaHabilitacionUrbana = $("#tablaHabilitacionUrbana").DataTable({
    "ajax": {
        "url": ROOT + "Lotes/CargarHabilitacion", "type": "POST", "datatype": "json",
        "data": function (d) {
            d.CodigoDistrito = $('#CodDist').val();
            d.CodigoSector = $('#CodSect').val();
            d.CodigoManzana = $('#CodManz').val();
            d.CodigoLote = $('#CodLote').val();
            d.Estatico = Estatico;
        }
    },
    "language": { "lengthMenu": "", "info": "", "emptyTable": "" },
    "processing": true,
    "serverSide": false,
    "paging": false,
    "columns": [
        {
            'render': function (data, type, full, meta) {
                return '<button data-toggle="tooltip" title="Editar" '+ deshabilitar + ' class="btn mr-1 text-center btnEditHabil btn-default btn-xs glyphicon glyphicon-edit" type="button" ></button>' +
                '<button data-toggle="tooltip" title="Eliminar" ' + deshabilitar + ' class="btn mr-1 text-center btnDeleteHabil btn-default btn-xs glyphicon glyphicon-trash" type="button" ></button>';
            }, "className": "text-center"
        },
        { "data": "CodigoHabilitacionUrbana", "className": "text-center" }, { "data": "NombreTipoHabilitacion", "className": "text-center" },
        { "data": "NombreHabilitacion", "className": "text-center" }, { "data": "NombreManzanaUrbana", "className": "text-center" },
        { "data": "CodigoManzanaUrbana", "className": "hide_column" }, { "data": "CodigoTipoHabilitacion", "className": "hide_column" },
    ]
});


/*
|--------------------------------------------------------------------------
| FIN TABLAS - Plugin Datatables
|--------------------------------------------------------------------------
*/

/*
|--------------------------------------------------------------------------
| EVENTOS JQUERY
|--------------------------------------------------------------------------
*/
$('#tablaUnidadCatastral tbody').on('click', 'tr', function () {
    var row = $(this);
    var data = tablaUnidadCatastral.row(row).data();
    //$.LoadingOverlay("show");
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected'); $('#tabLotes').hide(); modifLote = false; selecLote = false; $('#GenFicha').attr('disabled', 'disabled'); $('#GenFichaManzana').attr('disabled', 'disabled'); $('#GrabarGeneral').attr('disabled', 'disabled'); $.LoadingOverlay("hide");
    }
    else {
        if (data.FlagUsuario == 0 && !data.Bloqueado) {
            toastr.warning("La Solicitud no se encuentra asociada a tu USUARIO", "Mensaje del Sistema", { "progressBar": true });
        } else
        if (!data.Bloqueado) {
            if (tablaUnidadCatastral.rows('.selected').data().length === 1) {
                tablaUnidadCatastral.rows().every(function () {
                    this.nodes().to$().removeClass('selected')
                })
            }
            $.post(ROOT + "Lotes/BuscarGrabar", {
                CodigoCorrelativo: data.CodigoCorrelativo, CodigoDistrito: data.CodigoDistrito, CodigoLote: data.CodigoLote,
                CodigoManzana: data.CodigoManzana, CodigoNumeroSolicitud: data.CodigoNumeroSolicitud, CodigoSector: data.CodigoSector, CodigoUni: data.CodigoUni
            }, function (response) {
                $('#CodDist').val(response.SolicitudUnidad.CodigoDistrito); $('#CodSect').val(response.SolicitudUnidad.CodigoSector);
                $('#CodManz').val(response.SolicitudUnidad.CodigoManzana); $('#CodLote').val(response.SolicitudUnidad.CodigoLote);
                iniTab04 = 0; iniTab06 = 0;
                if (response.success === true) {
                    RecuperarLote();
                }
                $('#GenFicha').removeAttr('disabled');
                $('#GenFichaManzana').removeAttr('disabled');
                tablaHabilitacionUrbana.ajax.reload();
                tablaUnidadCatastral.$('tr.selected').removeClass('selected');
                row.addClass('selected');
                $('#tabLotes').show();
            });
        }else {
            toastr.error("Solicitud Conforme y Cerrada, Consultar Información por el Modulo  de Consultas", "Mensaje del Sistema", { "progressBar": true });
        }
    }
});
$('#tablaUnidadCatastralEstatico tbody').on('click', 'tr', function () {
    var row = $(this); var data = tablaUnidadCatastralEstatico.row(row).data();
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
        $('#tabLotes').hide(); $('#GenFicha').attr('disabled', 'disabled'); $('#GenFichaManzana').attr('disabled', 'disabled'); $('#GrabarGeneral').attr('disabled', 'disabled'); 
    }
    else {
        if (tablaUnidadCatastralEstatico.rows('.selected').data().length === 1) {
            tablaUnidadCatastralEstatico.rows().every(function () {
                this.nodes().to$().removeClass('selected')
            })
        }
        Estatico = true;
        //$.post(ROOT + "Lotes/BuscarGrabar", {
        //    CodigoCorrelativo: data.CodigoCorrelativo, CodigoDistrito: data.CodigoDistrito, CodigoLote: data.CodigoLote,
        //    CodigoManzana: data.CodigoManzana, CodigoNumeroSolicitud: data.CodigoNumeroSolicitud, CodigoSector: data.CodigoSector, CodigoUni: data.CodigoUni
        //}, function (response) {
        //    $('#CodDist').val(response.SolicitudUnidad.CodigoDistrito); $('#CodSect').val(response.SolicitudUnidad.CodigoSector);
        //    $('#CodManz').val(response.SolicitudUnidad.CodigoManzana); $('#CodLote').val(response.SolicitudUnidad.CodigoLote);
        console.log('Dist', $('#CodDist').val());
        tablaHabilitacionUrbana.ajax.reload();
            //iniTab02 = 0;
            iniTab04 = 0; iniTab06 = 0;
            
            RecuperarLote(Estatico);
            $('#GenFicha').removeAttr('disabled');$('#GenFichaManzana').removeAttr('disabled');
            tablaUnidadCatastral.$('tr.selected').removeClass('selected'); row.addClass('selected');
            $('#tabLotes').show();
            //CAMBIOS NUEVOS CATASTRO GJLR-INI
            $("#miModal").modal("hide");
            //CAMBIOS NUEVOS CATASTRO GJLR-FIN
        //});
    }
});

$('#tabLotes input').change(function () {
    modifLote = true;
});
$('#tabLotes select').change(function () {
    modifLote = true;
});
$("#tablaUnidadCatastral tbody").on('click', 'button.btnBorrarLote', function (event) {
    var data = tablaUnidadCatastral.row($(this).parents('tr')).data();
    var enlace = ROOT + 'Lotes/EliminarLoteTemporal';
    bootbox.confirm({
        title: "Mensaje del Sistema", message: "¿Esta seguro de borrar el registro?",
        buttons: { confirm: { label: '<i class="fa fa-trash"></i> Eliminar ', className: "btn btn-danger" }, cancel: { label: '<i class="fa fa-times"></i> Cancelar' } },
        callback: function (result) {
            if (result) {
                $.post(enlace, {
                    CodigoDistrito: data.CodigoDistrito, CodigoLote: data.CodigoLote, CodigoManzana: data.CodigoManzana, CodigoSector: data.CodigoSector,
                    CodigoTipoSolicitud: $('#CodigoTipSol').val(),
                    CodigoNumeroSolicitud: $('#CodigoNumSol').val(),
                    FiltrarCodigoPeriodo : $('#Periodo').val(),
                    CodigoTipoDocumento: $('#FiltrarCodigoTipoDocumentoReg').val(),
                    TotalFilas: tablaUnidadCatastral.data().count(),
                    Estatico: Estatico
                } , function (response) {
                    tablaUnidadCatastral.ajax.reload(function (json) {
                        var contUni = 0;
                        //tablaUnidadCatastral.rows().every(function () {
                        //    var d = this.data();
                        //    console.log(d.FlagTrabajo);
                        //    if (d.FlagTrabajo === "T") {
                        //        contUni++;
                        //    }
                        //});
                        //if (contUni != 0) {
                        //    tablaUnidadCatastralRef.ajax.reload();
                        //} else {
                        //    tablaUnidadCatastralRef.clear().draw();
                        //}
                        tablaUnidadCatastralRef.ajax.reload();
                        $('#tabLotes').hide();
                    });
                });
            }
        }
    });
    event.stopPropagation();
});

$("#tablaHabilitacionUrbana tbody").on('click', 'button.btnEditHabil', function (event) {
    var data = tablaHabilitacionUrbana.row($(this).parents('tr')).data();
    var enlace = ROOT + 'Lotes/EditarHabilitacion';
    $('#TipoHabilitacion').val(data.CodigoTipoHabilitacion);
    $.post(enlace,
        {
            CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(),
            CodigoHabilitacionUrbana: data.CodigoHabilitacionUrbana, CodigoManzanaUrbana: data.CodigoManzanaUrbana, CodigoTipoHabilitacion: data.CodigoTipoHabilitacion, Estatico: Estatico
        }
        , function (response) {
            var id = "#modalRegistrarHabilitacion"; $(id).modal().html(response);
        });
});
$("#tablaHabilitacionUrbana tbody").on('click', 'button.btnDeleteHabil', function (event) {
    var data = tablaHabilitacionUrbana.row($(this).parents('tr')).data();
    var enlace = ROOT + 'Lotes/EliminarHabilitacion';
    bootbox.confirm({
        title: "Mensaje del Sistema", message: "¿Esta seguro de borrar el registro?",
        buttons: { confirm: { label: '<i class="fa fa-trash"></i> Eliminar ', className: "btn btn-danger" },cancel: { label: '<i class="fa fa-times"></i> Cancelar' } },
        callback: function (result) {
            if (result) {
                $.post(enlace,
                {
                    CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(),
                    CodigoHabilitacionUrbana: data.CodigoHabilitacionUrbana, CodigoManzanaUrbana: data.CodigoManzanaUrbana, Estatico: Estatico
                }
                , function (response) {
                    tablaHabilitacionUrbana.ajax.reload();
                });
            }
        }
    });

});
$('#MonumentoHistorico').change(function () {
    if (this.value === '010001') {
        $('#NumeroResolucion').removeAttr('disabled');
        $('#FechaResolucion').removeAttr('disabled');
    } else {
        $('#NumeroResolucion').attr('disabled', 'disabled').val('');
        $('#FechaResolucion').attr('disabled', 'disabled').val('');
    }
});
$('#btnBuscar').click(function () {
    var codSol = $('#FiltrarCodigoTipoSolicitud').val(); var numVal = $('#FiltrarNumeroSolicitud').val(); var codDoc = $('#FiltrarCodigoTipoDocumentoReg').val();
    tipDoc = $('#FiltrarCodigoTipoDocumentoReg').val();
    $('#btnNuevoLote').attr('disabled', 'disabled');
    if (validarCamposBusqueda(codSol, numVal, tipDoc)) {
        $.ajax({
            url: ROOT + "Lotes/BuscarSolicitud", type: "POST", dataType: "json",
            data: { FiltrarCodigoTipoSolicitud: codSol, FiltrarNumeroSolicitud: numVal, FiltrarCodigoTipoDocumentoReg: codDoc },
            success: function (response) {
                if (response.success) {
                    $('#Periodo').val(response.ProcedimientoNuevo.Periodo);
                    $('#CodigoTipSol').val(response.ProcedimientoNuevo.CodigoTipoSolicitud);
                    $('#CodigoNumSol').val(response.ProcedimientoNuevo.NumeroSolicitud);
                    $('#CodigoTipDoc').val(response.ProcedimientoNuevo.CodigoTipoSolicitud);
                    tablaUnidadCatastral.ajax.reload(
                        function (json) {
                            var contUni = 0;
                            tablaUnidadCatastralRef.ajax.reload();
                        }
                   );
                    $('#CodDist').val(""); $('#CodLote').val(); $('#CodManz').val(""); $('#CodSect').val();
                    $('#tabLotes').hide(); $('.tabs').trigger('show', '#tab-1'); $('#GenFicha').attr('disabled', 'disabled');
                    $('#GenFichaManzana').attr('disabled', 'disabled');
                    $('#GrabarGeneral').attr('disabled', 'disabled');
                    $('#btnNuevoLote').removeAttr('disabled');
                } else {
                    $('#btnNuevoLote').attr('disabled', 'disabled');
                    $('#GenFicha').attr('disabled', 'disabled');
                    $('#GrabarGeneral').attr('disabled', 'disabled');
                    $('#tabLotes').hide();
                    tablaUnidadCatastral.rows().remove().draw();
                    tablaUnidadCatastralRef.rows().remove().draw();
                    toastr.error("No se han encontrado solicitudes", "Mensaje del Sistema", { "progressBar": true });
                }
            },
            complete: function (response) {
            }
        });
    }
});
$('#btnBuscarEstatico').click(function () {
    var codSect = $('#FiltrarCodigoSector').val(); var codManz = $('#FiltrarCodigoManzana').val(); var codLote = $('#FiltrarCodigoLote').val(); var cont;
    if (!$('#FiltrarCodigoSector').val()) { $('#msgErrores').append("<li>Ingrese el código del sector</li>"); cont = true; }
    if (!$('#FiltrarCodigoManzana').val()) { $('#msgErrores').append("<li>Ingrese el código de la manzana</li>"); cont = true; }
    //if (!$('#FiltrarCodigoLote').val()) { $('#msgErrores').append("<li>Ingrese el código del lote</li>"); cont = true; }
    $('#btnNuevoLote').attr('disabled', 'disabled');
    if (!cont) {
        $('#msgErrores').html("");
        $.ajax({
            url: ROOT + "Lotes/BuscarSolicitudEstatico", type: "POST", dataType: "json",
            data: { FiltrarCodigoSector: codSect, FiltrarCodigoManzana: codManz, FiltrarCodigoLote: codLote, Estatico: true },
            success: function (response) {
                if (response.success) {
                    $('#CodDist').val(response.ProcedimientoNuevo.CodigoDistrito); $('#CodSect').val(response.ProcedimientoNuevo.CodigoSector);
                    $('#CodManz').val(response.ProcedimientoNuevo.CodigoManzana); $('#CodLote').val(response.ProcedimientoNuevo.CodigoLote);
                    //CAMBIOS NUEVOS CATASTRO GJLR-INI
                    //$('#tabLotes').hide(); $('.tabs').trigger('show', '#tab-1'); $('#GenFicha').attr('disabled', 'disabled');
                    $('#tabLotes').hide(); $('.tabs').trigger('show', '#tab-3'); $('#GenFicha').attr('disabled', 'disabled');
                    //CAMBIOS NUEVOS CATASTRO GJLR-FIN
                    $('#GenFichaManzana').attr('disabled', 'disabled');
                    $('#GrabarGeneral').attr('disabled', 'disabled');
                    $('#btnNuevoLote').removeAttr('disabled');
                    tablaUnidadCatastralEstatico.ajax.reload(function (res) {
                        tablaUnidadCatastral.columns.adjust().draw();
                        var alto = $('#tablaUnidadCatastralEstatico_wrapper .dataTables_scrollBody').height();
                        if (alto < 399) {
                            $('#tablaUnidadCatastralEstatico_wrapper .dataTables_scrollHead').removeClass('pr-4');
                        } else {
                            $('#tablaUnidadCatastralEstatico_wrapper .dataTables_scrollHead').addClass('pr-4');
                        }
                    });
                } else {
                    $('#btnNuevoLote').attr('disabled', 'disabled');
                    $('#GenFicha').attr('disabled', 'disabled');
                    $('#GrabarGeneral').attr('disabled', 'disabled');
                    $('#tabLotes').hide();
                    tablaUnidadCatastralEstatico.rows().remove().draw();
                    toastr.error("No se ha encontrado el lote", "Mensaje del Sistema", { "progressBar": true });
                }
            },
            complete: function (response) {
            }
        });
    }
});
$('#btnAgregrarHabilitacion').click(function () {
    //if ($('#TipoHabilitacion').val()) {
        $.get(ROOT + "Lotes/RegistrarHabilitacion", function (response) {
            $("#modalRegistrarHabilitacion").modal().html(response);
        });
    //} else {
    //    toastr.warning("Selecione el tipo de habilitación", "Mensaje del Sistema", { "progressBar": true });
    //}
});
$('#btnBienComun').click(function () {
    $.get(ROOT + "Lotes/PorcentajeBienComun", function (response) {
        $("#modalPorcentajeBienComun").modal().html(response);
    });
});
$('#FiltrarCodigoTipoSolicitud').change(function () {
    var URL = "";
    if (this.value === "010001") {
        $('#divTipoDocumento').show();
        URL = ROOT + "RecepcionDocumentos/DocExterno";
        $.post(URL, function (data) {
            $('#FiltrarCodigoTipoDocumentoReg').find('option:not(:first)').remove();
            var items = '<option value="">Seleccione el tipo de documento</option>';
            $.each(data, function (i, item) { items += "<option value='" + item.Value + "'>" + item.Text + "</option>"; });
            $('#FiltrarCodigoTipoDocumentoReg').html(items);
            $('#FiltrarCodigoTipoDocumentoReg').trigger("chosen:updated");
        });
    } else if (this.value === "010002") {
        $('#divTipoDocumento').show();
        URL = ROOT + "RecepcionDocumentos/DocInterno";
        $.post(URL, function (data) {
            $('#FiltrarCodigoTipoDocumentoReg').find('option:not(:first)').remove();
            var items = '<option value="">Seleccione el tipo de documento</option>';
            $.each(data, function (i, item) { items += "<option value='" + item.Value + "'>" + item.Text + "</option>"; });
            $('#FiltrarCodigoTipoDocumentoReg').html(items);
            $('#FiltrarCodigoTipoDocumentoReg').trigger("chosen:updated");
        });
    } else {
        $('#divTipoDocumento').hide();
        $('#FiltrarCodigoTipoDocumentoReg').find('option:not(:first)').remove();
    }
});
/*
|--------------------------------------------------------------------------
| FIN EVENTOS JQUERY
|--------------------------------------------------------------------------
*/


/*
|--------------------------------------------------------------------------
| FUNCIONES
|--------------------------------------------------------------------------
*/

function GenerarFicha() {
    urlFICHA = ROOT + "Reportes/Reports.aspx?CodigoDistrito=" + $('#CodDist').val() + '&CodigoSector=' + $('#CodSect').val() + '&CodigoManzana=' + $('#CodManz').val() + '&CodigoLote=' + $('#CodLote').val() + '&CodigoReporte=01&CodigoEsq=01';
    window.open(urlFICHA);
}
function GenerarFichaManzana() {
    urlFICHAMANZA = ROOT + "Reportes/Reports.aspx?CodigoDistrito=" + $('#CodDist').val() + '&CodigoSector=' + $('#CodSect').val() + '&CodigoManzana=' + $('#CodManz').val() + '&CodigoReporte=03';
    window.open(urlFICHAMANZA);
}

function SeleccionarUnidadCatastral() {
    var URL1 = ROOT + "HabilitacionUrbana/ListarTipoHabilitacion";
    $.post(URL1, function (data) {
        $('#TipoHabilitacion').children('option:not(:first)').remove();
        $.each(data, function (i, obj) {
            $('#TipoHabilitacion').append($('<option>').text(obj.Text).attr('value', obj.Value));
        });
    });
    var URL2 = ROOT + "Lotes/ListarParamConfirmacion";
    $.post(URL2, function (data) {
        $('#LoteEsquina').children('option:not(:first)').remove();
        $('#MonumentoHistorico').children('option:not(:first)').remove();
        $.each(data, function (i, obj) {
            $('#LoteEsquina').append($('<option>').text(obj.Text).attr('value', obj.Value));
            $('#MonumentoHistorico').append($('<option>').text(obj.Text).attr('value', obj.Value));
        });
    });
    var URL3 = ROOT + "Lotes/ListarTipoLote";
    $.post(URL3, function (data) {
        $('#TipoLote').children('option:not(:first)').remove();
        $.each(data, function (i, obj) {
            $('#TipoLote').append($('<option>').text(obj.Text).attr('value', obj.Value));
        });
    });

}


var ConfZonif = 0, ConfLicen = 0, ConfObras = 0, ConfDocum = 0, ConfObser = 0, ConfLinder = 0, ConfGeneral = 0;
function GrabarLote() {
    var mensaje = "¿Esta seguro de grabar los cambios?";
    

    
    $.post(ROOT + "Lotes/BuscarLoteSolicitud", {
        CodigoDistrito: $('#CodDist').val(), FiltrarCodigoLote: $('#CodLote').val(), FiltrarCodigoManzana: $('#CodManz').val(), FiltrarCodigoSector: $('#CodSect').val()
    }, function (response) {
        if (response.Lotes) {
            var solicitudes = "";
            (response.Lotes).forEach( function(item) {
                solicitudes = solicitudes + "," + item.CodigoNumeroSolicitud
            });
            mensaje = "¿Esta seguro de grabar los cambios se han encontrado la(s) siguiente(s) solicitud(es) abierta(s) " + solicitudes.substring(1) + "? Se recomienda realizar las coordinaciones correspondientes.";
        }
        bootbox.confirm({
            title: "Mensaje del Sistema", message: mensaje,
            buttons: { confirm: { label: '<i class="fa fa-check"></i> Grabar ', className: "btn btn-success" }, cancel: { label: '<i class="fa fa-times"></i> Cancelar' } },
            callback: function (result) {
                if (result) {

                    //var modelLinderos = GrabarLoteLinderos();
                    //if (!ValidarLoteObservacion()) {
                    if (!$('#LoteEsquina').val()) {
                        toastr.warning("Completar informacion de el tipo de lote en esquina", "Mensaje del Sistema", { "progressBar": true });
                    } else if (!$('#TipoLote').val()) {
                        toastr.warning("Completar informacion de el tipo de lote", "Mensaje del Sistema", { "progressBar": true });
                    } else if (!$('#MonumentoHistorico').val()) {
                        toastr.warning("Completar informacion del monumento historico ", "Mensaje del Sistema", { "progressBar": true });
                    } else if (ValidarTab2 !== 0) {
                        toastr.warning("Se han encontrado campos incompletos en los Linderos del Predio", "Mensaje del Sistema", { "progressBar": true });
                    //} else if (false) {
                    //    toastr.warning("Se han encontrado campos vacíos en la pestaña Observaciones", "Mensaje del Sistema", { "progressBar": true });
                    //    //} else if (!validDocRRPP) {
                    //} else if (false) {
                        //toastr.warning("Se han encontrado campos vacíos en la pestaña Documentación del Predio - Documentos RRPP", "Mensaje del Sistema", { "progressBar": true, "showDuration": "600" });
                    } else {
                        var modelLoteNormaUrbana = GrabarNormaUrbana();
                        var modelDocRRPP = GrabarCamposDocumentacion(1);
                        var modelDocum = GrabarCamposDocumentacion(2);
                        $.post(ROOT + "Lotes/Grabar", {
                            CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val()
                        , LoteUrbano: $('#LoteUrbano').val(), SubLoteUrbano: $('#SubLoteUrbano').val(), Denominacion: $('#Denominacion').val(), LoteEsquina: $('#LoteEsquina').val()
                        , TipoLote: $('#TipoLote').val(), MonumentoHistorico: $('#MonumentoHistorico').val()
                        , AreaTerrenoCampo: $('#AreaTerrenoCampo').val(), AreaTerrenoOficial: $('#AreaTerrenoOficial').val()
                        , CodigoFuente: $('#CodigoFuente').val(), AreaConstruidaTotal: $('#AreaConstruidaTotal').val()
                        , SectorCatastral: $('#SectorCatastral').val(), SubSectorCatastral: $('#SubSectorCatastral').val()
                        , SectorVecinal: $('#SectorVecinal').val(), SubSectorVecinal: $('#SubSectorVecinal').val()
                        , SectorPlaneamiento: $('#SectorPlaneamiento').val(), SubSectorPlaneamiento: $('#SubSectorPlaneamiento').val()
                        , SectorSeguridad: $('#SectorSeguridad').val(), SubSectorSeguridad: $('#SubSectorSeguridad').val()
                        , AlturaEdificacion: $('#AlturaEdificacion').val(), UsoPredio: $('#UsoPredio').val()
                        , NumeroResolucion: $('#NumeroResolucion').val(), FechaResolucion: $('#FechaResolucion').val(), Estatico: Estatico
                        }, function (response) {
                            if (response.success) {
                                //console.log('Grabado_LoteGeneral', response.success); 
                                ConfGeneral = 2; ConfGrab();
                            } else {
                                ConfGeneral = 1;
                            }

                        });
                        $.post(ROOT + "Lotes/GrabarLoteNormaUrbana", { model: modelLoteNormaUrbana }, function (response) {
                        //    RecuperarNormaUrbana();$('#LoteLinderos input').attr('disabled', 'disabled');$('#LoteLinderos select').attr('disabled', 'disabled');
                            if (response.success) {console.log('Grabado_NormaUrbana', response.success);ConfLinder = 2; ConfGrab();} else {ConfLinder = 1;}
                        });
                        $.post(ROOT + "Lotes/GrabarLoteObservacion", { model: GrabarLoteObservacion() }, function (response) {
                            if (response.success) {
                                //console.log('Grabado_LoteObservacion', response.success);
                                RecuperarLoteObservacion(Estatico);
                                ConfObser = 2; ConfGrab();
                            } else { ConfObser = 1; }
                        });

                        $.post(ROOT + "Lotes/GrabarLoteDocumento  ", { model: modelDocum }, function (response) {
                            if (response.success) {
                                //console.log('Grabado_DOCEXP', response.success);
                                RecuperarDocumentos(Estatico);
                                ConfDocum = 2; ConfGrab();
                            } else { ConfDocum = 1; }
                        });
                        $.post(ROOT + "Lotes/GrabarLoteObras", { model: GrabarObras() }, function (response) {
                            if (response.success) {
                                //console.log('Grabado_DocObras', response.success);
                                tablaObras.ajax.reload();
                                ConfObras = 2; ConfGrab();
                            } else { ConfObras = 1; }
                        });

                        $.post(ROOT + "Lotes/GrabarLoteLicencias", { model: GrabarLicencias() }, function (response) {
                            if (response.success) {
                                //console.log('Grabado_DocLicencias', response.success);
                                tablaLicencias.ajax.reload();
                                ConfLicen = 2; ConfGrab();
                            } else { ConfLicen = 1; }
                        });
                        if (GrabarZonifLote().length !== 0) {
                            //console.log('ZONIF', GrabarZonifLote());
                            $.post(ROOT + "Lotes/GrabarZonifLote", { model: GrabarZonifLote() }, function (response) {
                                if (response.success) { console.log('Grabado_ZonifLote', response.success); ConfZonif = 2; ConfGrab(); } else { ConfZonif = 1; }
                            });
                        } else {
                            ConfZonif = 2; ConfGrab();
                        }

                    }
                }
            }
        });

    });
    
    

    
}
function RecuperarLote(estatico) {
    $.post(ROOT + "Lotes/Recuperar", {
        CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(), Estatico: estatico
    }, function (response) {
        $('#Cuc').val(response.RegistrarLote.Cuc);
        $('#LoteUrbano').val(response.RegistrarLote.LoteUrbano);
        $('#SubLoteUrbano').val(response.RegistrarLote.SubLoteUrbano);
        $('#Denominacion').val(response.RegistrarLote.Denominacion);
        $('#LoteEsquina').val(response.RegistrarLote.LoteEsquina);
        $('#TipoLote').val(response.RegistrarLote.TipoLote);
        $('#MonumentoHistorico').val(response.RegistrarLote.MonumentoHistorico).trigger('change');
        
        $('#AreaTerrenoCampo').val(response.RegistrarLote.AreaTerrenoCampo); $('#AreaTerrenoOficial').val(response.RegistrarLote.AreaTerrenoOficial);
        $('#AreaConstruidaTotal').val(response.RegistrarLote.AreaConstruidaTotal); $('#CodigoFuente').val(response.RegistrarLote.CodigoFuente);
        $('#SectorVecinal').val(response.RegistrarLote.SectorVecinal); $('#SubSectorVecinal').val(response.RegistrarLote.SubSectorVecinal);
        $('#SectorPlaneamiento').val(response.RegistrarLote.SectorPlaneamiento); $('#SubSectorPlaneamiento').val(response.RegistrarLote.SubSectorPlaneamiento);
        $('#SectorSeguridad').val(response.RegistrarLote.AreaConstruidaTotal); $('#SubSectorSeguridad').val(response.RegistrarLote.CodigoFuente);
        $('#AlturaEdificacion').val(response.RegistrarLote.AlturaEdificacion); $('#UsoPredio').val(response.RegistrarLote.UsoPredio);
        $('#NumeroResolucion').val(response.RegistrarLote.NumeroResolucion); $('#FechaResolucion').val(response.RegistrarLote.FechaResolucion);
    });
    CargarImagen(estatico);
    //RecuperarLinderos();
    
    RecuperarNormaUrbana(estatico);
    RecuperarCampoZonificacion(estatico);
    tablaMunicipalAsignado.ajax.reload();
    tablaLinderos.ajax.reload();
    tablaRetiroMunicipal.ajax.reload();
    tablaObras.ajax.reload();
    tablaOtrosDocumentos.ajax.reload();
    tablaLicencias.ajax.reload();
    tablaInspecciones.ajax.reload();
    RecuperarDocumentoRRPP(estatico);
    RecuperarDocumentos(estatico);
    RecuperarLoteObservacion(estatico);
    CargarGaleriaImagenes();
    //CAMBIOS NUEVOS CATASTRO GJLR-INI
    tablaRetiroMunicipalNew.ajax.reload();
    tablaJardinAislamientoNew.ajax.reload();
    tablaAreaPublicaNew.ajax.reload();
    tablaAnchoViaNew.ajax.reload();
    tablaLoteReferenciaNew.ajax.reload();
    //CAMBIOS NUEVOS CATASTRO GJLR-FIN
}

function ActGrab() {
    //iniTab02 == 1 && 
    if (iniTab04 === 1 && iniTab06 === 1) {
        if (Consultas === 'False') {
            $('#GrabarGeneral').removeAttr('disabled');
        }
    }
}
function ConfGrab() {
    //console.log('ConfGrab', ConfZonif, ConfLicen, ConfObras, ConfDocum, ConfObser, ConfLinder, ConfGeneral)
    if (ConfZonif === 2 && ConfLicen === 2 && ConfObras === 2 && ConfDocum === 2 && ConfObser === 2 && ConfGeneral === 2) {
        toastr.success("Información del Lote Registrada Correctamente", "Mensaje del Sistema", { "progressBar": true });
        ConfZonif = 0; ConfLicen = 0; ConfObras = 0; ConfDocum = 0; ConfObser = 0; ConfLinder = 0; ConfGeneral = 0;
        
    } else if (ConfZonif !== 0 && ConfLicen !== 0 && ConfObras !== 0 && ConfDocum !== 0 && ConfObser !== 0 && ConfGeneral !== 0) {
        if (ConfGeneral === 1) { toastr.warning("Se detecto un problema al grabar la Información del Lote", "Mensaje del Sistema", { "progressBar": true }); }
        if (ConfLicen === 1) { toastr.warning("Se detecto un problema al grabar las Licencias de Funcionamiento", "Mensaje del Sistema", { "progressBar": true }); }
        if (ConfObras === 1) { toastr.warning("Se detecto un problema al grabar las Obras Privadas", "Mensaje del Sistema", { "progressBar": true }); }
        if (ConfDocum === 1) { toastr.warning("Se detecto un problema al grabar los Expedientes y Documentos Simples", "Mensaje del Sistema", { "progressBar": true }); }
        if (ConfZonif === 1) { toastr.warning("Se detecto un problema al grabar la Zonificación", "Mensaje del Sistema", { "progressBar": true }); }
        if (ConfObser === 1) { toastr.warning("Se detecto un problema al grabar las Observaciones", "Mensaje del Sistema", { "progressBar": true }); }
        //if (ConfLinder === 1) { toastr.warning("Se detecto un problema al grabar los Datos del Predio", "Mensaje del Sistema", { "progressBar": true }); }
        ConfZonif = 0; ConfLicen = 0; ConfObras = 0; ConfDocum = 0; ConfObser = 0; ConfLinder = 0; ConfGeneral = 0;
        
    }
    
}

function ActualizarIndex(objeto) {
    var indice = 0;
    objeto.each(function (index, item) {
        item.value = LeftZero((indice + 1), 5);
        if ($(item).closest("tr").attr('name') !== 'delete') indice++;
    });
}

function validarCamposBusqueda(codSol, numVal, tipDoc) {
    var validado = false;
    valiCodTip = $('[data-valmsg-for="FiltrarCodigoTipoSolicitud"]');
    valiTipDoc = $('[data-valmsg-for="FiltrarCodigoTipoDocumentoReg"]');
    valiNumSol = $('[data-valmsg-for="FiltrarNumeroSolicitud"]');

    tablaUnidadCatastral.rows().remove().draw(); tablaUnidadCatastralRef.rows().remove().draw();
    $('#tabLotes').hide();
    $('#btnNuevoLote').attr('disabled', 'disabled'); $('#GenFicha').attr('disabled', 'disabled');
    $('#GrabarGeneral').attr('disabled', 'disabled');

    if (!codSol) {
        valiCodTip.html('Seleccione el tipo de solicitud').addClass('field-validation-valid has-error');
        valiNumSol.html('').removeClass('field-validation-valid has-error');
        $('[data-valmsg-for="FiltrarCodigoTipoDocumentoReg"]').html('').removeClass('field-validation-valid has-error');
        $('#FiltrarCodigoTipoSolicitud').focus(); //$('#btnDerivar').attr('disabled', 'disabled');
    } else if (!tipDoc && codSol !== '010003') {
        valiCodTip.html('').removeClass('field-validation-valid has-error');
        valiNumSol.html('').removeClass('field-validation-valid has-error');
        $('[data-valmsg-for="FiltrarCodigoTipoDocumentoReg"]').html('Seleccione el tipo de documento').addClass('field-validation-valid has-error');
        $('#FiltrarCodigoTipoDocumentoReg').focus();
    } else if (numVal === '-' || !numVal) {
        valiCodTip.html('').removeClass('field-validation-valid has-error');
        valiNumSol.html('Ingrese un número de solicitud').addClass('field-validation-valid has-error');
        $('[data-valmsg-for="FiltrarCodigoTipoDocumentoReg"]').html('').removeClass('field-validation-valid has-error');
        $('#FiltrarNumeroSolicitud').focus(); //$('#btnDerivar').attr('disabled', 'disabled');
    } else {
        valiCodTip.html('').removeClass('field-validation-valid has-error');
        valiNumSol.html('').removeClass('field-validation-valid has-error');
        $('[data-valmsg-for="FiltrarCodigoTipoDocumentoReg"]').html('').removeClass('field-validation-valid has-error');
        validado = true;
    }
    return validado;
}

/*
|--------------------------------------------------------------------------
| FIN FUNCIONES
|--------------------------------------------------------------------------
*/