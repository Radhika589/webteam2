using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Webteam2.Models;

namespace Webteam2.Views.Home
{
    public class JobsModel : PageModel
    {
        private readonly Context _db;
        public JobsModel(Context db)
        {
            _db = db;
        }
        public IEnumerable<Issue> Jobs { get; set; }
        public async Task OnGetAsync()
        {
            Jobs = await _db.Issues.ToListAsync();
        }
    }
}
