var datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#jobs_table').datatable({
        "ajax": {
            "url": "/job/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "30%" },
            { "data": "title", "width": "30%" },
            { "data": "description", "width": "30%" },
            { "data": "payment", "width": "30%" },
            { "data": "issuerRep", "width": "30%" },
        ],
        "language": {
            "emptyTable": "no data found"
        },
        width: "100%"
    });
}