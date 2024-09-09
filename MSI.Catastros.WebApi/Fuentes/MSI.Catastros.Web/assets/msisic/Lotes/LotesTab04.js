
var contIdLoteZonificacion = 1, contLoteNorma = 0, carga1 = 0, carga2 = 0;



function CargarCodigoZonificacion(iditem, valor, ultima) {
    var URLZonificacion = ROOT + "Lotes/ListarZonificacion";
   
    
        $.post(URLZonificacion,{CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val()},  function (data) {
            $((iditem) ? '#lotezon_cod_' + iditem : '.lotezon_cod').children('option:not(:first)').remove();
            $.each(data, function (i, obj) {
                $((iditem) ? '#lotezon_cod_' + iditem : '.lotezon_cod').append($('<option>').text(obj.Text).attr('value', obj.Value));
            });
            if (valor) {
                $((iditem) ? '#lotezon_cod_' + iditem : '.lotezon_cod').val(valor);
                CargarDescripcionZonificacion($((iditem) ? '#lotezon_cod_' + iditem : '.lotezon_cod'), ultima);
            }
        });
    
}

function CargarCodigoZonificacion2(iditem, valor,ultima) {
    var URLZonificacion = ROOT + "Lotes/ListarZonificacion2";
    
        $.post(URLZonificacion, { CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val() }, function (data) {
            $((iditem) ? '#lotezon_des_' + iditem : '.lotezon_desc').children('option:not(:first)').remove();
            listZonif2 = data;
            $.each(data, function (i, obj) {
                $((iditem) ? '#lotezon_des_' + iditem : '.lotezon_desc').append($('<option>').text(obj.Text).attr('value', obj.Value));
            });
            if (valor) {
                $((iditem) ? '#lotezon_des_' + iditem : '.lotezon_desc').val(valor);
            }
            if (ultima === true) {
                carga1 = 1;
                CargaT4();
            }
        });
    
}
function CambiarDescripcion(element) {
    var codigo = $(element).val();
    var id = $(element).attr('id');
    var num_item = id.substring(12, 17);
    var cont = 0;
    $(".lotezon_cod").each(function (index) {
        if (this.value === codigo) {
            cont++;
            console.log('a1', this.value, codigo);
            if (cont > 0) {
                toastr.error("El código seleccionado ya ha sido asignado", "Mensaje del Sistema", { "progressBar": true });
                $(element).val('')
                $('#lotezon_cod_' + num_item).val('');
                return;
            }
        }
    });
    if (cont === 0) { 
        $('#lotezon_cod_' + num_item).val(codigo);
    }
}
function CargarDescripcionZonificacion(element, ultima) {

    var codigo = $(element).val()
    var cont = 0;
    $(".lotezon_cod").each(function (index) {
        if (this.value === codigo) {
            cont++;
            console.log('a1', this.value, codigo);
            if (cont > 1) { 
                toastr.error("El código seleccionado ya ha sido asignado", "Mensaje del Sistema", { "progressBar": true });
                $(element).val('')
                return;
            }
        }
    });
    
    
    var id = $(element).attr('id');
    var num_item = id.substring(12, 17);
    var URLRecupZonificacion = ROOT + "Lotes/RecuperarZonificacion";
    if (!$('#lotezon_cod_' + num_item).val()) {
        $('#lotezon_des_' + num_item).val("");
    }
    CargarCodigoZonificacion2(num_item, $('#lotezon_cod_' + num_item).val(),ultima);
    //$('#lotezon_des_' + num_item).val(data);
    //if (ultima === true) {
    //    carga1 = 1;
    //    CargaT4();
    //}
}

