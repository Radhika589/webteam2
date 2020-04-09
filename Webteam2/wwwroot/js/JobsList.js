window.addEventListener("load", () => {
  
    var jobs= GetAllJobs();
    $('#jobs_table').dataTable( {
        "ajax": "/job/getall/",
        "columns":[
            {"data":"id"},
            {"data":"title"},
            {"data":"description"},
            {"data":"payment"},
            {"data":"issuer.reputation"}
        ]
      } );


     async function GetAllJobs() {
         let fetchedJobs;
         fetchedJobs = await fetch("/job/getall/").
             then(response => response.json()).
             catch(error => console.log(error));
         return fetchedJobs;
     };

    PrintJobs();
    async function PrintJobs() {
        let jobs = await GetAllJobs();
        jobs.data.forEach(job => {
            console.log(job.id);
            console.log(job.title);
            console.log(job.description);
            console.log(job.payment);
            console.log(job.issuer.reputation);
        });
    };

    async function PopulateTable(){
        let id_nod= document.createElement("TD");
        let title_nod= document.createElement("TD");
        let description_nod= document.createElement("TD");
        let payment_nod= document.createElement("TD");
        let issuer_rep_nod= document.createElement("TD");

        let text=document.createTextNode("test");

        id_nod.appendChild(text);
        title_nod.appendChild(text);
        description_nod.appendChild(text);
        payment_nod.appendChild(text);
        issuer_rep_nod.appendChild(text);

        document.getElementById("table_row").appendChild(id_nod);
    };

    //PopulateTable();
});