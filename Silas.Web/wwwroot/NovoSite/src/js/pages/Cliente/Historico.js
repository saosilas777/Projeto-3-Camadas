"use strict";
let jsonResponse;
let historicoCliente;

const codigo = document.getElementById("codigoCliente");

function initDOM() {
    setTimeout(() => { ClientesCadastrados(); }, 1000)
}


function ClientesCadastrados() {

    $.get("/Clientes/BuscarCliente?codigo=" + codigo.value, function (data) {
        jsonResponse = JSON.parse(data);
        
    }).done(function () {
        
        setTimeout(function () {
            jQuery(document).ready(function () {
                historicoCliente = jsonResponse.historicoCliente.historico;
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
        var Array = historicoCliente;
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

            // columns definition
            columns: [{
                field: 'clienteID',
                title: 'ID',
                sortable: false,
                width: 400,
                //selector: {
                //    class: ''
                //},
                textAlign: 'center',
                template: function (row) {
                    return '<a href="javascript:buscarCliente(' + [row.clienteID] + ')[0]">' + [row.clienteID] + '</a>';
                }
            }, {
                field: 'data',
                width: 300,
                title: 'Data de Contato',
            }, {
                field: 'registroDeContato',
                width: 400,
                title: 'Registro',
            }],
        });
        $('#kt_datatable_search_level').on('change', function () {
            datatable.search($(this).val().toLowerCase(), 'isActive');
        });

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