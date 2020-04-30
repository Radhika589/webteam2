using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webteam2.Models;

namespace Webteam2
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<User> _userManager;

        public ProfileController(Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(new ProfileViewModel
            {
                UserProfile = user.Profile,
                IsContractor = await _userManager.IsInRoleAsync(user, "contractor")
            });
        }

//        public async Task<IActionResult> Edit() 
//        {
//            var user = await _userManager.GetUserAsync(User);
//
//            return View(new ProfileViewModel
//            {
//                UserProfile = user.Profile,
//                IsContractor = await _userManager.IsInRoleAsync(user, "contractor")
//            });
//        }

        public IActionResult Update(EditProfileModel model)
        {
            throw new NotImplementedException();
        }
    }
}
