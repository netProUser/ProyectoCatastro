
$(".chosen-seleccionar").chosen({ width: "100%", placeholder_text_single: "Seleccione una opción" });


pickmeup('#docum_lote_fechadoc_00001', { format: 'd/m/Y' });

tablaObras = $("#tablaObras").DataTable({
    "ajax": {
        "url": ROOT + "Lotes/CargarLoteDocumentosObras", "type": "POST", "datatype": "json",
        "data": function (d) {
            d.CodigoDistrito = $('#CodDist').val(); d.CodigoSector = $('#CodSect').val(); d.CodigoManzana = $('#CodManz').val(); d.CodigoLote = $('#CodLote').val();
            d.Estatico = Estatico;
        }
    },
    "columns": [
        { "data": "Item", "className": "text-center" }, { "data": "NumeroLicencia", "className": "text-center" },
        { "data": "Solicitante", "className": "text-center" }, { "data": "Beneficiario", "className": "text-center" },
        { "data": "TipoObra"},        
        { "data": "FechaLicencia", "className": "text-center" }, { "data": "Codigo", "className": "hide_column" },
        {
            'render': function (data, type, full, meta) {
                return '<button data-toggle="tooltip" title="Ver" class="btn mr-1 text-center ' + deshabilitar + ' btn-default btn-xs glyphicon glyphicon-search" type="button" ></button>';
            }, "className": "text-center"
        },
    ],
    "language": { "lengthMenu": "", "info": "", "emptyTable": "" }, "processing": true, "serverSide": false, "paging": false,
});


tablaOtrosDocumentos = $("#tablaOtrosDocumentos").DataTable({
    "ajax": {
        "url": ROOT + "Lotes/CargarLoteOtrosDocumentos", "type": "POST", "datatype": "json",
        "data": function (d) {
            d.CodigoDistrito = $('#CodDist').val();
            d.CodigoSector = $('#CodSect').val();
            d.CodigoManzana = $('#CodManz').val();
            d.CodigoLote = $('#CodLote').val();
            d.Estatico = Estatico;
        }
    },
    "columns": [
        { "data": "Item", "className": "text-center" },
        { "data": "TipoDocumento", "className": "text-center" },
        { "data": "NroDocumenro", "className": "text-center" },
        { "data": "Observaciones", "className": "text-center" },
        { "data": "FechaDocumento", "className": "text-center" },
        { "data": "Correlativo", "className": "hide_column" },
        { "data": "PdfHabilitado", "className": "hide_column" },
        {
               'render': function (data, type, full, meta) {
                   var InhabilitarPDF = full.PdfHabilitado == "NO" ? "disabled" : "";
                   return '<button data-toggle="tooltip" title="Editar"  class="btn btn-sm btn-success mr-1 px-2 py-1 btnEditarOtrosDocumentos glyphicon glyphicon-edit" type="button" ></button>' +
                       '<button data-toggle="tooltip" title="Eliminar"  class="btn btn-sm btn-success mr-1 px-2 py-1 btnEliminarOtrosDocumentos glyphicon glyphicon-trash" type="button" ></button>' +
                       '<form class="form-cell" enctype="multipart/form-data" id="' + full.Correlativo + '"> <label id="otro_subir_' + full.Correlativo + '" class="btn btn-sm btn-success buttonup px-2 py-1 glyphicon glyphicon-folder-open"><input name="Archivo" id="otro_lote_archivo_' + full.Correlativo + '" class="form-control archivo_lote_otro" type="file" /></label> </form>' +
                       '<button data-toggle="tooltip" title="Ver PDF" ' + InhabilitarPDF + ' onclick="DescargarPdfOtrosDocumentos(\'' + full.Correlativo + '\')"  class="btn btn-sm btn-success mr-1 px-2 py-1 btnVerOtrosDocumentos glyphicon glyphicon-search" type="button" ></button>';
            }, "className": "text-center"
        },
    ],
    "language": { "lengthMenu": "", "info": "", "emptyTable": "" }, "processing": true, "serverSide": false, "paging": false,
});

$("#tablaOtrosDocumentos tbody").on('click', 'button.btnEliminarOtrosDocumentos', function (event) {
    var cell = this;
    var data = tablaOtrosDocumentos.row($(this).parents('tr')).data();
    var enlace = ROOT + 'Lotes/EliminarOtrosDocumentos';
    console.log('Data', data);
        bootbox.confirm({
            title: "Mensaje del Sistema", message: "¿Esta seguro de borrar el registro?",
            buttons: { confirm: { label: '<i class="fa fa-trash"></i> Eliminar ', className: "btn btn-danger" }, cancel: { label: '<i class="fa fa-times"></i> Cancelar' } },
            callback: function (result) {
                if (result) {
                    $.post(enlace,
                    {
                        CodigoDistrito: $('#CodDist').val(),
                        CodigoLote: $('#CodLote').val(),
                        CodigoManzana: $('#CodManz').val(),
                        CodigoSector: $('#CodSect').val(),
                        Correlativo: data.Correlativo,
                        Estatico: Estatico
                    }
                    , function (response) {
                        tablaOtrosDocumentos.ajax.reload();
                        RecuperarNormaUrbana();
                        toastr.success("Registro eliminado correctamente", "Mensaje del Sistema", { "progressBar": true });
                    });
                }
            }
        });
    
});


