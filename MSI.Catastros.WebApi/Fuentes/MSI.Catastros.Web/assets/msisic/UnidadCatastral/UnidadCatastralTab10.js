//quinta
var tipoColTemp, contIdLoteLindero = 4;

CargarLados(true);
var URLFuente = ROOT + "BienComun/ListarFuente";

$.post(URLFuente, function (data) {
    $('#CodigoFuente').children('option:not(:first)').remove();
    $.each(data, function (i, obj) {
        $('#CodigoFuente').append($('<option>').text(obj.Text).attr('value', obj.Value));
    });
});
$(document).on('focus', '.tipoColindante', function (e) {
    tipoColTemp = $(this).val();
});
$('#LoteLinderos input').attr('disabled', 'disabled'); $('#LoteLinderos select').attr('disabled', 'disabled');



function CargarLados(firstTime, idlado, idtipocol, valuelado, valuetipcol, valuecolin, ultima) {
    var URLLadoColindante = ROOT + "BienComun/ListarLadoLindero";
    var URLLadoColindante2 = "@Url.Content(" + URLLadoColindante + ")";
    $.post(URLLadoColindante, function (data) {
        $((idlado) ? idlado : '.ladoColindante').children('option:not(:first)').remove();
        $.each(data, function (i, obj) { $((idlado) ? idlado : '.ladoColindante').append($('<option>').text(obj.Text).attr('value', obj.Value)); });
        if (valuelado) { $((idlado) ? idlado : '.ladoColindante').val(valuelado); }
        $('#filaFrente .ladoColindante').val('03'); $('#filaFondo .ladoColindante').val('05'); $('#filaDerecha .ladoColindante').val('06'); $('#filaIzquierda .ladoColindante').val('04');
    });
    // var URLTipoColindante = "/BienComun/ListarTipoColindante";
    var URLTipoColindante = ROOT + "BienComun/ListarTipoColindante";

    $.post(URLTipoColindante, function (data) {
        if (!firstTime) { $((idtipocol) ? idtipocol : '.tipoColindante').children('option:not(:first)').remove(); }
        $.each(data, function (i, obj) { $((idtipocol) ? idtipocol : '.tipoColindante').append($('<option>').text(obj.Text).attr('value', obj.Value)); });
        //alert('AB', valuetipcol, valuecolin, ultima);
        if (valuetipcol) {
            $(idtipocol).val(valuetipcol);
            if (valuecolin) {
                CargarColindante($(idtipocol), valuecolin, ultima);
            } else {
                if (ultima === true) {
                    iniTab02 = 1; $("#tab-2").LoadingOverlay("hide");
                    //ActGrab();
                }
            }
        }
        //if (ultima === true) { iniTab02 = 1; $("#tab-2").LoadingOverlay("hide"); ActGrab(); }
        //if (valuetipcol) {
        //    $(idtipocol).val(valuetipcol);
        //    if (valuecolin) {
        //        CargarColindante($(idtipocol), valuecolin, ultima);

        //    }
        //}
    });
}
function CargarColindante(element, valor, ultima) {
    var codigo = $(element).val();
    var id = $(element).attr('id');
    var num_item = id.substring(15, 20);
    var URLColindante;
    var ubi = null;
    //var codigo = $(element).val(); var id = $(element).attr('id'); var num_item = id.substring(15, 20); var URLColindante; var ubi = null;
    if (ValidarColindante($('#lindero_colin_' + num_item).val(), num_item, 1) || !$('#lindero_colin_' + num_item).val()) {
        if (codigo === '010001') {
            URLColindante = ROOT + "BienComun/ListarColindante";
        }
        else if (codigo === '010003') {
            var ubi = '010031';
            URLColindante = ROOT + "BienComun/ListarColindante";
        }
        else if (codigo === '010002') {
            URLColindante = ROOT + "BienComun/ListarColindanteLote";
        }
        else if (codigo === '010004') {
            URLColindante = ROOT + "BienComun/ListarColindanteEdificacion";
        }
        else if (codigo === '010005') {
            URLColindante = ROOT + "BienComun/ListarColindanteUnidad";
        }
        if (URLColindante) {
            $('#lindero_colin_' + num_item).children('option:not(:first)').remove();
            if (valor) {
                $('#lindero_colin2_' + num_item).children('option:not(:first)').remove();
            }
            $.post(URLColindante, {
                CodigoDistrito: $('#CodigoDistrito').val(),
                CodigoLote: $('#CodigoLote').val(),
                CodigoManzana: $('#CodigoManzana').val(),
                CodigoSector: $('#CodigoSector').val(),
                Ed: $('#CodigoEdificacion').val(),
                Entrada: $("#CodigoEntrada").val(),
                Piso: $("#CodigoPiso").val(),
                Unidad: $("#CodigoUnidad").val(),
                Ubicacion: ubi
            }, function (data) {
                $.each(data, function (i, obj) {
                    $('#lindero_colin_' + num_item).append($('<option>').text(obj.Text).attr('value', obj.Value));
                    if (valor) {
                        $('#lindero_colin2_' + num_item).append($('<option>').text(obj.Text).attr('value', obj.Value));
                    }
                });
                if (valor) {
                    $('#lindero_colin_' + num_item).val(valor);
                    $('#lindero_colin2_' + num_item).val(valor);
                }
                if (ultima === true) {
                    iniTab02 = 1; $("#tab-2").LoadingOverlay("hide");
                    //ActGrab();
                }
                //if (valor) {
                //    $('#lindero_colin_' + num_item).val(valor);
                //    $('#lindero_colin2_' + num_item).val(valor);

                //}
            });
        } else {
            if (ultima === true) {
                iniTab02 = 1; $("#tab-2").LoadingOverlay("hide");
                //ActGrab();
            }
        }
    } else {
        $('#lindero_tipcol_' + num_item).val(tipoColTemp);
        if (ultima === true) {
            iniTab02 = 1; $("#tab-2").LoadingOverlay("hide");
            //ActGrab();
        }
        //$('#lindero_tipcol_' + num_item).val(tipoColTemp);
        //if (ultima === true) {
        //    iniTab02 = 1; $("#tab-2").LoadingOverlay("hide"); ActGrab();
        //}
    }
}
function CargarFuente(item, valor) {
    var num_item = item; var URLFuenteColin = ROOT +  "BienComun/ListarFuentesColin";
    $.post(URLFuenteColin, function (data) {
        $('#lindero_fuente_' + num_item).children('option:not(:first)').remove();
        $.each(data, function (i, obj) { $('#lindero_fuente_' + num_item).append($('<option>').text(obj.Text).attr('value', obj.Value)); });
        if (valor) { $('#lindero_fuente_' + num_item).val(valor); }
    });
}
function CrearLoteLinderos(lado, datos, tipofila, numlado, disabled, ultima) {
    var value_lado = (lado === undefined) ? "" : lado; var value_numlado = (numlado === undefined) ? "" : numlado;
    var value_medofi = '', value_medcam = '', value_tipcol = '', value_colin = '', value_fuente = '', value_codigo = '';
    if (datos) {
        value_medofi = (datos.MedidaLadoOfi === undefined) ? "" : datos.MedidaLadoOfi;
        value_medcam = (datos.MedidaLadoCam === undefined) ? "" : datos.MedidaLadoCam;
        value_tipcol = (datos.CodigoTipoColind === undefined) ? "" : datos.CodigoTipoColind;
        value_colin = (datos.CodigoColindante === undefined) ? "" : datos.CodigoColindante;
        //value_fuente = (datos.CodigoFuente === undefined) ? "" : datos.CodigoFuente;
        value_codigo = (datos.Codigo === undefined) ? "" : datos.Codigo;
    }

    contIdLoteLindero++; var idItem = LeftZero(contIdLoteLindero, 5);
    if (!disabled) { disabled = ''; }
    var idfila;
    switch (lado) {
        case '03': idfila = 'filaFrente'; break;
        case '04': idfila = 'filaIzquierda'; break;
        case '05': idfila = 'filaFondo'; break;
        case '06': idfila = 'filaDerecha'; break;
    }
    var act = ''; if (tipofila) { act = ' name="' + tipofila + '"'; }
    $('#LoteLinderos input').attr('disabled', 'disabled'); $('#LoteLinderos select').attr('disabled', 'disabled');
    var Fila = '<tr class="' + idfila + '" ' + act + ' style="height:40px">' +
               '<td class="pr-4"><select ' + disabled + ' id="lindero_lado_' + idItem + '"  class="form-control lindero_lado ladoColindante" disabled ><option value="">- Seleccione -</option></select></td>' +
               '<td class="pr-4"><input ' + disabled + ' id="lindero_numlado_' + idItem + '" value="' + value_numlado + '" type="text" disabled class="form-control text-center lindero_numlado" /></td>' +
               '<td class="pr-4"><input ' + disabled + ' id="lindero_medcam_' + idItem + '" value="' + value_medcam + '" type="text" class="form-control lindero_medcam numerotab2 text-right" /></td>' +
               '<td class="pr-4"><input ' + disabled + ' id="lindero_medofi_' + idItem + '" value="' + value_medofi + '" type="text" class="form-control lindero_medofi numerotab2 text-right" /></td>' +
              // '<td class="pr-4"><select ' + disabled + ' id="lindero_fuente_' + idItem + '" class="form-control lindero_fuente"><option value=""> - Seleccione - </option></select></td>' +
               '<td class="pr-4"><select ' + disabled + ' id="lindero_tipcol_' + idItem + '" onchange="CargarColindante(this)" class="form-control lindero_tipcol tipoColindante"><option value="">- Seleccione -</option></td>' +
               '<td class="pr-4"><select ' + disabled + ' id="lindero_colin_' + idItem + '" onchange="ActualizarCodigo(this)" class="form-control lindero_colin"><option value=""> - Seleccione el colindante - </option></select></td>' +
               '<td style="display:none;"><select style="display:none;" id="lindero_colin2_' + idItem + '" class="form-control lindero_colin2"><option value=""> - Seleccione el colindante - </option></select></td>' +
               '<td style="display:none;"><input id="lindero_correl_' + idItem + '" value="' + value_codigo + '" type="hidden" class="lindero_correl" /></td>' +
               '<td>' +
                   '<button data-toggle="tooltip"' + deshabilitar + ' title="Editar" onclick="EditarLoteLinderos(\'' + idItem + '\')" class="btn btn-sm btn-success mr-2 px-2 py-1 glyphicon glyphicon-edit"></button>' +
                   '<button data-toggle="tooltip"' + deshabilitar + ' title="Eliminar" onclick="EliminarLoteLindero(this, \'' + idItem + '\')" class="btn btn-sm btn-success px-2 py-1 glyphicon glyphicon-trash"></button>' +
               '</td>' +
               '</tr>';
    $(Fila).insertAfter('tr.' + idfila + ':last'); $('#lindero_medcam_' + idItem).number(true, 2, '.', ''); $('#lindero_medofi_' + idItem).number(true, 2, '.', '');
    if (value_numlado) { numerolado = value_numlado; } else { numerolado = ContadorLoteLinderos(value_lado); }
    $('#lindero_numlado_' + idItem).val(numerolado);
    CargarLados(false, "#lindero_lado_" + idItem, "#lindero_tipcol_" + idItem, value_lado, value_tipcol, value_colin, ultima);
    CargarFuente(idItem, value_fuente);
    $('#lindero_medcam_' + idItem).focus().select();
}
function EditarLoteLinderos(value) {
    $('#LoteLinderos input').attr('disabled', 'disabled'); $('#LoteLinderos select').attr('disabled', 'disabled');
    $('#lindero_medofi_' + value).removeAttr('disabled');
    // $('#lindero_fuente_' + value).removeAttr('disabled');
    $('#lindero_medcam_' + value).removeAttr('disabled'); $('#lindero_tipcol_' + value).removeAttr('disabled'); $('#lindero_colin_' + value).removeAttr('disabled');
    if (Number(value) <= 0) {
        $('#lindero_medcam_' + value).focus().select();
    } else { $('#lindero_medcam_' + value).focus().select(); }
}
function ActualizarCodigo(element) {
    var id = element.id;
    var num_item = id.substring(14, 19);
    var valor = $('#lindero_colin2_' + num_item).val();
    if (!valor) {
        $('#lindero_colin2_' + num_item).val(element.value);
    } else { ValidarColindante(valor, num_item, 1) }
}
function ValidarColindante(valor, num_item, tipo) {
    var tablaMunicipalTemp = tablaMunicipalAsignado.data();
    var contador = 0;
    if ($('#lindero_correl_' + num_item).val()) {
        $.each(tablaMunicipalTemp, function (index, Item) {
            if (valor === Item.CodigoManzanaVia + '-' + Item.CodigoVia) {
                if (tipo === 1) {
                    $('#lindero_colin_' + num_item).val(valor);
                    toastr.warning("No puede modificar esta Vía porque esta siendo utilizada en Ubicación y/o Entradas", "Mensaje del Sistema", { "progressBar": true });
                }
                else { toastr.warning("No puede eliminar esta Vía porque esta siendo utilizada en Ubicación y/o Entradas", "Mensaje del Sistema", { "progressBar": true }); }

                contador++;
                return false;
            }
        });
        /* var tablaRetiroTemp = tablaRetiroMunicipal.data();
         $.each(tablaRetiroTemp, function (index, Item) {
             if (valor === Item.CodigoManzanaVia + '-' + Item.CodigoVia) {
                 if (tipo === 1) {
                     $('#lindero_colin_' + num_item).val(valor);
                     toastr.warning("No puede modificar esta Vía porque esta siendo utilizada en Retiro Municipal", "Mensaje del Sistema", { "progressBar": true });
                 }
                 else { toastr.warning("No puede eliminar esta Vía porque esta siendo utilizada en Retiro Municipal", "Mensaje del Sistema", { "progressBar": true }); }
                 contador++;
                 return false;
             }
         });*/
    }
    return (contador === 0) ? true : false;
}
function EliminarLoteLindero(element, index) {
    if (Number(index) > 0) {
        if (ValidarColindante($('#lindero_colin_' + index).val(), index, 2)) {
            $(element).closest("tr").hide().attr('name', 'delete');
        }
    }
}
function GrabarLoteLinderos() {
    var arrayObject = [];
    ValidarTab2 = 0;
    $('#LoteLinderos tr').each(function (index, item) {
        var del = '0';
        if (index === 0) return true;
        if ($(item).closest("tr").attr('name') === 'delete') { del = '3'; }
        else if ($(item).closest("tr").attr('name') === 'update') { del = '2'; }
        else { del = '1'; }
        var lado, numlado, medofi, medcam, tipcol, colin, colin2, fuente, correl;
        $(item).children("td").each(function (index) {
            var input = $(this).children();
            if (input.hasClass("lindero_lado")) { lado = input.val(); }
            else if (input.hasClass("lindero_numlado")) { numlado = input.val(); }
            else if (input.hasClass("lindero_medofi")) { medofi = input.val(); }
            else if (input.hasClass("lindero_medcam")) { medcam = input.val(); }
            else if (input.hasClass("lindero_fuente")) { fuente = input.val(); }
            else if (input.hasClass("lindero_tipcol")) { tipcol = input.val(); }
            else if (input.hasClass("lindero_colin")) { colin = input.val(); }
            else if (input.hasClass("lindero_colin2")) { colin2 = input.val(); }
            else if (input.hasClass("lindero_correl")) { correl = input.val(); }
        });
        //console.log('VALID', medofi, medcam, fuente, tipcol, colin);
        if ((medofi != 0 || medofi) && (medcam != 0 || medcam) && fuente && tipcol && colin) {
            //console.log('VAL1');
            //No se detectan errores la fila a sido completada correctamente
        } else if ((medofi == 0 || !medofi) && (medcam == 0 || !medcam) && !fuente && !tipcol && !colin) {
            //console.log('VAL2');
            //No se detectan errores la fila es nula
        } else if (!tipcol || !colin || !fuente || (medcam == 0 || !medcam) || (medofi == 0 || !medofi)) {
            ValidarTab2++;
        }
        arrayObject.push({
            "Codigo": correl, "Estado": del, "CodigoLado": lado, "NumeroLado": numlado, "MedidaLadoOfi": medofi, "MedidaLadoCam": medcam,
            "CodigoTipoColind": tipcol, "CodigoColindante": colin, "CodigoViaAnterior": colin2,
            "CODUNI": $('#CodigoUnidadCatastral').val(), "Estatico": Estatico
        });
    });
    return arrayObject;
}
function ContadorLoteLinderos(valor) {
    var arrayObject = [];
    var contador = 1;
    $('#LoteLinderos tr').each(function (index, item) {
        if (index === 0) return true;
        if ($(item).closest("tr").attr('name') === 'delete') return true;
        var lado;
        $(item).children("td").each(function () {
            var input = $(this).children();
            if (input.hasClass("lindero_lado")) { lado = input.val(); }
        });
        if (lado === valor) {
            contador++;
        }
    });
    return LeftZero(contador, 4);
}
function RecuperarLinderos() {
    $.ajax({
        type: "POST", url: ROOT + "UnidadCatastral/BuscarLoteLinderos",
        // data: {CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val()},
        data: {
            codUniCat: $('#CodigoUnidadCatastral').val(),
            Estatico: Estatico
        },
        dataType: "json",
        success: function (r) {
            delaySuccess(r);

        },
    })
}
function delaySuccess(r) {
    $('#LoteLinderos tr').each(function (index, item) {
        if (index === 0)
            return true;
        if (item.id === 'filaFrente' || item.id === 'filaIzquierda' || item.id === 'filaFondo' || item.id === 'filaDerecha') {
            $(item).attr('name', '');
            $('#' + item.id + ' .lindero_numlado').attr('disabled', 'disabled');
            $('#' + item.id + ' .lindero_medofi').val("").attr('disabled', 'disabled').attr('name', ''); $('#' + item.id + ' .lindero_medcam').val("").attr('disabled', 'disabled');
            $('#' + item.id + ' .lindero_tipcol').val("").attr('disabled', 'disabled').attr('name', '');
            $('#' + item.id + ' .lindero_tipcol').val("").attr('disabled', 'disabled');
            // $('#' + item.id + ' .lindero_fuente').val("").attr('disabled', 'disabled').attr('name', '');
            $('#' + item.id + ' .lindero_colin').val("").attr('disabled', 'disabled'); $('#' + item.id + ' .lindero_colin2').val("");
        } else {
            item.remove();
        }
    });
    //contIdLoteLindero = 0;
    contfre = false; contizq = false; contfon = false; contder = false; indice = 1;
    var numfre = 0, numizq = 0, numfon = 0, numder = 0; CrearLoteFijo = false;
    if (!r.LoteObservacion || r.LoteObservacion.length === 0) {
        iniTab02 = 1; $("#tab-2").LoadingOverlay("hide");
        //ActGrab();
        // CargarFuente('00001'); CargarFuente('00002'); CargarFuente('00003'); CargarFuente('00004');
    }
    $.each(r.LoteObservacion, function (index, item) {
        if (item.CodigoLado === '03') {
            CrearLoteFijo = (contfre) ? false : true; numfre++;
        }
        if (item.CodigoLado === '04') {
            CrearLoteFijo = (contizq) ? false : true; numizq++;
        }
        if (item.CodigoLado === '05') {
            CrearLoteFijo = (contfon) ? false : true; numfon++;
        }
        if (item.CodigoLado === '06') {
            CrearLoteFijo = (contder) ? false : true; numder++;
        }
        if (CrearLoteFijo) {
            var idfila;
            switch (item.CodigoLado) {
                case '03': idfila = '#filaFrente'; contfre = true; break;
                case '04': idfila = '#filaIzquierda'; contizq = true; break;
                case '05': idfila = '#filaFondo'; contfon = true; break;
                case '06': idfila = '#filaDerecha'; contder = true; break;
            }
            $(idfila + ' .ladoColindante').val(item.CodigoLado);
            $(idfila + ' .lindero_numlado').val(item.Codigo);
            $(idfila + ' .lindero_medofi').val(item.MedidaLadoOfi);
            $(idfila + ' .lindero_medcam').val(item.MedidaLadoCam);
            $(idfila + ' .lindero_tipcol').val(item.CodigoTipoColind);
            $(idfila + ' .lindero_tipcol').val(item.CodigoTipoColind);
            var ultima = false;
            if ((index + 1) == r.LoteObservacion.length) {
                ultima = true;
            }
            //if ((index + 1) == r.LoteObservacion.length || r.LoteObservacion[(index + 1)].CodigoTipoColind === null) { ultima = true; }
            CargarColindante($(idfila + ' .lindero_tipcol'), item.CodigoColindante, ultima);
            //  CargarFuente(LeftZero(indice, 5), item.CodigoFuente);
            $(idfila).attr('name', 'update')
            indice++;
        } else {
            var medida = 0;
            if (item.CodigoLado === '03') medida = LeftZero(numfre, 4);
            if (item.CodigoLado === '04') medida = LeftZero(numizq, 4);
            if (item.CodigoLado === '05') medida = LeftZero(numfon, 4);
            if (item.CodigoLado === '06') medida = LeftZero(numder, 4);
            var ultima = false;
            if ((index + 1) == r.LoteObservacion.length) { ultima = true; }
            var datos = {
                'Codigo': item.Codigo, 'MedidaLadoOfi': item.MedidaLadoOfi, 'MedidaLadoCam': item.MedidaLadoCam, 'CodigoTipoColind': item.CodigoTipoColind,
                'CodigoColindante': item.CodigoColindante
            };
            CrearLoteLinderos(item.CodigoLado, datos, 'update', medida, 'disabled', ultima)
        }

    });


}