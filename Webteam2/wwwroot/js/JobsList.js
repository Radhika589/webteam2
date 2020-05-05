window.addEventListener("load",() => {
    $('#jobs_table').DataTable({
        "ajax": "/job/getall/",
        dom: 'Bfrtip',
        buttons: {
            buttons: [
                {
                    //extend: "print",
                    //autoPrint: false,
                    text: 'Print Selected Row(chanage to "Accept Job" later)',
                    action: function (e, dt, node, config) {
                        //https://datatables.net/reference/option/buttons.buttons.action
                        //https: //stackoverflow.com/questions/31309801/using-url-action-and-route-data-in-javascript
                        var url = `@Url.Action("PreviewContract","Job",new{Area="",Id=${node}})`;

                        //console.log(node);
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

//buttons: {
//    buttons: [
//        {
//            extend: "print",
//            autoPrint: false,
//            text: 'Print Selected Row(chanage to "Accept Job" later)',
//            exportOptions: {
//                modifier: {
//                    selected: true
//                }
//            }
//        }
//    ]
//}