$("#tablaOtrosDocumentos tbody").on('click', 'button.btnEditarOtrosDocumentos', function (event) {
    var cell = this;
    var data = tablaOtrosDocumentos.row($(this).parents('tr')).data();
    var enlace = ROOT + 'Lotes/AgregarOtrosDocumentoAsignado';
    $.post(enlace,
        {
            CodigoDistrito: $('#CodDist').val(),
            CodigoLote: $('#CodLote').val(),
            CodigoManzana: $('#CodManz').val(), 
            CodigoSector: $('#CodSect').val(),
            NumeroLado: data.NumeroLado,
            Correlativo: data.Correlativo,
            Estatico: Estatico,
            NroItem: data.Item,
        }
        , function (response) {
            var id = "#modalRegistrarOtrosDocumentos"; $(id).modal().html(response);
        });
});

$("#modalRegistrarOtrosDocumentos").on('shown.bs.modal');


tablaLicencias = $("#tablaLicencias").DataTable({
    "ajax": {
        "url": ROOT + "Lotes/CargarLoteDocumentosLicencias", "type": "POST", "datatype": "json",
        "data": function (d) {d.CodigoDistrito = $('#CodDist').val();d.CodigoSector = $('#CodSect').val();d.CodigoManzana = $('#CodManz').val();d.CodigoLote = $('#CodLote').val();}
    },
    "columns": [
        { "data": "Item", "className": "text-center" }, { "data": "NumeroLicencia", "className": "text-center" },
        { "data": "Solicitante", "className": "text-center" }, { "data": "Beneficiario", "className": "text-center" },
        { "data": "Giros" },
        { "data": "FechaLicencia", "className": "text-center" },
        { "data": "Codigo", "className": "hide_column" },
        { "data": "CodGiro", "className": "hide_column" },
        {   'render': function (data, type, full, meta) {
            return '<button data-toggle="tooltip" title="Ver" class="btn mr-1 text-center ' + deshabilitar + ' btn-default btn-xs glyphicon glyphicon-search" type="button" ></button>';
            }, "className": "text-center"
        },
    ],
    "language": { "lengthMenu": "", "info": "", "emptyTable": "" }, "processing": true, "serverSide": false, "paging": false,
});
tablaInspecciones = $("#tablaInspecciones").DataTable({
    "ajax": {
        "url": ROOT + "Lotes/CargarLoteDocumentosInspecciones", "type": "POST", "datatype": "json",
        "data": function (d) {
            d.CodigoDistrito = $('#CodDist').val(); d.CodigoSector = $('#CodSect').val(); d.CodigoManzana = $('#CodManz').val(); d.CodigoLote = $('#CodLote').val();
            d.Estatico = Estatico;
        }
    },
    "columns": [
        { "data": "Item", "className": "text-center" }, { "data": "FechaInspeccion", "className": "text-center" },
        { "data": "CodigoUnidad", "className": "text-center" }, { "data": "InspectorResponsable"},
        { "data": "Inspectores" },
        { "data": "Observacion" }, { "data": "Codigo", "className": "hide_column" },
        {
            'render': function (data, type, full, meta) {
                return '<button data-toggle="tooltip" title="Ver" ' + deshabilitar + ' class="btn mr-1 text-center  btn-default btn-xs glyphicon glyphicon-search" type="button" ></button>';
            }, "className": "text-center"
        },
    ],
    "language": { "lengthMenu": "", "info": "", "emptyTable": "" }, "processing": true, "serverSide": false, "paging": false,
});
CargarTipoDocumento();


var CorrelativoItemLote = '';
var contLoteDocumRRPP = 1;var contIdLoteDocumRRPP = 1;var contLoteExpediente, contLoteIdExpediente, columnas, fieldset;
contLoteDocumRRPP = contIdLoteDocumRRPP = contLoteExpediente = contLoteIdExpediente = 1;
var lblTd = '<td class="pr-4">';

function CargarTipoDocumento(idlado,  valuelado) {
    //console.log(idlado, valuelado);
    CrearCombobox((idlado) ? idlado : '.tipodoc_lote_docum', ListVBTipoDocRRPP, valuelado)
}
function CrearCombobox(Combobox, data, valuelado) {
    
    $(Combobox).find('option:not(:first)').remove();
    var items = "<option value=''>Seleccione...</option>";
    var option = document.createElement('option'); option.text = 'Seleccione...';
    var option1 = '';
    document.querySelector(Combobox).appendChild(option, 0);
    $.each(data, function (i, item) {
        option1 = document.createElement('option'); option1.text = item.Text; option1.value = item.Value;
        document.querySelector(Combobox).appendChild(option1, (i + 1));
        items += "<option value='" + item.Value + "'>" + item.Text + "</option>";
    });
    //console.log('AD','|' + Combobox+ "|", data, valuelado, items);
    //$(Combobox).append(items)
    $(Combobox).val(valuelado);
    //$('.chosen-seleccionar').trigger("chosen:updated");
}

