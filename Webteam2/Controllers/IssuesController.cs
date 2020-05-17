using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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

        public async Task<IActionResult> Index()
        {
            return await _context.Issues.AnyAsync() ? View(await _context.Issues.ToListAsync()) : View(new List<Issue>());
        }


        // GET: Issues/Create
        [Authorize(Roles = "Administrator, Customer")]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Payment,Title,Description,CityId")]
            Issue issue)
        {
            issue.Id = NewIssueId();
            issue.Issuer = await this._userManager.GetUserAsync(User);
            issue.City = await this._context.City.FindAsync(issue.CityId);

            if (ModelState.IsValid)
            {
                _context.Add(issue);

                await _context.SaveChangesAsync();
                ViewBag.Message = "Success: Issue added!";
                return View();
            }

            ViewBag.Message = "Something went wrong...";
            return View(issue);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (IssueExists(id))
            {
                var issue = await _context.Issues.FindAsync(id);
                ViewBag.CanEdit = await CanEdit(issue);
                return View(issue);
            }

            return NotFound();
        }

        [Authorize(Roles = "Administrator, Customer")]
        public async Task<IActionResult> Edit(string id)
        {
            if (IssueExists(id))
            {
                var issue = await _context.Issues.FindAsync(id);
                if (await CanEdit(issue))
                {
                    return View(issue);
                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Payment,Title,Description,CityId")]
            Issue issue)
        {
            if (id != issue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssueExists(issue.Id))
                    {
                        return NotFound();
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(issue);
        }

        [Authorize(Roles = "Administrator, Customer")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id.IsNullOrEmpty())
            {
                return NotFound();
            }

            var issue = await _context.Issues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (issue == null)
            {
                return NotFound();
            }

            if (!await CanEdit(issue))
            {
                return NotFound();
            }

            return View(issue);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var issue = await _context.Issues.FindAsync(id);
            _context.Issues.Remove(issue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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

        private async Task<bool> CanEdit(Issue issue)
        {
            var sender = await _userManager.GetUserAsync(User);
            if (User.IsInRole("Administrator"))
            {
                return true;
            }

            if (issue.Issuer == sender)
            {
                return true;
            }

            return false;
        }
    }
}
