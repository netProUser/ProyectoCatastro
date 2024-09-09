console.log("LinderosUnidad");
function RecuperarLinderos() {
    LoteLinderos.ajax.reload();
};

function RegistrarLindero(lado) {
    $.get(ROOT + "Cotitularidad/AgregarLindero/" + lado,
        function (response) {
            var id = "#modalRegistrarLindero";
            $(id).modal().html(response);

        });
};

$("#modalRegistrarLindero").on('shown.bs.modal',
    function () {
        $('#MedidaLadoCam').focus().select()
    });


LoteLinderos = $("#LoteLinderos").DataTable({
    "ajax": {
        "url": ROOT + "Cotitularidad/BuscarLoteLinderos",
        "type": "POST",
        "datatype": "json",
        "data": function (d) {
            d.codUniCat =  $('#CodigoUnidadCatastral').val(),
            d.Estatico =  Estatico
        }
    },
    "columns": [
        {
            'render': function (data, type, full, meta) {
                var disabled = (full.CodigoColindante == "0001") ? "" : "";
                return '<button data-toggle="tooltip" title="Editar" class="btn mr-1 text-center btnEditLindero btn-default btn-xs glyphicon glyphicon-edit" type="button" ></button>' +
                '<button data-toggle="tooltip"  title="Eliminar"  ' + disabled + ' class="btn mr-1 text-center btnDeleteLindero btn-default btn-xs glyphicon glyphicon-trash" type="button" ></button>';
            }, "className": "text-center"
        },
        { "data": "NombreLado", "name": "NombreLado", "className": "text-center" },
        { "data": "NumeroLado", "name": "NumeroLado", "className": "text-center" },
        { "data": "MedidaLadoCam", render: function (data, type, full) { return parseFloat(data).toFixed(4); }, "name": "MedidaLadoCam", "className": "text-right" },
        { "data": "MedidaLadoOfi", render: function (data, type, full) { return parseFloat(data).toFixed(4); }, "name": "MedidaLadoOfi", "className": "text-right" },
        { "data": "ListaUnidadColindantes", "name": "ListaUnidadColindantes", "className": "text-center" },
        { "data": "CodigoColindante", "name": "CodigoColindante", "autoWidth": true, "className": "hide_column" },
        { "data": "CodigoLado", "name": "CodigoLado", "autoWidth": true, "className": "hide_column" },
        { "data": "Codigo", "name": "Codigo", "autoWidth": true, "className": "hide_column" }


    ],
    "language": { "lengthMenu": "", "info": "", "emptyTable": "" },
    "processing": true,
    "serverSide": false,
    "paging": false,
});

$("#LoteLinderos tbody").on('click', 'button.btnDeleteLindero', function (event) {
    var cell = this;
    var data = LoteLinderos.row($(this).parents('tr')).data();
    var enlace = ROOT + 'Cotitularidad/EliminarLinderoUnidad';
    console.log('Data', data);
        bootbox.confirm({
            title: "Mensaje del Sistema", message: "¿Esta seguro de borrar el registro?",
            buttons: { confirm: { label: '<i class="fa fa-trash"></i> Eliminar ', className: "btn btn-danger" }, cancel: { label: '<i class="fa fa-times"></i> Cancelar' } },
            callback: function (result) {
                if (result) {
                    $.post(enlace,
                    {
                        CodigoUnidadColidante: $('#CodigoUnidadCatastral').val(),
                        Estatico : Estatico,
                        CodigoLado: data.CodigoLado,
                        Codigo: data.Codigo,
                        NumeroLado: data.NumeroLado
                    }
                    , function (response) {
                        RecuperarLinderos();
                        toastr.success("Registro eliminado correctamente", "Mensaje del Sistema", { "progressBar": true });
                    });
                }
            }
        });
    
});

$("#LoteLinderos tbody").on('click', 'button.btnEditLindero', function (event) {
    var cell = this;
    var data = LoteLinderos.row($(this).parents('tr')).data();
    var enlace = ROOT + 'Cotitularidad/AgregarLindero';
    $.post(enlace,
        {
            CodigoUnidadColidante: $('#CodigoUnidadCatastral').val(),
            Estatico : Estatico,
            CodigoLado: data.CodigoLado,
            Codigo: data.Codigo,
            NumeroLado: data.NumeroLado
        }
        , function (response) {
            var id = "#modalRegistrarLindero";
            $(id).modal().html(response);
        });
});