function CrearCamposDocumentacion(tipo, tabla, focus, datos, disabled, disabledtot, ultima) {
    if (!datos) {
        datos = {};
    }

    CorrelativoItemLote = '';

    var value_fecha = (datos.Fecha === undefined) ? "" : datos.Fecha;
    var value_detalle = (datos.Detalle === undefined) ? "" : datos.Detalle;
    var value_codigo = (datos.Codigo === undefined) ? "" : datos.Codigo;                    var value_numero = (datos.Numero === undefined) ? "" : datos.Numero;
    var value_solicitante = (datos.Solicitante === undefined) ? "" : datos.Solicitante;     var value_documento = (datos.Documento === undefined) ? "" : datos.Documento;
    var value_observacion = (datos.Detalle === undefined) ? "" : datos.Detalle;
    var value_correl = (datos.Correlativo === undefined) ? "" : datos.Correlativo;
    CorrelativoItemLote = value_correl;
    var value_flag = (datos.Flag === undefined) ? "" : datos.Flag;
    var value_ruta = (datos.Ruta === undefined) ? "" : datos.Ruta; var value_codsoli = (datos.CodSoli === undefined) ? "" : datos.CodSoli;
    var value_codigoDocumento = (datos.CodigoDocumento === undefined) ? "" : datos.CodigoDocumento;
    var value_partidaElectronica = (datos.PartidaElectronica === undefined) ? "" : datos.PartidaElectronica;
    var value_tomoFicha = (datos.TomoFicha === undefined) ? "" : datos.TomoFicha; var value_folio = (datos.Folio === undefined) ? "" : datos.Folio;
    var value_asiento = (datos.Asiento === undefined) ? "" : datos.Asiento;

    var classButton = ' btn-warning ';
    var value_disabled = ''
    if (disabled) {
        value_disabled = disabled;
        classButton = ' btn-success ';
    }
    //console.log('btn', classButton, disabled);

    if (!disabledtot) {
        disabledtot = '';
    }
    var numeroItem, idItem;
    if (tipo === 1) {
        contLoteDocumRRPP++; contIdLoteDocumRRPP++;
        numeroItem = LeftZero(contLoteDocumRRPP, 5);
        idItem = LeftZero(contIdLoteDocumRRPP, 5);
        fieldset = "docum";
        columnas = lblTd + '<input type="text" id="docum_lote_item_' + idItem + '"  disabled value="' + numeroItem + '" class="form-control item_lote_documr"></td>' +
                lblTd + '<select ' + disabledtot + ' ' + deshabilitar + ' id="docum_lote_tipodoc_' + idItem + '" class="form-control tipodoc_lote_docum"><option value="">- Seleccione -</option></select></td>' +
                lblTd + '<input ' + disabledtot + ' ' + deshabilitar + ' id="docum_lote_partida_' + idItem + '"  value="' + value_partidaElectronica + '" type="text" class="form-control partida_lote_documr"></td>' +
                lblTd + '<input ' + disabledtot + ' ' + deshabilitar + ' id="docum_lote_tomoficha_' + idItem + '" style="text-align:center;" value="' + value_tomoFicha + '" type="text" class="form-control tomoficha_lote_documr"></td>' +
                lblTd + '<input ' + disabledtot + ' ' + deshabilitar + ' id="docum_lote_folio_' + idItem + '" style="text-align:center;" value="' + value_folio + '" type="text" class="form-control folio_lote_documr"></td>' +
                lblTd + '<input ' + disabledtot + ' ' + deshabilitar + ' id="docum_lote_asiento_' + idItem + '" value="' + value_asiento + '" type="text" class="form-control asiento_lote_documr"></td>' +
                lblTd + '<input ' + disabledtot + ' ' + deshabilitar + ' id="docum_lote_fechadoc_' + idItem + '" maxlength="10" style="text-align:center;" value="' + value_fecha + '" type="text" class="form-control fechadoc_lote_documr"></td>' +
                '<td style="display:none;">' + '<input ' + deshabilitar + ' id="docum_lote_id_' + idItem + '" value="' + value_codigo + '" type="hidden" class="form-control id_lote_documr"></td>' +
                '<td style="display:none;">' + '<input ' + deshabilitar + ' id="docum_lote_ruta_' + idItem + '" value="' + value_ruta + '" type="hidden" class="form-control ruta_lote_documr"></td>';;
        
        if (ultima === true) {
            iniTab06 = 1;
            $("#tab-6").LoadingOverlay("hide");
            ActGrab();
        }

    } else {
        if (tipo === 2) {
            fieldset = "exped"; 
            contLoteExpediente++;
            contLoteIdExpediente++;
            numeroItem = LeftZero(contLoteExpediente, 5);
            idItem = LeftZero(contLoteIdExpediente, 5);
        }
        
        columnas = lblTd + '<input ' + deshabilitar + ' type="text" disabled value="' + numeroItem + '" class="form-control item_lote_' + fieldset + '"></td>' +
               lblTd + '<input ' + deshabilitar + ' disabled id="' + fieldset + '_lote_solici_' + idItem + '" value="' + value_solicitante + '" type="text" class="form-control solici_lote_' + fieldset + '"></td>' +
               lblTd + '<input ' + deshabilitar + ' disabled id="' + fieldset + '_lote_documento_' + idItem + '" value="' + value_documento + '" type="text" class="form-control documento_lote_' + fieldset + '"></td>' +
               lblTd + '<input ' + deshabilitar + ' disabled id="' + fieldset + '_lote_numero_' + idItem + '" value="' + value_numero + '" type="text" class="form-control numero_lote_' + fieldset + '"></td>' +
               lblTd + '<input ' + deshabilitar + ' disabled id="' + fieldset + '_lote_fecha_' + idItem + '" value="' + value_fecha + '" type="date" class="form-control fecha_lote_' + fieldset + '"></td>' +
               lblTd + '<input ' + deshabilitar + ' id="' + fieldset + '_lote_obser_' + idItem + '" value="' + value_detalle + '" autocomplete="off" type="text" class="form-control obser_lote_' + fieldset + '"></td>' +
               '<td style="display:none;">' + '<input id="' + fieldset + '_lote_id_' + idItem + '" value="' + value_codigo + '" type="hidden" class="id_lote_' + fieldset + '"></td>' +
               '<td style="display:none;">' + '<input id="' + fieldset + '_lote_correl_' + idItem + '" value="' + value_correl + '" type="hidden" class="correl_lote_' + fieldset + '"></td>' +
               '<td style="display:none;">' + '<input id="' + fieldset + '_lote_flag_' + idItem + '" value="' + value_flag + '" type="hidden" class="flag_lote_' + fieldset + '"></td>' +
               '<td style="display:none;">' + '<input id="' + fieldset + '_lote_codsoli_' + idItem + '" value="' + value_codsoli + '" type="hidden" class="codsoli_lote_' + fieldset + '"></td>';
    }
    $('#' + tabla + ' input').attr('disabled', 'disabled');
    $('#' + tabla + ' select').attr('disabled', 'disabled');
    $('.tipodoc_lote_docum').attr('disabled', 'disabled').trigger("chosen:updated");
            if (Consultas === 'False') {
                $('#' + tabla + ' input[type="file"]').removeAttr('disabled');
                $('input.obser_lote_exped').removeAttr('disabled');
            } else {
                $('input.obser_lote_exped').attr('disabled','disabled');
            }
            var botonesMant = (tipo === 1) ?
                    '<button ' + deshabilitar + ' onclick="CrearCamposDocumentacion(' + tipo + ',\'' + tabla + '\',\'' + focus + '\', \'\', \'' + disabled + '\' )"  class="btn btn-sm btn-success mr-2 px-2 py-1 glyphicon glyphicon-plus"></button>' +
                    '<button ' + deshabilitar + ' onclick="EditarCampoDocumentacion(' + tipo + ',\'' + tabla + '\',\'' + idItem + '\',\'' + focus + '\')" class="btn btn-sm btn-success mr-2 px-2 py-1 glyphicon glyphicon-edit"></button>' +
                    '<button ' + value_disabled + ' onclick="EliminarCampoDocumentacion(' + tipo + ',this, ' + idItem + ', \'item_lote_' + fieldset + '\')" class="btn btn-sm btn-success mr-2 px-2 py-1 glyphicon glyphicon-trash"></button>' +
                    '<form enctype="multipart/form-data" class="form-cell" id="formima_' + idItem + '"><label ' + deshabilitar + ' id="docum_subir_' + idItem + '" class="btn btn-sm ' + classButton + 'buttonup mr-2 px-2 py-1 glyphicon glyphicon-folder-open"> ' +
                        '<input ' + deshabilitar + ' name="Archivo" id="docum_lote_archivo_' + idItem + '" class="form-control archivo_lote_documr" type="file" />' +
                    '</label></form>' +
                    '<button ' + deshabilitar + ' id="docum_descargar_' + idItem + '" onclick="DescargarArchivo(\'' + idItem + '\')" class="btn btn-sm btn-success px-2 py-1 glyphicon glyphicon-search"></button></div></td></tr>' : '';
    var newTR = document.createElement('tr');
    newTR.style.height = "45px";
    newTR.innerHTML = columnas + '<td align="right"><div style="width:150px">' + botonesMant + ((tipo === 2) ? // '<button ' + deshabilitar + ' onclick="" class="btn btn-sm btn-success px-2 py-1 glyphicon glyphicon-search"></button>' : '') +
                                                                                                               '<button ' + deshabilitar + ' onclick="EliminarCampoDocumentacionExpediente(' + tipo + ', \'' + CorrelativoItemLote + '\',this, ' + idItem + ', \'item_lote_' + fieldset + '\')" class="btn btn-sm btn-success mr-2 px-2 py-1 glyphicon glyphicon-trash"></button>' : '') +
                                                                                                               '</div></td>';
    var cadena = '<tr style="height:45px">' + columnas + '<td align="right"><div style="width:150px">' +
                    botonesMant +
                    '<button ' + deshabilitar + ' onclick="" class="btn btn-sm btn-success px-2 py-1 glyphicon glyphicon-trash"></button></div></td></tr>';
    var table = document.getElementById(tabla);
    table.appendChild(newTR);
    if (tipo === 1) { 
        CargarTipoDocumento("#docum_lote_tipodoc_" + idItem, value_codigoDocumento);
    }
    //document.getElementById(tabla).innerHTML = cadena;

    if (tipo === 1) { 
        pickmeup('#docum_lote_fechadoc_' + idItem, { format: 'd/m/Y' });
        if (value_fecha) { 
            pickmeup('#docum_lote_fechadoc_' + idItem).set_date(value_fecha);
        }
    }
    //$('#' + focus + '_' + idItem).focus().select();
}

