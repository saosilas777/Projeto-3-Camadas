function GetParams() {
    $.get("https://localhost:5001", function (data) {
        jsonResponse = data;
    }).done(function () {
        setTimeout(function () {
            jQuery(document).ready(function () {
                KTDatatable.init();
            });
        }, 20);
    }).fail(function (e) {
        var json = JSON.parse(e.responseText);
        var msg = "Code: " + json.code + "\nError Msg: " + json.errorMessage + "\nMsg: " + json.message;
        alert(msg);
        console.log(e.responseText);
    });
}


var KTDatatable = function () {
    var load = function () {
        var array = JSON.parse(jsonResponse);
        var datatable = $('#kt_datatable').KTDatatable({
            // datasource definition
            data: {
                type: 'local',
                source: array,
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
            columns: [{
                field: 'Codigo',
                title: '#',
                sortable: false,
                width: 40,
                type: 'number',
                //selector: {
                //    class: ''
                //},
                textAlign: 'center',
                template: function (row) {
                    return '<a href="javascript:OpenParamDetail(' + [row.id] + ')">' + [row.id] + '</a>';
                }
            }, {
                field: 'RazaoSocial',
                title: 'Razao Social',
            }, {
                field: 'Cidade',
                title: 'Cidade',
            }, {
                field: 'Estado',
                title: 'Estado',
            }, {
                field: 'isActive',
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
            }],
        });
        $('#kt_datatable_search_level').on('change', function () {
            datatable.search($(this).val().toLowerCase(), 'isActive');
        });
        // $('#kt_datatable_search_status, #kt_datatable_search_type').selectpicker();
        $('#kt_datatable_search_type').selectpicker();
    };
    return {
        // public functions
        init: function () {
            load();
        }
    };
}();