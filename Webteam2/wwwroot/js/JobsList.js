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
                        action: function(e, dt, node, config) {
                            //kopla till "skapa nya jobb"
                            //for ANDREAS
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
            "columns": [
                { "data": "id" },
                { "data": "title" },
                { "data": "description" },
                { "data": "location" },
                { "data": "payment" },
                { "data": "issuer.reputation" },
                { "data": "issuer.firstName" },
                { "data": "issuer.lastName" }
        ]}).buttons().disable();

        $("#jobs_table").on("click",
            "tr",
            function() {
                //Här lägger du länken till sidan du vill ladda
                window.location.href = '/job/PreviewContract?Id=' + $(this).attr('Id');
            });

});

