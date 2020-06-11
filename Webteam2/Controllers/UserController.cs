using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Threading.Tasks;
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
                return Json(new { data = await _db.Users.ToListAsync() });
            }
            else
            {
                return Json(new { success = false, message = "No Users Are Available." });
            }
        }

#nullable enable

        [HttpGet]
        public IActionResult Index(string? searchString)
        {
            var userLists = new UserLists
            {
                Customers = _userManager.GetUsersInRoleAsync("Customer").Result,
                NotValidatedContractors = _userManager.GetUsersInRoleAsync("NotValidatedContractor").Result,
                ValidatedContractors = _userManager.GetUsersInRoleAsync("ValidatedContractor").Result,
                Administrators = _userManager.GetUsersInRoleAsync("Administrator").Result
            };
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Substring(0, 1).ToUpper()
                               + searchString.Substring(1, searchString.Length - 1).ToLower();


                userLists.Customers = userLists.Customers
                    .Where(
                       c => c.FirstName.Contains(searchString)
                       || c.LastName.Contains(searchString)
                    ).ToList();

                userLists.NotValidatedContractors = userLists.NotValidatedContractors
                    .Where(
                        c => c.FirstName.Contains(searchString)
                             || c.LastName.Contains(searchString)
                    ).ToList();

                userLists.ValidatedContractors = userLists.ValidatedContractors
                    .Where(
                        c => c.FirstName.Contains(searchString)
                             || c.LastName.Contains(searchString)
                    ).ToList();

                userLists.Administrators = userLists.Administrators
                    .Where(
                        c => c.FirstName.Contains(searchString)
                             || c.LastName.Contains(searchString)
                    ).ToList();
            }

            return View(userLists);
        }

#nullable disable

        #endregion API Calls
    }
}