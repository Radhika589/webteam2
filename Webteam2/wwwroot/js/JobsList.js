window.addEventListener("load", () => {
  
    //var events = $('#events');
    /*var table =*/ $('#jobs_table').DataTable({
        "ajax": "/job/getall/",
        dom: 'Bfrtip',
        buttons: [
            {
                extend: "print",
                autoPrint:false,
                text: 'Print Selected Row(chanage to "Accept Job" later)',
                exportOptions: {
                    modifier: {
                        selected: true
                    }
                }
            }
        ],
        "select": {
            style:'single'
        },
        "columns":[
            {"data":"title"},
            {"data":"description"},
            {"data":"location"},
            {"data":"payment"},
            { "data": "issuer.reputation" },
            { "data": "issuer.firstName" },
            { "data": "issuer.lastName" }
        ]
      } );

});