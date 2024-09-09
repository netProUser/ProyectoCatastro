tablaRetiroMunicipal = $("#tablaRetiroMunicipal").DataTable({
    "ajax": {
        "url": ROOT + "Lotes/CargarRetiroMunicipal",
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
        { "data": "NombreVia", "name": "NombreVia", "className": "text-center" },
        { "data": "NumeroCuadra", "name": "NumeroCuadra",  "className": "text-center" },
        { "data": "NombreLado", "name": "NombreLado", "className": "text-center" },
        { "data": "RetiroOficial", render: function (data, type, full) { return (full.RetiroOficial) ? parseFloat(data).toFixed(4) : "0.0000"; }, "name": "RetiroOficial", "className": "text-center" },
        { "data": "RetiroCampo", render: function (data, type, full) { return (full.RetiroCampo) ? parseFloat(data).toFixed(4) : "0.0000"; }, "name": "RetiroCampo", "className": "text-center" },
        { "data": "OcupacionRetiro", "name": "OcupacionRetiro", "className": "text-center" },
        { "data": "DescripcionRetiro", "name": "DescripcionRetiro", "className": "text-center" },
        { "data": "JardinAislamOfi", render: function (data, type, full) { return (full.JardinAislamOfi) ? parseFloat(data).toFixed(4) : "0.0000"; }, "className": "text-center" },
        { "data": "OcupacionJardin", "name": "OcupacionJardin",  "className": "text-center" },
        { "data": "DescripcionJardin", "name": "DescripcionJardin", "className": "text-center" },
        { "data": "Codigo",  "className": "hide_column" },
        { "data": "CodigoManzanaVia",  "className": "hide_column" },
        { "data": "CodigoVia", "className": "hide_column" }
    ],
    "language": { "lengthMenu": "", "info": "", "emptyTable": "" },
    "processing": true,
    "serverSide": false,
    "paging": false,
});

$("#tablaRetiroMunicipal tbody").on('click', 'button.btnEditMunicipal', function (event) {
    var cell = this;
    var data = tablaRetiroMunicipal.row($(this).parents('tr')).data();
    var enlace = ROOT + 'Lotes/AgregarRetiroMunicipal';
    $.post(enlace,
        {
            CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(),
            Codigo: data.Codigo, CodigoVia: data.CodigoVia, CodigoManzanaVia: data.CodigoManzanaVia, Estatico: Estatico
        }
        , function (response) {
            var id = "#modalRegistrarRetiroMunicipal"; $(id).modal().html(response);
    });
});
$("#tablaRetiroMunicipal tbody").on('click', 'button.btnDeleteMunicipal', function (event) {
    var cell = this;
    var data = tablaRetiroMunicipal.row($(this).parents('tr')).data();
    var CodigoTipoSolicitud = $('#CodigoTipSol').val();
    var NumeroSolicitud = $('#CodigoNumSol').val();
    var CodigoPeriodo = $('#Periodo').val()
    var CodigoCorrel = data.CodigoCorrelativo;
    var enlace = ROOT + 'Lotes/EliminarRetiroMunicipal';
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
                    tablaRetiroMunicipal.ajax.reload();
                });
            }
        }
    });
    
});
$("#modalRegistrarRetiroMunicipal").on('hidden.bs.modal', function () { $('#btnAgregar').focus() });

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//CAMBIOS NUEVOS CATASTRO GJLR-INI
tablaRetiroMunicipalNew = $("#tablaRetiroMunicipalNew").DataTable({
    "ajax": {
        "url": ROOT + "Lotes/CargarRetiroMunicipal",
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
        { "data": "CodigoVia", "name": "CodigoVia", "className": "text-center" },
        { "data": "NombreVia", "name": "NombreVia", "className": "text-center" },
        //{ "data": "NumeroCuadra", "name": "NumeroCuadra", "className": "text-center" },
        //{ "data": "NombreLado", "name": "NombreLado", "className": "text-center" },
        { "data": "RetiroOficial", render: function (data, type, full) { return (full.RetiroOficial) ? parseFloat(data).toFixed(4) : "0.0000"; }, "name": "RetiroOficial", "className": "text-center" },
        { "data": "RetiroCampo", render: function (data, type, full) { return (full.RetiroCampo) ? parseFloat(data).toFixed(4) : "0.0000"; }, "name": "RetiroCampo", "className": "text-center" },
        //{ "data": "OcupacionRetiro", "name": "OcupacionRetiro", "className": "text-center" },
        { "data": "CodigoOcupacionRetiro", "name": "CodigoOcupacionRetiro", "className": "text-center" },
        { "data": "DescripcionRetiro", "name": "DescripcionRetiro", "className": "text-center" }
        //{ "data": "JardinAislamOfi", render: function (data, type, full) { return (full.JardinAislamOfi) ? parseFloat(data).toFixed(4) : "0.0000"; }, "className": "text-center" },
        //{ "data": "OcupacionJardin", "name": "OcupacionJardin", "className": "text-center" },
        //{ "data": "DescripcionJardin", "name": "DescripcionJardin", "className": "text-center" },
        //{ "data": "Codigo", "className": "hide_column" },
        //{ "data": "CodigoManzanaVia", "className": "hide_column" }
        //{ "data": "CodigoVia", "className": "hide_column" }
    ],
    "language": { "lengthMenu": "", "info": "", "emptyTable": "" },
    "processing": true,
    "serverSide": false,
    "paging": false,
});

