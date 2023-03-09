"use strict";
let jsonResponse;

function initDOM() {
    setTimeout(() => { ClientesCadastrados(); }, 200);
}


function ClientesCadastrados() {

    $.get("/Clientes/ListarClientesCadastrados", function (data) {
        jsonResponse = data;
    }).done(function () {
        setTimeout(function () {
            jQuery(document).ready(function () {
                KTDatatable.init();
            });
        }, 200);
    }).fail(function (e) {
        var json = JSON.parse(e.responseText);
        var msg = "Code: " + json.code + "\nError Msg: " + json.errorMessage + "\nMsg: " + json.message;
        alert(msg);
        console.log(e.responseText);
    });
}


var KTDatatable = function () {
    var load = function () {
        var Array = JSON.parse(jsonResponse);

        var datatable = $('#kt_datatable').KTDatatable({
            // datasource definition
            data: {
                type: 'local',
                source: Array,
                pageSize: 100,
            },
            // layout definition
            layout: {
                scroll: false, // enable/disable datatable scroll both horizontal and vertical when needed.
                footer: false // display/hide footer
            },
            // column sorting
            sortable: true,
            pagination: true,
            search: {
                input: $('#kt_datatable_search_query'),
                key: 'generalSearch'
            },

            // columns definition
            columns: [
                {
                    field: 'codigo',
                    title: 'Codigo',
                    sortable: false,
                    width: 150,
                    textAlign: 'center',
                    template: function (row) {
                        return '<a href="javascript:buscarCliente(' + [row.codigo] + ')[0]">' + [row.codigo] + '</a>';
                    }
                }, {
                    field: 'razaoSocial',
                    width: 200,
                    title: 'Razao Social',
                }, {
                    field: 'cidade',
                    width: 100,
                    title: 'Cidade',
                }, {
                    field: 'estado',
                    width: 60,
                    title: 'Estado',
                }, {
                    field: 'isActive',

                    width: 100,
                    title: 'Status',
                    autoHide: false,
                    // callback function support for column rendering
                    template: function (row) {
                        var status = {
                            true: {
                                'title': 'Active',
                                'class': ' label-light-success'
                            },
                            false: {
                                'title': 'Inactive',
                                'class': ' label-light-danger'
                            }
                        };
                        return '<span class="label font-weight-bold label-lg' + status[row.isActive].class + ' label-inline">' + status[row.isActive].title + '</span>';
                    },
                },
            ],
        }

        );



        $('#kt_datatable_search_status').on('change', function () {

            datatable.search($(this).val(), 'isActive')
        });
        $('#kt_datatable_search_type').on('change', function () {
            datatable.search($(this).val().toLowerCase(), 'estado');
        });

        $('#kt_datatable_search_status, #kt_datatable_search_type').selectpicker();
    };

    return {
        // public functions
        init: function () {
            load();
        }
    };
}();



function buscarCliente(codigo) {
    window.location.href = "/Clientes/Cliente?codigo=" + codigo;

}

initDOM();