function CrearCamposZonificacion(codigo, disabled, ultima) {
    var value_codigo = (codigo === undefined) ? "" : codigo;
    contIdLoteZonificacion++;
    var idItem = LeftZero(contIdLoteZonificacion, 5);
    if (!disabled) {
        disabled = '';
    }
    $('#Zonificacion')
        .append('<tr style="height:45px">' +
                '<td class="pr-4"><select ' + disabled + ' id="lotezon_cod_' + idItem + '" onchange="CargarDescripcionZonificacion(this)" class="form-control lotezon_cod"><option value=""> - Seleccione - </option></select></td>' +
                '<td class="pr-4"><select ' + disabled + ' id="lotezon_des_' + idItem + '" onchange="CambiarDescripcion(this);" class="form-control lotezon_desc"><option value=""> - Seleccione la zonificación - </option></select>' +
                '<td>' +
                    '<button onclick="CrearCamposZonificacion()"  class="btn btn-sm btn-success mr-2 px-2 py-1 glyphicon glyphicon-plus"></button>' +
                    '<button onclick="EditarCampoZonificacion(\'' + idItem + '\')" class="btn btn-sm btn-success mr-2 px-2 py-1 glyphicon glyphicon-edit"></button>' +
                    '<button onclick="EliminarCampoZonificacion(this, ' + idItem + ')" class="btn btn-sm btn-success px-2 py-1 glyphicon glyphicon-trash"></button>' +
                '</td>' +
            '</tr>');
    CargarCodigoZonificacion(idItem, codigo, ultima);
    CargarCodigoZonificacion2(idItem, codigo, ultima);
    $('#lotezon_cod_' + idItem).focus().select();
}
function EditarCampoZonificacion(value) {
    $('#Zonificacion input').attr('disabled', 'disabled'); $('#lotezon_cod_' + value).removeAttr('disabled'); $('#lotezon_des_' + value).removeAttr('disabled');
    //$('#lotezon_des_' + value).removeAttr('disabled');
    $('#lotezon_cod_' + value).focus();
}
function EliminarCampoZonificacion(element, index) {
    if (index !== '00001') {
        $(element).closest("tr").hide().attr('name', 'delete');
        var items = $('.lotezon_cod');
    }
}
function RecuperarCampoZonificacion(estatico) {
    var URLObservacion = ROOT + "Lotes/BuscarLoteZonificacion";
    $.post(URLObservacion, { CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(), Estatico: estatico},
    function (r) {
        contIdLoteZonificacion = 1;
        $('#Zonificacion tr').each(function (index, item) {
            if (index === 0) return true;
            if (index === 1) {
                var id = '#lotePrimeraFilaZon'; 
                $(id + ' .lotezon_desc').val("").attr('disabled', 'disabled'); $(id + ' .lotezon_cod').val("").attr('disabled', 'disabled');
                return true;
            }
            item.remove();
        });
        if (r.LoteZonificacion.length === 0) {
            CargarCodigoZonificacion();
            CargarCodigoZonificacion2();
            carga1 = 1;
            CargaT4();
        }
        $.each(r.LoteZonificacion, function (index, item) {
            if (index === 0) {
                var id = '#lotePrimeraFilaZon';
                if ((index + 1) === r.LoteZonificacion.length) {
                    CargarCodigoZonificacion('00001', item.Codigo, true);
                } else {
                    CargarCodigoZonificacion('00001', item.Codigo, false);
                }
            } else {
                var ultima = false;
                if ((index + 1) === r.LoteZonificacion.length) {
                    ultima = true;
                }
                CrearCamposZonificacion(item.Codigo, 'disabled', ultima);
            }
        });
    });
}
function GrabarZonifLote() {
    var arrayObject = [];
    $('#Zonificacion tr').each(function (index, item) {
        var del = '0';
        if (index === 0) return true;
        if ($(item).closest("tr").attr('name') === 'delete') del = '1';
        var codigo;
        $(item).children("td").each(function () {
            var input = $(this).children();
            if (input.hasClass("lotezon_cod")) { codigo = input.val(); }
        });
        console.log('ADDZONIF',codigo);
        if (codigo) {
            arrayObject.push({ "Codigo": codigo, "Estado": del, CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(), Estatico: Estatico });
        }
    });
    return arrayObject;
}


