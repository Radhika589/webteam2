using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webteam2.Models;

namespace Webteam2.Controllers
{
    public class JobController : Controller
    {
        private readonly Context _db;
        public JobController(Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (_db.Issues.Any())
            {
                return Json(new { data = await _db.Issues.ToListAsync() });
            }
            else
            {
                return Json(new { success = false, message = "No Jobs Are Available!" });
            }
        }
        #endregion
    }
}