function EditarCampoDocumentacion(tipo, tabla, value, focus) {
    $('#' + tabla + ' input').attr('disabled', 'disabled');
    $('#' + tabla + ' select').attr('disabled', 'disabled');
    $('.tipodoc_lote_docum').attr('disabled', 'disabled').trigger("chosen:updated");
    if (tipo === 1) {
        $('#docum_lote_tipodoc_' + value).removeAttr('disabled').trigger("chosen:updated"); $('#docum_lote_partida_' + value).removeAttr('disabled');
        $('#docum_lote_tomoficha_' + value).removeAttr('disabled'); $('#docum_lote_folio_' + value).removeAttr('disabled');
        $('#docum_lote_asiento_' + value).removeAttr('disabled'); $('#docum_lote_fechadoc_' + value).removeAttr('disabled');
        $('#docum_lote_archivo_' + value).removeAttr('disabled');
        
    } else {
        $('#exped_lote_solici_' + value).removeAttr('disabled'); $('#exped_lote_documento_' + value).removeAttr('disabled');
        $('#exped_lote_numero_' + value).removeAttr('disabled'); $('#exped_lote_fecha_' + value).removeAttr('disabled');
        $('#exped_lote_obser_' + value).removeAttr('disabled');
    }
    $('#' + focus + '_' + value).focus().select();
}
function EliminarCampoDocumentacion(tipo, element, index, item) {
    if (index !== '00001') {
        if (tipo === 1) {
            contLoteDocumRRPP--;
        }
        else {
            contLoteExpediente--;
        }
        $(element).closest("tr").hide().attr('name', 'delete');
        var items = $('.' + item);
        ActualizarIndex(items);
    }
}

