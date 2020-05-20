using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webteam2.Models;

namespace Webteam2.Controllers
{
    public class UserController : Controller
    {
        private readonly Context _db;
        private readonly UserManager<User> _userManager;
        public UserController(Context db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
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
        [HttpGet]
        public IActionResult Index(UserLists userLists)
        {
            userLists.Customers = _userManager.GetUsersInRoleAsync("Customer").Result;
            userLists.NotValidatedContractors = _userManager.GetUsersInRoleAsync("NotValidatedContractor").Result;
            userLists.ValidatedContractors = _userManager.GetUsersInRoleAsync("ValidatedContractor").Result;
            userLists.Administrators = _userManager.GetUsersInRoleAsync("Administrator").Result;
            return View(userLists);
            //return RedirectToPage(nameof(AccountController.ValidateContractors), contractorsToValidateModel);
        }
        #endregion
    }
}