$("#tablaRetiroMunicipalNew tbody").on('click', 'button.btnEditMunicipal', function (event) {
    var cell = this;
    var data = tablaRetiroMunicipalNew.row($(this).parents('tr')).data();
    var enlace = ROOT + 'Lotes/AgregarRetiroMunicipal';
    $.post(enlace,
        {
            CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(),
            Codigo: data.Codigo, CodigoVia: data.CodigoVia, CodigoManzanaVia: data.CodigoManzanaVia, Estatico: Estatico
        }
        , function (response) {
            var id = "#modalRegistrarRetiroMunicipalNew"; $(id).modal().html(response);
        });
});
$("#tablaRetiroMunicipalNew tbody").on('click', 'button.btnDeleteMunicipal', function (event) {
    var cell = this;
    var data = tablaRetiroMunicipalNew.row($(this).parents('tr')).data();
    var CodigoTipoSolicitud = $('#CodigoTipSol').val();
    var NumeroSolicitud = $('#CodigoNumSol').val();
    var CodigoPeriodo = $('#Periodo').val()
    var CodigoCorrel = data.CodigoCorrelativo;
    var enlace = ROOT + 'Lotes/EliminarRetiroMunicipal';
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
                    tablaRetiroMunicipalNew.ajax.reload();
                });
            }
        }
    });

});
$("#modalRegistrarRetiroMunicipalNew").on('hidden.bs.modal', function () { $('#btnAgregar').focus() });
//CAMBIOS NUEVOS CATASTRO GJLR-FIN

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//CAMBIOS NUEVOS CATASTRO GJLR-INI
tablaJardinAislamientoNew = $("#tablaJardinAislamientoNew").DataTable({
    "ajax": {
        "url": ROOT + "Lotes/CargarRetiroMunicipal",
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
        { "data": "CodigoVia", "name": "CodigoVia", "className": "text-center" },
        { "data": "NombreVia", "name": "NombreVia", "className": "text-center" },
        //{ "data": "NumeroCuadra", "name": "NumeroCuadra", "className": "text-center" },
        //{ "data": "NombreLado", "name": "NombreLado", "className": "text-center" },
        //{ "data": "RetiroOficial", render: function (data, type, full) { return (full.RetiroOficial) ? parseFloat(data).toFixed(4) : "0.0000"; }, "name": "RetiroOficial", "className": "text-center" },
        //{ "data": "RetiroCampo", render: function (data, type, full) { return (full.RetiroCampo) ? parseFloat(data).toFixed(4) : "0.0000"; }, "name": "RetiroCampo", "className": "text-center" },
        //{ "data": "OcupacionRetiro", "name": "OcupacionRetiro", "className": "text-center" },
        //{ "data": "CodigoOcupacionRetiro", "name": "CodigoOcupacionRetiro", "className": "text-center" },
        //{ "data": "DescripcionRetiro", "name": "DescripcionRetiro", "className": "text-center" }
        { "data": "JardinAislamOfi", render: function (data, type, full) { return (full.JardinAislamOfi) ? parseFloat(data).toFixed(4) : "0.0000"; }, "className": "text-center" },
        //{ "data": "OcupacionJardin", "name": "OcupacionJardin", "className": "text-center" },
        { "data": "CodigoOcupacionJardin", "name": "CodigoOcupacionJardin", "className": "text-center" },
        { "data": "DescripcionJardin", "name": "DescripcionJardin", "className": "text-center" }
        //{ "data": "Codigo", "className": "hide_column" },
        //{ "data": "CodigoManzanaVia", "className": "hide_column" }
        //{ "data": "CodigoVia", "className": "hide_column" }
    ],
    "language": { "lengthMenu": "", "info": "", "emptyTable": "" },
    "processing": true,
    "serverSide": false,
    "paging": false,
});

