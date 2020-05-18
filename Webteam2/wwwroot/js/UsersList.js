window.addEventListener("load", () => {
    $('#users_table').DataTable({
        "ajax": "/User/getall",
        "createdRow": function(row, data, id) {
            $(row).attr('Id', data.id);
        },
        dom: 'Bfrtip',
        buttons: {
            buttons: [
                {
                    text: 'Do Something',
                    action: function (e, dt, node, config) {
                        //Connect to an Action method.
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
        "columnDefs": [
            {
                targets: 0,
                render: function (data, type, row) {
                    return type === 'display' && data.length > 15 ?
                        data.substr(0, 12) + '...' :
                        data;
                }
            },
            {
                targets: 1,
                render: function (data, type, row) {
                    return type === 'display' && data.length > 15 ?
                        data.substr(0, 12) + '...' :
                        data;
                }
            }
            //{
            //    targets: 4,
            //    render: function (data, type, row) {
            //        return type === 'display' && data.length > 15 ?
            //            data.substr(0, 12) + '...' :
            //            data;
            //    }
            //}
        ],
        "columns": [
            { "data": "firstName" },
            { "data": "lastName" },
            { "data": "reputation" },
            { "data": "tel" },
            { "data": "location" }
        ]
    });

    //$("#jobs_table").on("click",
    //    "tr",
    //    function () {
    //        let id = $(this).attr('Id');
    //        if (id) {
    //            window.location.href = '/job/PreviewContract?Id=' + $(this).attr('Id');
    //        }
    //    });
});