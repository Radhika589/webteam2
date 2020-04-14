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
            {"data":"issuer.reputation"}
        ]
      } );

    //table
    //    .on('select', function (e, dt, type, indexes) {
    //        var rowData = table.rows(indexes).data().toArray();
    //        events.prepend('<div><b>' + type + ' selection</b> - ' + JSON.stringify(rowData) + '</div>');
    //    })
    //    .on('deselect', function (e, dt, type, indexes) {
    //        var rowData = table.rows(indexes).data().toArray();
    //        events.prepend('<div><b>' + type + ' <i>de</i>selection</b> - ' + JSON.stringify(rowData) + '</div>');
    //    });
    













    // async function GetAllJobs() {
    //     let fetchedJobs;
    //     fetchedJobs = await fetch("/job/getall/").
    //         then(response => response.json()).
    //         catch(error => console.log(error));
    //     return fetchedJobs;
    // };

    //PrintJobs();
    //async function PrintJobs() {
    //    let jobs = await GetAllJobs();
    //    jobs.data.forEach(job => {
    //        console.log(job.id);
    //        console.log(job.title);
    //        console.log(job.description);
    //        console.log(job.payment);
    //        console.log(job.issuer.reputation);
    //    });
    //};









});