function EliminarCampoDocumentacionExpediente(tipo, CorrelativoItemLote, element, index, item) {
    var enlace = ROOT + 'Lotes/EliminarDocumentos';
    $.post(enlace,
        {
            CodigoDepartamento: "15",
            CodigoProvincia: "01",
            CodigoDistrito: $('#CodDist').val(),
            CodigoLote: $('#CodLote').val(),
            CodigoManzana: $('#CodManz').val(),
            CodigoSector: $('#CodSect').val(),
            CodigoCorrelativo: CorrelativoItemLote,
            Estatico: Estatico
        }
        , function (response) {
            RecuperarDocumentos(Estatico);
            toastr.success("Registro grabado correctamente", "Mensaje del Sistema", { "progressBar": true });
        });



}


function RecuperarDocumentoRRPP(estatico) {
    var URLDocumentoRRPP = ROOT + "Lotes/BuscarLoteDocumentosRRPP";
    $('#loteDocumRRPPPrimeraFila .docum_descargar').attr('disabled', 'disabled');
    $('#docum_subir_00001').addClass('btn-success').removeClass('btn-warning');
    $.post(URLDocumentoRRPP, {
        CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(), Estatico : Estatico
    }, function (r) {
        contLoteDocumRRPP = 1;contIdLoteDocumRRPP = 1;
        $('#DocumentosRrpp tr').each(function (index, item) {
            if (index === 0) return true;
            if (index === 1) {
                var id = '#loteDocumRRPPPrimeraFila'; $(id + ' .tipodoc_lote_docum').val(item.CodigoDocumento).attr('disabled', 'disabled');
                $(id + ' .partida_lote_documr').val(item.PartidaElectronica).attr('disabled', 'disabled'); $(id + ' .tomoficha_lote_documr').val(item.TomoFicha).attr('disabled', 'disabled');
                $(id + ' .folio_lote_documr').val(item.Folio).attr('disabled', 'disabled'); $(id + ' .asiento_lote_documr').val(item.Asiento).attr('disabled', 'disabled');
                $(id + ' .fechadoc_lote_documr').val(item.Fecha).attr('disabled', 'disabled'); $(id + ' .id_lote_documr').val(item.Codigo).attr('disabled', 'disabled');
                pickmeup('#docum_lote_fechadoc_00001').set_date(item.Fecha);
                $(id + ' .ruta_lote_documr').val("").attr('disabled', 'disabled');
                return true;
            }
            item.remove();
        });
        if (r.LoteObservacion.length === 0) {
            iniTab06 = 1;
            $("#tab-6").LoadingOverlay("hide");
            ActGrab();
        }
        $.each(r.LoteObservacion, function (index, item) {
            if (index === 0) {
                var id = '#loteDocumRRPPPrimeraFila'; $(id + ' .tipodoc_lote_docum').val(item.CodigoDocumento);
                $(id + ' .partida_lote_documr').val(item.PartidaElectronica);       $(id + ' .tomoficha_lote_documr').val(item.TomoFicha);
                $(id + ' .folio_lote_documr').val(item.Folio);                      $(id + ' .asiento_lote_documr').val(item.Asiento);
                $(id + ' .fechadoc_lote_documr').val(item.Fecha); $(id + ' .id_lote_documr').val(item.Codigo);
                
                $(id + ' .ruta_lote_documr').val(item.Ruta);
                if ((index + 1) === r.LoteObservacion.length) {
                    iniTab06 = 1;
                    $("#tab-6").LoadingOverlay("hide");
                    ActGrab();
                }
                if (item.Ruta) {
                    $(id + ' .docum_descargar').removeAttr('disabled');
                    $('#docum_subir_00001').removeClass('btn-success').addClass('btn-warning');
                }
            } else {
                var datos = {
                    'Fecha': item.Fecha, 'Detalle': item.Detalle, 'CodigoDocumento': item.CodigoDocumento, 'PartidaElectronica': item.PartidaElectronica,
                    'TomoFicha': item.TomoFicha, 'Folio': item.Folio, 'Asiento': item.Asiento, 'Codigo': item.Codigo, 'Ruta': item.Ruta
                };
                var disabled;
                if (!item.Ruta) {
                    disabled = 'disabled';
                }
                var ultima = false;
                if ((index + 1) === r.LoteObservacion.length) {
                    ultima = true;
                }
                CrearCamposDocumentacion(1, 'DocumentosRrpp', 'docum_lote_tipodoc', datos, disabled, 'disabled', ultima);
            }
        });
    });
}
function RecuperarDocumentos(estatico) {
    var URLDocumentos = ROOT + "Lotes/BuscarLoteDocumentos";
    $.post(URLDocumentos, {
        CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(), Estatico: Estatico
    }, function (r) {
        contLoteExpediente = 1; contLoteIdExpediente = 1;
        $('#ExpedientesDoc tr').each(function (index, item) {
            if (index === 0) return true;
            if (index === 1) {
                var id = '#loteDocumPrimeraFila';
                $(id + ' .solici_lote_exped').val("").attr('disabled', 'disabled');
                $(id + ' .documento_lote_exped').val("").attr('disabled', 'disabled');
                $(id + ' .numero_lote_exped').val("").attr('disabled', 'disabled');
                $(id + ' .fecha_lote_exped').val("").attr('disabled', 'disabled');
                //$(id + ' .obser_lote_exped').val("").attr('disabled', 'disabled');
                $(id + ' .id_lote_exped').val("").attr('disabled', 'disabled');
                $(id + ' .correl_lote_exped').val("").attr('disabled', 'disabled');
                $(id + ' .flag_lote_exped').val("").attr('disabled', 'disabled');
                $(id + ' .codsoli_lote_exped').val("").attr('disabled', 'disabled');
                return true;
            }
            item.remove();
        });
        $.each(r.LoteObservacion, function (index, item) {
            if (index === 0) {
                var id = '#loteDocumPrimeraFila';
                $(id + ' .solici_lote_exped').val(item.Solicitante);
                $(id + ' .documento_lote_exped').val(item.Documento);
                $(id + ' .numero_lote_exped').val(item.Numero);
                $(id + ' .obser_lote_exped').val(item.Detalle);
                $(id + ' .fecha_lote_exped').val(item.Fecha);
                $(id + ' .id_lote_exped').val(item.Codigo);
                $(id + ' .correl_lote_exped').val(item.Correlativo);
                $(id + ' .flag_lote_exped').val(item.Flag);
                $(id + ' .codsoli_lote_exped').val(item.CodSoli);
            } else {
                var datos = {
                    'Fecha': item.Fecha, 'Detalle': item.Detalle, 'Solicitante': item.Solicitante, 'CodSoli': item.CodSoli, 'Documento': item.Documento,
                    'Numero': item.Numero, 'Codigo': item.Codigo, 'Correlativo': item.Correlativo, 'Flag': item.Flag
                };
                CrearCamposDocumentacion(2, 'ExpedientesDoc', 'exped_lote_obser', datos);
            }
        });
    });
}

