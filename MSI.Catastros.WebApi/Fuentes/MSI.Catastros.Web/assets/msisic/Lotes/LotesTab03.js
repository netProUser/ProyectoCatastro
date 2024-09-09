
tablaMunicipalAsignado = $("#tablaMunicipalAsignado").DataTable({
    "ajax": {
        "url": ROOT + "Lotes/CargarDirecMunicipal",
        "type": "POST",
        "datatype": "json",
        "data": function (d) {
            d.CodigoDistrito = $('#CodDist').val();
            d.CodigoSector = $('#CodSect').val();
            d.CodigoManzana = $('#CodManz').val();
            d.CodigoLote = $('#CodLote').val();
            d.Estatico = Estatico;
        }
    },
    "columns": [
        {
            'render': function (data, type, full, meta) {
                return '<button data-toggle="tooltip" ' + deshabilitar + ' title="Editar" class="btn mr-1 text-center btnEditMunicipal btn-default btn-xs glyphicon glyphicon-edit" type="button" ></button>' +
                '<button data-toggle="tooltip" ' + deshabilitar + ' title="Eliminar" class="btn mr-1 text-center btnDeleteMunicipal btn-default btn-xs glyphicon glyphicon-trash" type="button" ></button>';
            }, "className": "text-center"
        },
        { "data": "Item", "name": "Item", "className": "text-center" },
        //CAMBIOS NUEVOS CATASTRO GJLR-INI
        { "data": "CodigoVia_Unidad", "name": "CodigoVia_Unidad", "className": "text-center" },
        //CAMBIOS NUEVOS CATASTRO GJLR-FIN
        { "data": "NombreVia", "name": "NombreVia", "className": "text-center" },
        { "data": "NumeroCuadra", "name": "NumeroCuadra", "autoWidth": true, "className": "text-center" },
        { "data": "NombreLado", "name": "NombreLado", "autoWidth": true, "className": "text-center" },
        { "data": "NombreTipoEdificacion", "name": "TipoEdificacionNombreTipoEdificacion", "autoWidth": true, "className": "text-center" },
        //CAMBIOS NUEVOS CATASTRO GJLR-INI
        //SE COMENTO ORIGINAL
        //{ "data": "NumTipoEdificacion", "name": "NumTipoEdificacion", "className": "text-center" },
        //CAMBIOS NUEVOS CATASTRO GJLR-FIN
        { "data": "NombreTipoPuerta", "name": "NombreTipoPuerta", "autoWidth": true, "className": "text-center" },
        { "data": "NumeroPuerta", "name": "NumeroPuerta", "autoWidth": true, "className": "text-center" },
         //CAMBIOS NUEVOS CATASTRO GJLR-INI
        { "data": "NumeroMunicipal", "name": "NumeroMunicipal", "autoWidth": true, "className": "text-center" },
         //CAMBIOS NUEVOS CATASTRO GJLR-FIN
        { "data": "LetraPuerta", "name": "LetraPuerta", "autoWidth": true, "className": "text-center" },
        //CAMBIOS NUEVOS CATASTRO GJLR-INI
        { "data": "ExManzana", "name": "ExManzana", "autoWidth": true, "className": "text-center" },
        { "data": "ExLote", "name": "ExLote", "autoWidth": true, "className": "text-center" },
        { "data": "SubLote", "name": "SubLote", "autoWidth": true, "className": "text-center" },
        //CAMBIOS NUEVOS CATASTRO GJLR-FIN
        { "data": "Codigo", "name": "Codigo", "autoWidth": true, "className": "hide_column" },
        { "data": "CodigoManzanaVia", "name": "Codigo", "autoWidth": true, "className": "hide_column" },
        { "data": "CodigoVia", "name": "Codigo", "autoWidth": true, "className": "hide_column" },
        //CAMBIOS NUEVOS CATASTRO GJLR-INI
        //Se cambio de posicion a la columna
        { "data": "NombreAsignacion", "name": "NombreAsignacion", "className": "text-center" }
        //CAMBIOS NUEVOS CATASTRO GJLR-FIN
    ],
    "language": { "lengthMenu": "", "info": "", "emptyTable": "" },
    "processing": true,
    "serverSide": false,
    "paging": false,
});

