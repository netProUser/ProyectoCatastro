
var contLoteObservacion = 1;
var contLoteIdObservacion = 1;

pickmeup('#obs_lote_fecha_00001', { format: 'd/m/Y' });

function CrearLoteObservacion(fecha, detalle, codigo, ultima) {
    var value_fecha = (fecha === undefined) ? "" : fecha; var value_detalle = (!detalle) ? "" : detalle; var value_codigo = (codigo === undefined) ? "" : codigo;
    contLoteObservacion++; contLoteIdObservacion++;
    var numeroItem = LeftZero(contLoteObservacion, 5); var idItem = LeftZero(contLoteIdObservacion, 5);
    //console.log(value_detalle);
    $('#LoteObservacion input').attr('disabled', 'disabled');
    $('#LoteObservacion textarea').attr('disabled', 'disabled');
    $('#LoteObservacion')
        .append('<tr style="height:45px">' +
                '<td valign="top" class="pr-4"><input id="obs_lote_' + idItem + '" type="text" disabled value="' + numeroItem + '" class="form-control mt-3 text-center px-1 text-center item_lote_obser"></td>' +
                '<td valign="top" class="pr-4"><input id="obs_lote_fecha_' + idItem + '" value="' + value_fecha + '"  type="text" maxlength="10" class="form-control mt-3 text-center fecha_lote_obser"></td>' +
                '<td style="padding-right: 1.5rem !important;"><textarea id="obs_lote_observacion_' + idItem + '" value="' + value_detalle + '" style=""  class="form-control mt-3 obser_lote_obser" rows="3" ></textarea>' +
                    '' +
                '</td>' +
                '<td style="display:none;"><input id="obs_lote_id_' + idItem + '" value="' + value_codigo + '" type="hidden" class="id_lote_obser"></td>' +
                '<td valign="top" width="100px">' +
                    '<div class="mt-3"><button ' + deshabilitar + ' onclick="CrearLoteObservacion()"  class="btn btn-sm btn-success mr-2 px-2 py-1 glyphicon glyphicon-plus"></button>' +
                    '<button ' + deshabilitar + ' onclick="EditarLoteObservacion(\'' + idItem + '\')" class="btn btn-sm btn-success mr-2 px-2 py-1 glyphicon glyphicon-edit"></button>' +
                    '<button ' + deshabilitar + ' onclick="EliminarLoteObservacion(this, ' + idItem + ')" class="btn btn-sm btn-success px-2 py-1 glyphicon glyphicon-trash"></button></div>' +
                '</td>' +
            '</tr>');
    pickmeup('#obs_lote_fecha_' + idItem, { format: 'd/m/Y' });
    if (value_fecha) {
        pickmeup('#obs_lote_fecha_' + idItem).set_date(value_fecha);
    }

    $('#obs_lote_fecha_' + idItem).focus();
    $('#obs_lote_observacion_' + idItem).val(value_detalle);
    if (ultima) {
        $('#obs_lote_fecha_' + idItem).attr('disabled', 'disabled');
        $('#obs_lote_observacion_' + idItem).attr('disabled', 'disabled');
    }
}
function EditarLoteObservacion(value) {
    $('#LoteObservacion input').attr('disabled', 'disabled'); $('#LoteObservacion textarea').attr('disabled', 'disabled');

    $('#obs_lote_fecha_' + value).removeAttr('disabled');$('#obs_lote_observacion_' + value).removeAttr('disabled'); $('#obs_lote_fecha_' + value).focus();
}
function EliminarLoteObservacion(element, index) {
    if (index !== '00001') {
        contLoteObservacion--; $(element).closest("tr").hide().attr('name', 'delete');
        var items = $('.item_lote_obser'); ActualizarIndex(items);
    }
}
function RecuperarLoteObservacion(estatico) {
    var URLObservacion = ROOT + "Lotes/BuscarLoteObservacion";
    $.post(URLObservacion, {
        CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(), Estatico: estatico
    }, function (r) {
        contLoteObservacion = 1; contLoteIdObservacion = 1;
        $('#LoteObservacion tr').each(function (index, item) {
            if (index === 0) return true;
            if (index === 1) {
                var id = '#lotePrimeraFila'; $(id + ' .fecha_lote_obser').attr('disabled', 'disabled');
                $(id + ' .obser_lote_obser').attr('disabled', 'disabled'); $(id + ' .id_lote_obser').attr('disabled', 'disabled');
                return true;
            }
            item.remove();
        });
        $.each(r.LoteObservacion, function (index, item) {
            
            //contLoteObservacion++; contIdLoteObservacion++;
            if (index === 0) {
                var id = '#lotePrimeraFila'; $(id + ' .fecha_lote_obser').val(item.Fecha);
                pickmeup('#obs_lote_fecha_00001').set_date(item.Fecha);
                $(id + ' .obser_lote_obser').val(item.Detalle); $(id + ' .id_lote_obser').val(item.Codigo);
            } else {
                var ultima = false;
                if ((index + 1) == r.LoteObservacion.length) { ultima = true; }
                CrearLoteObservacion(item.Fecha, item.Detalle, item.Codigo, ultima);
            }
        });
    });
}

function GrabarLoteObservacion() {
    var arrayObject = []; 
    $('#LoteObservacion tr').each(function (index, item) {
        var del = '0';
        if (index === 0) return true;
        if ($(item).closest("tr").attr('name') === 'delete') del = '1';
        var fecha, ind, obser;
        $(item).children("td").each(function () {
            var input = $(this).children();
            if (input.hasClass("fecha_lote_obser")) { fecha = input.val(); }
            else if (input.hasClass("id_lote_obser")) { ind = input.val(); }
            else if (input.hasClass("obser_lote_obser")) { obser = input.val(); }
        });
        $('#LoteObservacion input').attr('disabled', 'disabled');
        $('#LoteObservacion textarea').attr('disabled', 'disabled');
        arrayObject.push({ "Codigo": ind, "Estado": del, "Fecha": fecha, "Detalle": obser, CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(), Estatico: Estatico });
    });
    return arrayObject;
}
function ValidarLoteObservacion() {
    var validado = 0;
    $('#LoteObservacion tr').each(function (index, item) {
        if (index === 0) return true;
        var fecha, ind, obser;
        $(item).children("td").each(function () {
            var input = $(this).children("input");
            
            if (input.hasClass("fecha_lote_obser")) { fecha = input.val(); }
            else if (input.hasClass("id_lote_obser")) { ind = input.val(); }
            else if (input.hasClass("obser_lote_obser")) { obser = input.val(); }
        });
        if (!fecha || !obser) {
            validado++;
        }
    });
    //return (validado === 0) ? true : false;
    return true;
}