function GrabarLicencias() {
    var arrayObject = [];
    var tablaLicenciasTemp = tablaLicencias.data();
    $.each(tablaLicenciasTemp, function (index, Item) {
        arrayObject.push({
            "Solicitante": Item.Solicitante, "Beneficiario": Item.Beneficiario, "TipoLicencia": Item.TipoLicencia, "NumeroLicencia": Item.NumeroLicencia, "Giros": Item.Giros,
            "FechaLicencia": Item.FechaLicencia, "Codigo": Item.Codigo, "CodGiro": Item.CodGiro,
            CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(), Estatico: Estatico
        });
    });
    return arrayObject;
}
function GrabarObras() {
    var arrayObject = [];
    var tablaObrasTemp = tablaObras.data();
    $.each(tablaObrasTemp, function (index, Item) {
        arrayObject.push({
            "Solicitante": Item.Solicitante, "Beneficiario": Item.Beneficiario, "TipoObra": Item.TipoObra, "NumeroLicencia": Item.NumeroLicencia, 
            "FechaLicencia": Item.FechaLicencia, "Codigo": Item.Codigo, Estatico: Estatico,
            CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val()
        });
    });
    return arrayObject;
}

function DescargarArchivo(num_item) {
    window.open(ROOT + 'Lotes/DescargarLoteDocumentoRRPP?CodigoDistrito=' + $('#CodDist').val() + '&CodigoSector=' + $('#CodSect').val() + '&CodigoManzana=' + $('#CodManz').val() + '&CodigoLote=' + $('#CodLote').val() + '&Codigo=' + $('#docum_lote_id_' + num_item).val() + '&Estatico=' + Estatico);
    var modelDocum = {
        CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(), Codigo: $('#docum_lote_id_' + num_item).val()
    };
}