$("#tablaJardinAislamientoNew tbody").on('click', 'button.btnEditMunicipal', function (event) {
    var cell = this;
    var data = tablaJardinAislamientoNew.row($(this).parents('tr')).data();
    var enlace = ROOT + 'Lotes/AgregarRetiroMunicipal';
    $.post(enlace,
        {
            CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(),
            Codigo: data.Codigo, CodigoVia: data.CodigoVia, CodigoManzanaVia: data.CodigoManzanaVia, Estatico: Estatico
        }
        , function (response) {
            var id = "#modalRegistrarJardinAislamientolNew"; $(id).modal().html(response);
        });
});
$("#tablaJardinAislamientoNew tbody").on('click', 'button.btnDeleteMunicipal', function (event) {
    var cell = this;
    var data = tablaJardinAislamientoNew.row($(this).parents('tr')).data();
    var CodigoTipoSolicitud = $('#CodigoTipSol').val();
    var NumeroSolicitud = $('#CodigoNumSol').val();
    var CodigoPeriodo = $('#Periodo').val()
    var CodigoCorrel = data.CodigoCorrelativo;
    var enlace = ROOT + 'Lotes/EliminarRetiroMunicipal';
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
                    tablaJardinAislamientoNew.ajax.reload();
                });
            }
        }
    });

});
$("#modalRegistrarJardinAislamientolNew").on('hidden.bs.modal', function () { $('#btnAgregar').focus() });
//CAMBIOS NUEVOS CATASTRO GJLR-FIN

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//CAMBIOS NUEVOS CATASTRO GJLR-INI
tablaAreaPublicaNew = $("#tablaAreaPublicaNew").DataTable({
    "ajax": {
        "url": ROOT + "Lotes/CargarRetiroMunicipal",
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
        { "data": "CodigoVia", "name": "CodigoVia", "className": "text-center" },
        { "data": "NombreVia", "name": "NombreVia", "className": "text-center" },
        { "data": "AreaPublicaOficial", render: function (data, type, full) { return (full.AreaPublicaOficial) ? parseFloat(data).toFixed(4) : "0.0000"; }, "name": "AreaPublicaOficial", "className": "text-center" },
        { "data": "AreaPublicaCampo", render: function (data, type, full) { return (full.AreaPublicaCampo) ? parseFloat(data).toFixed(4) : "0.0000"; }, "name": "AreaPublicaCampo", "className": "text-center" },
        { "data": "CodigoOcupacionAreaPublica", "name": "CodigoOcupacionAreaPublica", "className": "text-center" },
        { "data": "DescripcionAreaPublica", "name": "DescripcionAreaPublica", "className": "text-center" }
    ],
    "language": { "lengthMenu": "", "info": "", "emptyTable": "" },
    "processing": true,
    "serverSide": false,
    "paging": false,
});

