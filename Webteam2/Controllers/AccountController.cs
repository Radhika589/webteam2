using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webteam2.Models;

namespace Webteam2.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private Context _context;

        public AccountController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, Context context)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
			_context = context;
        }
        //todo:do this
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrationModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }
            var user = _mapper.Map<User>(userModel);
            var userProfile = new Profile
            {
                Id = Guid.NewGuid().ToString(),
                User = user,
                UserId = user.Id,
                Description = "",
                PictureURL = $"https://api.adorable.io/avatars/150/{user.Id}.png"
            };
            
            user.Profile = userProfile;
            _context.Profiles.Add(userProfile);
            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(userModel);
            }
            await _userManager.AddToRoleAsync(user, userModel.Role);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> Initialize()
        {
            if (_context.Users.Any())
            {
                return new JsonResult("You already have users in your database");
            }
            var password = "Password123@";
            var admin = "Administrator";
            var customer = "Customer";
            var contractNoVal = "NotValidatedContractor";
            var contractYesVal = "ValidatedContractor";
            var Users = new UserRegistrationModel[]
            {
                new UserRegistrationModel{
                    FirstName = "Daniel",
                    LastName = "Andersson",
                    Email = "1@hotmail.com",
                    Password = password,
                    ConfirmPassword = password,
                    Role= customer
                },
                new UserRegistrationModel{
                    FirstName = "Fredrik",
                    LastName = "Karlsson",
                    Email = "2@hotmail.com",
                    Password = password,
                    ConfirmPassword = password,
                    Role= customer
                },
                new UserRegistrationModel{
                    FirstName = "Arne",
                    LastName = "Bertilsson",
                    Email = "3@hotmail.com",
                    Password = password,
                    ConfirmPassword = password,
                    Role= customer
                },
                new UserRegistrationModel{
                    FirstName = "Roger",
                    LastName = "Andersson",
                    Email = "4@hotmail.com",
                    Password = password,
                    ConfirmPassword = password,
                    Role= contractNoVal
                },
                new UserRegistrationModel{
                    FirstName = "Pontus",
                    LastName = "Rickardsson",
                    Email = "5@hotmail.com",
                    Password = password,
                    ConfirmPassword = password,
                    Role= contractNoVal
                },
                new UserRegistrationModel{
                    FirstName = "Olof",
                    LastName = "Torsson",
                    Email = "6@hotmail.com",
                    Password = password,
                    ConfirmPassword = password,
                    Role= contractNoVal
                },
                new UserRegistrationModel{
                    FirstName = "Anna",
                    LastName = "Andersson",
                    Email = "7@hotmail.com",
                    Password = password,
                    ConfirmPassword = password,
                    Role= contractYesVal
                },
                new UserRegistrationModel{
                    FirstName = "Sara",
                    LastName = "Novi",
                    Email = "8@hotmail.com",
                    Password = password,
                    ConfirmPassword = password,
                    Role= contractYesVal
                },
                new UserRegistrationModel{
                    FirstName = "Emma",
                    LastName = "Svensson",
                    Email = "9@hotmail.com",
                    Password = password,
                    ConfirmPassword = password,
                    Role= contractYesVal
                },
                new UserRegistrationModel{
                    FirstName = "Linnea",
                    LastName = "Hjalmarsson",
                    Email = "10@hotmail.com",
                    Password = password,
                    ConfirmPassword = password,
                    Role= contractYesVal
                },
                new UserRegistrationModel{
                    FirstName = "Admin",
                    LastName = "Adminsson",
                    Email = "Admin@hotmail.com",
                    Password = password,
                    ConfirmPassword = password,
                    Role= admin
                },

            };
            foreach (var UserReg in Users)
            {
                var user = _mapper.Map<User>(UserReg);
                var userProfile = new Profile
                {
                    Id = Guid.NewGuid().ToString(),
                    User = user,
                    UserId = user.Id,
                    Description = "",
                    PictureURL = $"https://api.adorable.io/avatars/150/{user.Id}.png"
                };

                user.Profile = userProfile;
                _context.Profiles.Add(userProfile);
                await _userManager.CreateAsync(user, UserReg.Password);
                await _userManager.AddToRoleAsync(user, UserReg.Role);
                _context.SaveChanges();
            }
            return new JsonResult("Successfully added users to your database");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ValidateContactor(string id)
        {
            var user = _context.Users.First(u => u.Id == id);
            await _userManager.RemoveFromRoleAsync(user, "NotValidatedContractor");
            await _userManager.AddToRoleAsync(user, "ValidatedContractor");
            return RedirectToAction(nameof(AccountController.ValidateContractors), "Account");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult ValidateContractors(ContractorsToValidateModel contractorsToValidateModel)
        {
            contractorsToValidateModel.UsersList = _userManager.GetUsersInRoleAsync("NotValidatedContractor").Result;
            return View(contractorsToValidateModel);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginModel);
            }
            var result = await _signInManager.PasswordSignInAsync(userLoginModel.Email, userLoginModel.Password, userLoginModel.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid Username or Password");
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index),"Home");
            }
        }
    }
}