function DescargarPdfOtrosDocumentos(num_item) {
    console.log(num_item + "si llego");
    window.open(ROOT + 'Lotes/DescargarOtrosDocumento?CodigoDistrito=' + $('#CodDist').val() +
                                                        '&CodigoSector=' + $('#CodSect').val() +
                                                        '&CodigoManzana=' + $('#CodManz').val() +
                                                        '&CodigoLote=' + $('#CodLote').val() +
                                                        '&Correlativo=' + num_item +
                                                        '&Estatico=' + Estatico)
    ;
    var modelDocum = {
        CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(), Correlativo: num_item
    };
}

var validDocRRPP = false;
function GrabarCamposDocumentacion(tipoObjeto) {
    var datosParseados = [];
    var tablaDocumentos;
    var validado = 0;
    switch (tipoObjeto) {
        case 1: tablaDocumentos = $('#DocumentosRrpp tr'); break;
        case 2: tablaDocumentos = $('#ExpedientesDoc tr'); break;
    }
    if (tipoObjeto === 1) {
        console.log('TABLA', tablaDocumentos);
        var totalFilas = tablaDocumentos.length - 1;
        tablaDocumentos.each(function (index, item) {
            var del = '0';
            if (index === 0) return true;
            if ($(item).closest("tr").attr('name') === 'delete') del = '1';
            var ind, tipodoc, partida, tomoficha, folio, asiento, fechadoc, codigo, archivo;var num_item;
            $(item).children("td").each(function () {
                var input = $(this).children(".form-control");

                if (input.hasClass("tipodoc_lote_docum")) { tipodoc = input.val(); num_item = input.attr('id').substring(19,24); } else if (input.hasClass("partida_lote_documr")) { partida = input.val(); }
                else if (input.hasClass("tomoficha_lote_documr")) { tomoficha = input.val(); } else if (input.hasClass("folio_lote_documr")) { folio = input.val(); }
                else if (input.hasClass("asiento_lote_documr")) { asiento = input.val(); } else if (input.hasClass("fechadoc_lote_documr")) { fechadoc = input.val(); }
                else if (input.hasClass("id_lote_documr")) { codigo = input.val(); } else if (input.hasClass("item_lote_documr")) { ind = input.val(); }
            });
            if (!tipodoc || !partida || !tomoficha || !folio || !asiento || !fechadoc) {
                validado++;
            }
            archivo = $('#docum_lote_archivo_' + num_item)[0].files[0];
            
            var modelDocum = {
                "Codigo": codigo, "Estado": del, "CodigoDocumento": tipodoc, "PartidaElectronica": partida, "Item": ind, //"Archivo": archivo,
                "TomoFicha": tomoficha, "Folio": folio, "Asiento": asiento, "Fecha": fechadoc, CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(),
                "Estatico" : Estatico
            };
            console.log('DOCS', modelDocum);

            $('#DocumentosRrpp input').attr('disabled', 'disabled');
            $('#DocumentosRrpp select').attr('disabled', 'disabled');
            $('#DocumentosRrpp .archivo_lote_documr').removeAttr('disabled');
            //data.append(codigo, del, tipodoc, partida, ind, archivo, tomoficha, folio, asiento, fechadoc, $('#CodDist').val(), $('#CodLote').val(), $('#CodManz').val(), $('#CodSect').val());
            console.log("LoteDocumRRPP", modelDocum);
            $.post(ROOT + "Lotes/GrabarLoteDocumentoRRPP  ", {
                model: modelDocum
            }, function (response) {
                //SUBIR IMAGEN

                if (archivo) {
                    var form = $('#formima_' + num_item)[0];
                    var dataString = new FormData(form);
                    dataString.append('CodigoDistrito', $('#CodDist').val());
                    dataString.append('CodigoSector', $('#CodSect').val());
                    dataString.append('CodigoManzana', $('#CodManz').val());
                    dataString.append('CodigoLote', $('#CodLote').val());
                    dataString.append('Archivo', archivo);
                    dataString.append('Estatico', Estatico);
                    dataString.append('Codigo', response.responseText);
                    $('#docum_lote_id_' + num_item).val(response.responseText);
                    GrabarCamposDocumentacionImagen(dataString, num_item)
                }
                if (totalFilas === index) {
                    RecuperarDocumentoRRPP(Estatico);
                }
            });
        });
    } else {
        tablaDocumentos.each(function (index, item) {
            var del = '0';
            if (index === 0) return true;
            if ($(item).closest("tr").attr('name') === 'delete') del = '1';
            var ind, solicitante, documento, numero, fecha, observacion, correl, flag, codsoli;
            $(item).children("td").each(function () {
                var input = $(this).children("input");
                if (input.hasClass("solici_lote_exped")) { solicitante = input.val(); } else if (input.hasClass("documento_lote_exped")) { documento = input.val(); }
                else if (input.hasClass("numero_lote_exped")) { numero = input.val(); } else if (input.hasClass("fecha_lote_exped")) { fecha = input.val(); }
                else if (input.hasClass("obser_lote_exped")) { observacion = input.val(); } else if (input.hasClass("id_lote_exped")) { ind = input.val(); }
                else if (input.hasClass("correl_lote_exped")) { correl = input.val(); } else if (input.hasClass("flag_lote_exped")) { flag = input.val(); }
                else if (input.hasClass("codsoli_lote_exped")) { codsoli = input.val(); }
            });
            if (!solicitante || !documento || !numero || !fecha || !observacion) {
                validado++;
            }
            datosParseados.push({ "Codigo": ind, "Estado": del, "Solicitante": solicitante, "Correlativo": correl, "Flag": flag, "Documento": documento, "Numero": numero, "Fecha": fecha, "Detalle": observacion, CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(), CodSoli: codsoli, Estatico: Estatico });
        });

    }
    validDocRRPP = (validado === 0) ? true : false;
    return datosParseados;
}

