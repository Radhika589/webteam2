using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Webteam2.Models;

namespace Webteam2.Controllers
{
    [Authorize]
    public class IssuesController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<User> _userManager;

        public IssuesController(Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Issues/Create
        [Authorize(Roles = "Administrator, Customer")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Issues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Location,Payment,Title,Description")] Issue issue)
        {
            issue.Id = NewIssueId();
            issue.Issuer = await this._userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                _context.Add(issue);

                await _context.SaveChangesAsync();
                ViewData["IssueResult"] = "Success: Issue added!";
                return View();        
            }
            ViewData["IssueResult"] = "Fail...";
            return View(issue);
        }

        private bool IssueExists(string id)
        {
            return _context.Issues.Any(e => e.Id == id);
        }

        private string NewIssueId()
        {
            string id = GenerateIdString();
            while (IssueExists(id))
            {
                id = GenerateIdString();
            }
            return id;
        }

        private string GenerateIdString()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
