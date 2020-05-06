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

                        //TODO: Delete before the final release.
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
            window.location.href = '/job/PreviewContract?Id=' + $(this).attr('Id');
        });
});