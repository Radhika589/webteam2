window.addEventListener("load", () => {

    $('#users_table').DataTable({
        "ajax": "/User/getall",
        dom: 'Bfrtip',
        buttons: [
            {
                extend: "print",
                autoPrint: false,
                text: 'Print Selected Row(chanage to "Choose this user" later)',
                exportOptions: {
                    modifier: {
                        selected: true
                    }
                }
            }
        ],
        "select": {
            style: 'single'
        },
        "columns": [
            { "data": "firstName" },
            { "data": "lastName" },
            { "data": "reputation" },
            { "data": "tel" },
            { "data": "location" }
        ]
    });
});