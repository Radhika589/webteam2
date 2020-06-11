window.addEventListener("load", () => {
    var table = $('#jobs_table').DataTable({
        "ajax": "/job/getall/",
        "createdRow": function (row, data, id) {
            $(row).attr('Id', data.id);
        },
        dom: 'Bfrtip',
        buttons: {
            buttons: [
                {
                    text: 'Suggest A Price',
                    action: function (e, dt, node, config) {
                        //Connect to "Create a new job" Action method.
                        //for ANDREAS

                        //todo: Delete before the final release.
                        console.log("If you can see this, the action function inside the button works.");
                    },
                    exportOptions: {
                        modifier: {
                            selected: true
                        }
                    }
                }
            ]
        },
        "select": {
            style: 'single'
        },
        //Makes the first column(id) invisible.
        //!Note: The column is still there, and it's data can be accessed! Only the visibility has been disabled.
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            }, 
            {
                targets: 1,
                render: function (data, type, row) {
                    return type === 'display' && data.length > 15 ?
                        data.substr(0, 12) + '...' :
                        data;
                }
            },
            {
                targets: 2,
                render: function (data, type, row) {
                    return type === 'display' && data.length > 25 ?
                        data.substr(0, 22) + '...' :
                        data;
                }
            },
            {
                targets: 3,
                render: function (data, type, row) {
                    return type === 'display' && data.length > 15 ?
                        data.substr(0, 12) + '...' :
                        data;
                }
            },
            {
                targets: 6,
                render: function (data, type, row) {
                    return type === 'display' && data.length > 15 ?
                        data.substr(0, 12) + '...' :
                        data;
                }
            },
            {
                targets: 7,
                render: function (data, type, row) {
                    return type === 'display' && data.length > 15 ?
                        data.substr(0, 12) + '...' :
                        data;
                }
            }
        ],
        "columns": [
            { "data": "id" },
            { "data": "title" },
            { "data": "description" },
            { "data": "location" },
            { "data": "payment" },
            { "data": "issuer.reputation" },
            { "data": "issuer.firstName" },
            { "data": "issuer.lastName" }
        ]
    }).buttons().disable();

    $("#jobs_table").on("click",
        "tr",
        function () {
            let id = $(this).attr('Id');
            if (id) {
               window.location.href = '/job/PreviewContract?Id=' + $(this).attr('Id'); 
            }
        });
});