using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webteam2.Models;

namespace Webteam2.Controllers
{
    public class UserController : Controller
    {
        private readonly Context _db;
        public UserController(Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            if (_db.Users.Any())
            {
                return Json(new { data = await _db.Users.ToListAsync()});
            }
            else
            {
                return Json(new { success=false,message="No Users Are Available."});
            }
        }
        #endregion
    }
}