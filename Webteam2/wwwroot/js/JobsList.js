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

                            var data = table.buttons.exportData({ modifier: { selected: true } });
                            AjaxDisplayString();

                            

                            function AjaxDisplayString() {
                                $.ajax({
                                    url: '/job/PreviewContract/',
                                    type: 'POST',
                                    dataType: 'json',
                                    data: data,
                                    success: console.log('yes'),
                                    error:console.log('no')
                                });
                            }

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