$("#tablaAreaPublicaNew tbody").on('click', 'button.btnEditMunicipal', function (event) {
    var cell = this;
    var data = tablaAreaPublicaNew.row($(this).parents('tr')).data();
    var enlace = ROOT + 'Lotes/AgregarRetiroMunicipal';
    $.post(enlace,
        {
            CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(),
            Codigo: data.Codigo, CodigoVia: data.CodigoVia, CodigoManzanaVia: data.CodigoManzanaVia, Estatico: Estatico
        }
        , function (response) {
            var id = "#modalRegistrarAreaPublicaNew"; $(id).modal().html(response);
        });
});
$("#tablaAreaPublicaNew tbody").on('click', 'button.btnDeleteMunicipal', function (event) {
    var cell = this;
    var data = tablaAreaPublicaNew.row($(this).parents('tr')).data();
    var CodigoTipoSolicitud = $('#CodigoTipSol').val();
    var NumeroSolicitud = $('#CodigoNumSol').val();
    var CodigoPeriodo = $('#Periodo').val()
    var CodigoCorrel = data.CodigoCorrelativo;
    var enlace = ROOT + 'Lotes/EliminarRetiroMunicipal';
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
                    tablaAreaPublicaNew.ajax.reload();
                });
            }
        }
    });

});
$("#modalRegistrarAreaPublicaNew").on('hidden.bs.modal', function () { $('#btnAgregar').focus() });
//CAMBIOS NUEVOS CATASTRO GJLR-FIN

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//CAMBIOS NUEVOS CATASTRO GJLR-INI
tablaAnchoViaNew = $("#tablaAnchoViaNew").DataTable({
    "ajax": {
        "url": ROOT + "Lotes/CargarRetiroMunicipal",
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
        { "data": "CodigoVia", "name": "CodigoVia", "className": "text-center" },
        { "data": "NombreVia", "name": "NombreVia", "className": "text-center" },
        { "data": "AnchoViaOficial", render: function (data, type, full) { return (full.AnchoViaOficial) ? parseFloat(data).toFixed(4) : "0.0000"; }, "name": "AnchoViaOficial", "className": "text-center" },
        { "data": "AnchoViaCampo", render: function (data, type, full) { return (full.AnchoViaCampo) ? parseFloat(data).toFixed(4) : "0.0000"; }, "name": "AnchoViaCampo", "className": "text-center" },
        { "data": "CodigoOcupacionAnchoVia", "name": "CodigoOcupacionAnchoVia", "className": "text-center" },
        { "data": "DescripcionAnchoVia", "name": "DescripcionAnchoVia", "className": "text-center" }
    ],
    "language": { "lengthMenu": "", "info": "", "emptyTable": "" },
    "processing": true,
    "serverSide": false,
    "paging": false,
});

$("#tablaAnchoViaNew tbody").on('click', 'button.btnEditMunicipal', function (event) {
    var cell = this;
    var data = tablaAnchoViaNew.row($(this).parents('tr')).data();
    var enlace = ROOT + 'Lotes/AgregarRetiroMunicipal';
    $.post(enlace,
        {
            CodigoDistrito: $('#CodDist').val(), CodigoLote: $('#CodLote').val(), CodigoManzana: $('#CodManz').val(), CodigoSector: $('#CodSect').val(),
            Codigo: data.Codigo, CodigoVia: data.CodigoVia, CodigoManzanaVia: data.CodigoManzanaVia, Estatico: Estatico
        }
        , function (response) {
            var id = "#modalRegistrarAnchoViaNew"; $(id).modal().html(response);
        });
});
$("#tablaAnchoViaNew tbody").on('click', 'button.btnDeleteMunicipal', function (event) {
    var cell = this;
    var data = tablaAnchoViaNew.row($(this).parents('tr')).data();
    var CodigoTipoSolicitud = $('#CodigoTipSol').val();
    var NumeroSolicitud = $('#CodigoNumSol').val();
    var CodigoPeriodo = $('#Periodo').val()
    var CodigoCorrel = data.CodigoCorrelativo;
    var enlace = ROOT + 'Lotes/EliminarRetiroMunicipal';
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
                    tablaAnchoViaNew.ajax.reload();
                });
            }
        }
    });

});
$("#modalRegistrarAnchoViaNew").on('hidden.bs.modal', function () { $('#btnAgregar').focus() });
//CAMBIOS NUEVOS CATASTRO GJLR-FIN