$("#tablaMunicipalAsignado tbody").on('click', 'button.btnEditMunicipal', function (event) {
    var cell = this;
    var data = tablaMunicipalAsignado.row($(this).parents('tr')).data();
    var enlace = ROOT + 'Lotes/AgregarMunicipalAsignado';
    $.post(enlace,
        {
            CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(),
            Codigo: data.Codigo, CodigoVia: data.CodigoVia, CodigoManzanaVia: data.CodigoManzanaVia, Estatico: Estatico
        }
        , function (response) {
            var id = "#modalRegistrarDirecMunicipal";$(id).modal().html(response);
    });
});
$("#tablaMunicipalAsignado tbody").on('click', 'button.btnDeleteMunicipal', function (event) {
    var cell = this;
    var data = tablaMunicipalAsignado.row($(this).parents('tr')).data();
    var CodigoTipoSolicitud = $('#CodigoTipSol').val();
    var NumeroSolicitud = $('#CodigoNumSol').val();
    var CodigoPeriodo = $('#Periodo').val()
    var CodigoCorrel = data.CodigoCorrelativo;
    var enlace = ROOT + 'Lotes/EliminarMunicipalAsignado';
    bootbox.confirm({
        title: "Mensaje del Sistema", message: "¿Esta seguro de borrar el registro?",
        buttons: { confirm: { label: '<i class="fa fa-trash"></i> Eliminar ', className: "btn btn-danger" },cancel: { label: '<i class="fa fa-times"></i> Cancelar' } },
        callback: function (result) {
            if (result) {
                $.post(enlace,
                {
                    CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(),
                    Codigo: data.Codigo, CodigoVia: data.CodigoVia, CodigoManzanaVia: data.CodigoManzanaVia, Estatico: Estatico
                }
                , function (response) {
                    tablaMunicipalAsignado.ajax.reload();
                });
            }
        }
    });
    
});
$("#modalRegistrarDirecMunicipal").on('hidden.bs.modal', function () {
    $('#btnAgregarDirecMun').focus()
});
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//CAMBIOS NUEVOS CATASTRO GJLR-INI
tablaLoteReferenciaNew = $("#tablaLoteReferenciaNew").DataTable({
    "ajax": {
        "url": ROOT + "Lotes/CargarDirecMunicipal",
        "type": "POST",
        "datatype": "json",
        "data": function (d) {
            d.CodigoDistrito = $('#CodDist').val();
            d.CodigoSector = $('#CodSect').val();
            d.CodigoManzana = $('#CodManz').val();
            d.CodigoLote = $('#CodLote').val();
            d.Estatico = Estatico;
        }
    },
    "columns": [
        {
            'render': function (data, type, full, meta) {
                return '<button data-toggle="tooltip" ' + deshabilitar + ' title="Editar" class="btn mr-1 text-center btnEditMunicipal btn-default btn-xs glyphicon glyphicon-edit" type="button" ></button>' +
                '<button data-toggle="tooltip" ' + deshabilitar + ' title="Eliminar" class="btn mr-1 text-center btnDeleteMunicipal btn-default btn-xs glyphicon glyphicon-trash" type="button" ></button>';
            }, "className": "text-center"
        },
        { "data": "Item", "name": "Item", "className": "text-center" },
        { "data": "NombreLado", "name": "NombreLado", "autoWidth": true, "className": "text-center" },
        { "data": "CodigoVia", "name": "CodigoVia", "className": "text-center" },
        { "data": "NombreVia", "name": "NombreVia", "className": "text-center" },
        { "data": "NumeroMunicipal", "name": "NumeroMunicipal", "autoWidth": true, "className": "text-center" }
    ],
    "language": { "lengthMenu": "", "info": "", "emptyTable": "" },
    "processing": true,
    "serverSide": false,
    "paging": false,
});

$("#tablaLoteReferenciaNew tbody").on('click', 'button.btnEditMunicipal', function (event) {
    var cell = this;
    var data = tablaLoteReferenciaNew.row($(this).parents('tr')).data();
    var enlace = ROOT + 'Lotes/AgregarMunicipalAsignado';
    $.post(enlace,
        {
            CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(),
            Codigo: data.Codigo, CodigoVia: data.CodigoVia, CodigoManzanaVia: data.CodigoManzanaVia, Estatico: Estatico
        }
        , function (response) {
            var id = "#modalRegistrarLoteReferenciaNew"; $(id).modal().html(response);
        });
});
$("#tablaLoteReferenciaNew tbody").on('click', 'button.btnDeleteMunicipal', function (event) {
    var cell = this;
    var data = tablaLoteReferenciaNew.row($(this).parents('tr')).data();
    var CodigoTipoSolicitud = $('#CodigoTipSol').val();
    var NumeroSolicitud = $('#CodigoNumSol').val();
    var CodigoPeriodo = $('#Periodo').val()
    var CodigoCorrel = data.CodigoCorrelativo;
    var enlace = ROOT + 'Lotes/EliminarMunicipalAsignado';
    bootbox.confirm({
        title: "Mensaje del Sistema", message: "¿Esta seguro de borrar el registro?",
        buttons: { confirm: { label: '<i class="fa fa-trash"></i> Eliminar ', className: "btn btn-danger" }, cancel: { label: '<i class="fa fa-times"></i> Cancelar' } },
        callback: function (result) {
            if (result) {
                $.post(enlace,
                {
                    CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(),
                    Codigo: data.Codigo, CodigoVia: data.CodigoVia, CodigoManzanaVia: data.CodigoManzanaVia, Estatico: Estatico
                }
                , function (response) {
                    tablaLoteReferenciaNew.ajax.reload();
                });
            }
        }
    });

});
$("#modalRegistrarLoteReferenciaNew").on('hidden.bs.modal', function () {
    $('#btnAgregarDirecMun').focus()
});
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////