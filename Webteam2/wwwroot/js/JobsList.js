window.addEventListener("load",() => {
        var table = $('#jobs_table').DataTable({
            "ajax": "/job/getall/",
            dom: 'Bfrtip',
            buttons: {
                buttons: [
                    {
                        //extend: "print",
                        //autoPrint: false,
                        text: 'Suggest A Price',
                        action: function(e, dt, node, config) {
                            //https://datatables.net/reference/option/buttons.buttons.action
                            //https: //stackoverflow.com/questions/31309801/using-url-action-and-route-data-in-javascript
                            //https://datatables.net/reference/type/selector-modifier

                            let selectedRow = table.row({ selected: true }).data();
                            //var url = Url.Action("PreviewContract","Job",new{id:selectedRow});
                                
                            var data = table.buttons.exportData({modifier:{selected:true}});

                            console.log(data);
                            


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
            { "data": "title" },
            { "data": "description" },
            { "data": "location" },
            { "data": "payment" },
            { "data": "issuer.reputation" },
            { "data": "issuer.firstName" },
            { "data": "issuer.lastName" }
        ]
    });
});

