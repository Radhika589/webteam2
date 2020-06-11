﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
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
            return Json(new { success = false, message = "No Jobs Are Available!" });
        }

        //todo: is this even used anymore?
        [HttpGet]
        public async Task<IActionResult> PreviewContract(string id)
        {
            if (id != "undefined")
            {
                var issue = await _db.Issues
                 .FirstOrDefaultAsync(issue => issue.Id == id);
                return View(issue);
            }
            return View(null);
        }

        //todo: Remove if not needed.
        //[HttpPost]
        //public ActionResult OnPostLeaveABid(string id, int bid)
        //{
        //    if (bid==null)
        //    {
        //        return View(null);
        //    }
        //    _db.Issues.FirstOrDefault(issue => issue.Id == id).Bid = bid;
        //    _db.SaveChanges();
        //    return View();
        //}

        //[HttpDelete]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var job = await _db.Issues.FirstOrDefaultAsync(job=>job.Id==id);
        //    if (job==null)
        //    {
        //        return Json(new { success = false, message="Error while deleting" }) ;
        //    }
        //    _db.Issues.Remove(job);
        //    await _db.SaveChangesAsync();
        //    return Json(new { success=true,message="Deleting was successful"});
        //}

        #endregion API Calls
    }
}