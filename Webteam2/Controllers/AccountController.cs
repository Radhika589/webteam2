using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Webteam2.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webteam2.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly Context _db;
        public AccountController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, Context context)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _db = context;
        }

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

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }












        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ValidateContactor(string id)
        {
            var user = _db.Users.First(u => u.Id == id);
            await _userManager.RemoveFromRoleAsync(user, "NotValidatedContractor");
            await _userManager.AddToRoleAsync(user, "ValidatedContractor");
            //await _signInManager.RefreshSignInAsync(user);
            return RedirectToAction(nameof(AccountController.ValidateContractors), "Account");
        }


        [HttpGet]
        public IActionResult ValidateContractors(ContractorsToValidateModel contractorsToValidateModel)
        {
            contractorsToValidateModel.UsersList = _userManager.GetUsersInRoleAsync("NotValidatedContractor").Result;
            return View(contractorsToValidateModel);
            //return RedirectToPage(nameof(AccountController.ValidateContractors), contractorsToValidateModel);
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
            //var user = await _userManager.FindByEmailAsync(userLoginModel.Email);
            //if (user != null && await _userManager.CheckPasswordAsync(user, userLoginModel.Password))
            //{
            //    var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
            //    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
            //    identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            //    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(identity));
            //    return RedirectToLocal(returnUrl);
            //}
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
