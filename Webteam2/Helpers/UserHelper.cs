using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using Webteam2.Models;

namespace Webteam2.Helpers
{
    public enum UserRole
    {
        Administrator,
        Contractor,
        Customer,
        Visitor
    }

    public interface IUserHelperService
    {
        IEnumerable<Issue> GetUserIssues();
        User User { get; }
        string RoleString { get; }
        UserRole Role { get; }
        bool IsAdmin { get; }
    }
 /*
     Setup: 
      Add as a service in startup.cs under ConfigureServices() with the following line: 
        'services.Add(new ServiceDescriptor(typeof(IUserHelperService), typeof(UserHelper), ServiceLifetime.Scoped));'
        
    Usage:
        <CShtml> If you want to use it without a controller:
            put '@inject Webteam2.Helpers.IUserHelperService <name>'(Replace <name> with whatever you wanna call it. ignore <>) 
            anywhere you see fit and then call it with <name>.method() or <name>.property.

        <Controllers>
           1. Add a private readonly IUserHelperService property to your class. ex: 'private readonly IUserHelperService _userHelper;'
           2. Add it to the controller constructor and assign it to your private property. 
           ex: 
                private readonly IUserHelperService _userHelper;
                public HomeController(ILogger<HomeController> logger, IUserHelperService userHelper)
                {
                    _logger = logger;
                    _userHelper = userHelper;
                }
         
    Info: 
        You can see some live examples in /home/inddex 
                                          /Controllers/HomeController
                                          /startup.cs
*/

    public class UserHelper : IUserHelperService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContext;
        private readonly Context _context;


        public UserHelper(UserManager<User> userManager, IHttpContextAccessor httpContext, Context context)
        {
            this._userManager = userManager;
            this._httpContext = httpContext;
            this._context = context;
        }


        #region Public Getters

        public User User { get => _userManager.GetUserAsync(_httpContext.HttpContext.User).Result; }
        public string RoleString { get => GetUserRole(); }
        public UserRole Role { get => UserRoleFromString(RoleString); }
        public bool IsAdmin { get => Role == UserRole.Administrator; }

        #endregion


        #region Public methods
        /// <summary>method: <c>'GetUserIssues'</c>
        /// Returns all issues created by the current user. 
        /// </summary>
        public IEnumerable<Issue> GetUserIssues()
        {
            return _context.Issues.Where(m => m.Issuer == User);
        }

        #endregion

        #region Private methods
        private string GetUserRole()
        {
            var role = _userManager.GetRolesAsync(User).Result;
            return role.FirstOrDefault();
        }
        private UserRole UserRoleFromString(string role)
        {
            switch (role)
            {
                case "Administrator":
                    return UserRole.Administrator;
                case "Contractor":
                    return UserRole.Contractor;
                case "Customer":
                    return UserRole.Customer;
                default:
                    return UserRole.Visitor;
            }
        }
        #endregion
    }
}
