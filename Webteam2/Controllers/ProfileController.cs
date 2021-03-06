﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using RestClient.Net;
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
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ShowCount()
        {
            var apiCall = new Client(new Uri($"https://api.countapi.xyz/get/DanielAPIcall/ProfileUpdates"));
            var response = await apiCall.GetAsync<CountModel>();

            return View(response.Body);
        }
        public async Task<IActionResult> Index()
        {
            var apiCall = new Client(new Uri($"https://api.countapi.xyz/hit/DanielAPIcall/ProfileUpdates"));
            var response = await apiCall.GetAsync<CountModel>();

            var user = await _userManager.GetUserAsync(User);
                return View(new ProfileViewModel
                {
                    UserProfile = user.Profile,
                    IsContractor = await _userManager.IsInRoleAsync(user, "contractor"),
                    UserIssues = await _context.Issues.Where(m => m.Issuer == user).ToListAsync()
                });
            
        }
        public async Task<IActionResult> Details(string? id)
        {
            var apiCall = new Client(new Uri($"https://api.countapi.xyz/hit/DanielAPIcall/ProfileUpdates"));
            var response = await apiCall.GetAsync<CountModel>();
            if (id.IsNullOrEmpty())
            {
                return NotFound();
            }
            var user = await _context.Users.FirstAsync(u => u.Id == id);
                return View(new ProfileViewModel
                {
                    UserProfile = user.Profile,
                    IsContractor = await _userManager.IsInRoleAsync(user, "contractor")
                });
            
        }
        

        [HttpPost]
        public async Task<IActionResult> Update(EditProfileModel model)
        {
            if (ModelState.IsValid)
            {
                var encoded = HttpUtility.UrlEncode(model.Description);
                var client = new Client(new Uri($"https://www.purgomalum.com/service/plain?text={encoded}"));
                var response = await client.GetAsync<string>();
                var user = await _userManager.GetUserAsync(User);

                user.Profile.Description = response.Body;
                
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", model);
        }
    }

    
}