//Norma Urbana
function CrearNormaUrbana(Altura, Observacion, Via, ultima,ListZonif,ListAltura, ZonifVia, AlturaVia,Codvia, Codmanzanavia) {
    var value_altura = (!Altura) ? "0" : Altura; var value_observacion = (!Observacion) ? "" : Observacion; var value_via = (!Via) ? "" : Via;
    var value_Codvia = (!Codvia) ? "" : Codvia; var value_Codmanzanavia = (!Codmanzanavia) ? "" : Codmanzanavia;
    contLoteNorma++;
    var idItem = LeftZero(contLoteNorma, 5);
    //$('#LoteNormatividad input').attr('disabled', 'disabled');
    $('#LoteNormatividad')
        .append('<div class="row form-group divrow">' +
                '<div><input id="norm_lote_codvia_' + idItem + '" value="' + value_Codvia + '" type="hidden" class="norm_lote_codvia"></div>' +
                '<div><input id="norm_lote_codmanzanavia_' + idItem + '" value="' + value_Codmanzanavia + '" type="hidden" class="norm_lote_codmanzanavia"></div>' +
                '<div class="col-md-4"><input id="norm_lote_via_' + idItem + '" type="text" disabled value="' + value_via + '" class="form-control norm_lote_via"></div>' +
                '<div class="col-md-3"><select id="norm_lote_zonif_' + idItem + '"  multiple="multiple" class="form-control norm_lote_zonif"></select></div>' +
                '<div class="col-md-3"><select id="norm_lote_altura_' + idItem + '" multiple="multiple" class="form-control norm_lote_altura"></select></div>' +
            '</div>');
    if (Consultas != 'False') { 
        $('#LoteNormatividad input').attr('disabled', 'disabled');
        $('#LoteNormatividad select').attr('disabled', 'disabled');
    }
    $('#norm_lote_observacion_' + idItem).val(value_observacion);
    CrearSelectMultiple("#norm_lote_zonif_" + idItem, ListZonif, ZonifVia, 1);
    CrearSelectMultiple("#norm_lote_altura_" + idItem, ListAltura, AlturaVia, 2);
    if (ultima === true) {
        carga2 = 1;
        CargaT4();
    }
}
function CrearSelectMultiple(Combobox, data, valuelado,tipo) {
    $(Combobox).find('option:not(:first)').remove();
    var items = "";
    var option = document.createElement('option'); option.text = 'Seleccione...';
    var option1 = '';
    //document.querySelector(Combobox).appendChild(option, 0);
    $.each(data, function (i, item) {
        option1 = document.createElement('option'); option1.text = item.Text; option1.value = item.Value;
        document.querySelector(Combobox).appendChild(option1, (i + 1));
        items += "<option value='" + item.Value + "'>" + item.Text + "</option>";
    });
    var valueSel = (valuelado) ? valuelado.split(",") : "";
    $(Combobox).multiselect({
        buttonWidth: '100%',
        allSelectedText: (tipo == 1) ? "Todas las zonificaciones" : "Todas las alturas",
        buttonClass: 'btn btn-default btn-sm',
        nonSelectedText: (tipo == 1) ? 'Seleccione las zonificaciones' : 'Seleccione las alturas',
    });
    console.log('ALT', valueSel);
    $(Combobox).multiselect('select', valueSel);
}
function RecuperarNormaUrbana(estatico) {
    var URLNormaUrbana = ROOT + "Lotes/ListarNormaUrbana";
    $.post(URLNormaUrbana, {
        CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(), Estatico : estatico
    }, function (data) {
        $('#LoteNormatividad').empty();
        if (data.length === 0) {
            carga2 = 1;
            CargaT4();
        }
        $.each(data, function (i, obj) {
            var ultima = false;
            if ((i + 1) === data.length) {
                ultima = true;
            }
            console.log('Crear', obj);
            CrearNormaUrbana(obj.Altura, obj.Observacion, obj.Via, ultima, obj.ListZonificacion, obj.ListAltura, obj.ZonificacionVia, obj.AlturaVia, obj.CodVia, obj.CodManzanaVia);
        });
        
    });
}
function GrabarNormaUrbana() {
    var arrayObject = [];
    $('#LoteNormatividad .divrow').each(function (e) {
        console.log($('.norm_lote_via').val());
        arrayObject.push({
            "CodVia": $(this).find('.norm_lote_codvia').val(), "CodManzanaVia": $(this).find('.norm_lote_codmanzanavia').val(),
            "CodigoSector": $('#CodSect').val(), "CodigoManzana": $('#CodManz').val(), "CodigoLote": $('#CodLote').val(),
            "AlturaVia": ($(this).find('.norm_lote_altura').val()) ? $(this).find('.norm_lote_altura').val().toString() : "",
            "ZonificacionVia": ($(this).find('.norm_lote_zonif').val()) ? $(this).find('.norm_lote_zonif').val().toString() : "", Estatico: Estatico
        });
        
    });
    return arrayObject;
}

function CargaT4() {
    //console.log('CARGA', carga1, carga2);
    if (carga1 === 1 && carga2 === 1) {
        carga1 = 0; carga2 = 0;
        iniTab04 = 1;
        ActGrab();
    }

    
}