$(document).on("change", 'input.archivo_lote_documr[type="file"]', function (evt) {
    if (evt.target.files.length === 0) {
        toastr.warning("Archivo deseleccionado", "Mensaje del Sistema", { "progressBar": true });
    } else {
        var num_item = evt.target.id.substring( evt.target.id.length - 5)
        var del = '0';
        
        var ind, tipodoc, partida, tomoficha, folio, asiento, fechadoc, codigo, archivo;
        
            

            tipodoc = $('#docum_lote_tipodoc_'+num_item).val(); 
            partida = $('#docum_lote_partida_'+num_item).val();tomoficha = $('#docum_lote_tomoficha_'+num_item).val(); folio = $('#docum_lote_folio_'+num_item).val(); 
            asiento = $('#docum_lote_asiento_'+num_item).val();fechadoc = $('#docum_lote_fechadoc_').val(); 
            codigo = $('#docum_lote_id_'+num_item).val();  $('#docum_lote_item_'+num_item).val(); 
        
        archivo = $('#docum_lote_archivo_' + num_item)[0].files[0];
        var modelDocum = {
            "Codigo": codigo, "Estado": del, "CodigoDocumento": tipodoc, "PartidaElectronica": partida, "Item": ind, //"Archivo": archivo,
            "TomoFicha": tomoficha, "Folio": folio, "Asiento": asiento, "Fecha": fechadoc, CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(),
            "Estatico": Estatico 
        };
        $('#DocumentosRrpp input').attr('disabled', 'disabled');
        $('#DocumentosRrpp select').attr('disabled', 'disabled');
        $('#DocumentosRrpp .archivo_lote_documr').removeAttr('disabled');
        //data.append(codigo, del, tipodoc, partida, ind, archivo, tomoficha, folio, asiento, fechadoc, $('#CodDist').val(), $('#CodLote').val(), $('#CodManz').val(), $('#CodSect').val());
        $.post(ROOT + "Lotes/GrabarLoteDocumentoRRPP  ", {
            model: modelDocum
        }, function (response) {
            //SUBIR IMAGEN
            if (response.success === true) {
                var correl = response.responseText;

                $('#docum_lote_id_' + num_item).val(correl);

                if (archivo) {
                    var form = $('#formima_' + num_item)[0];
                    var dataString = new FormData(form);
                    dataString.append('CodigoDistrito', $('#CodDist').val());
                    dataString.append('CodigoSector', $('#CodSect').val());
                    dataString.append('CodigoManzana', $('#CodManz').val());
                    dataString.append('CodigoLote', $('#CodLote').val());
                    dataString.append('Archivo', archivo);
                    dataString.append('Estatico', Estatico);
                    dataString.append('Codigo', response.responseText);
                    $('#docum_lote_id_' + num_item).val(response.responseText);
                    GrabarCamposDocumentacionImagen(dataString, num_item)
                }
            }

            


        });
    }
});

function GrabarCamposDocumentacionImagen(dataString, num_item, mensaje) {
    console.log("llego hasta el metodo"+dataString);
    $.ajax({
            url: ROOT + "Lotes/GrabarLoteDocumentoRRPPImagen",
            type: 'POST',
            dataType: 'json',
            data: dataString,
            cache: false,
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.success) {
                    
                    if (mensaje) {
                        toastr.success("Archivo agregado correctamente", "Mensaje del Sistema", { "progressBar": true });
                    }
                }
            }
        });
}

$(document).on("change", 'input.archivo_lote_otro[type="file"]', function (evt) {
    if (evt.target.files.length === 0) {
        toastr.warning("Archivo Seleccionado", "Mensaje del Sistema", { "progressBar": true });
    } else {
        var num_item = evt.target.id.substring(evt.target.id.length - 3)
        var nombrePDF = evt.target.files[0];
        codigo = num_item;
        var archivo = nombrePDF;



        var form = $('#formima_' + num_item)[0];
        var dataString = new FormData(form);
        dataString.append('Codigo', codigo);
        dataString.append('Archivo', nombrePDF);
        dataString.append('Correlativo', codigo);
        dataString.append('CodigoDistrito', $('#CodDist').val());
        dataString.append('CodigoLote', $('#CodLote').val());
        dataString.append('CodigoManzana', $('#CodManz').val());
        dataString.append('CodigoSector', $('#CodSect').val());
        dataString.append('Estatico', Estatico);

        $.ajax({
            url: ROOT + "Lotes/GrabarLoteOtroDocumentoRRPPImagen",
            type: 'POST',
            dataType: 'json',
            data: dataString,
            cache: false,
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.success) {
                    toastr.warning(response.responseText, "Mensaje del Sistema", { "progressBar": true, "showDuration": "600", });
                    tablaOtrosDocumentos.ajax.reload();
                } else {
                    toastr.success("Registro grabado correctamente el PDF", "Mensaje del Sistema", { "progressBar": true });
                    tablaOtrosDocumentos.ajax.reload();

                }
            }
        });

    }
});
