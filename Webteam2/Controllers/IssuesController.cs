using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Webteam2.Models;

namespace Webteam2.Controllers
{
    [Authorize]
    public class IssuesController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<User> _userManager;
        private User _user { get { return _userManager.GetUserAsync(User).Result; } }
        private bool _IsAdmin { get { return _userManager.IsInRoleAsync(_user, "Administrator").Result; } }
        private string _userRole { get { return _userManager.GetRolesAsync(_user).Result[0]; } }

        public IssuesController(Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private bool HasWriteAccess(Issue issue)
        {
            if (_IsAdmin || _user.Id == issue.OwnerID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CanReadDetails(Issue issue)
        {
            string[] allowedRoles = { "Administrator","Contractor"};
            if (allowedRoles.Contains(_userRole) || HasWriteAccess(issue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // GET: Issues
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                IssuesViewModel issuesView = new IssuesViewModel();
                if (await _context.Issues.ToListAsync() != null)
                {
                    issuesView.AllIssues = await _context.Issues.ToListAsync();
                    issuesView.UserIssues = issuesView.AllIssues.Where(id => id.OwnerID == _user.Id).ToList();
                }
                return View(issuesView);
            }
            else
            {
                return NotFound();
            }

        }

        // GET: Issues/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var issue = await _context.Issues
                .FirstOrDefaultAsync(m => m.ID == id);
            if (issue != null )
            {
                if (CanReadDetails(issue))
                {
                    return View(issue);
                }
                else
                {
                    return NotFound("You're not allowed here.");
                }
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Issues/Create
        public async Task<IActionResult> Create()
        {
            if (_userRole == "Customer" || _IsAdmin)
            {
                return View();
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Issues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Location,Payment,Title,Description")] Issue issue)
        {
            if (ModelState.IsValid)
            {
                issue.OwnerID = _userManager.GetUserId(this.User);
                _context.Add(issue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(issue);
        }

        // GET: Issues/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var issue = await _context.Issues.FindAsync(id);
            if (issue != null)
            {
                if (HasWriteAccess(issue))
                {
                    return View(issue);
                }
                else
                {
                    return NotFound("You're not allowed here.");
                }
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Issues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Location,OwnerID,Payment,Title,Description")] Issue issue)
        {
           
            if (id != issue.ID)
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
                    if (!IssueExists(issue.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(issue);
        }

        // GET: Issues/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (!IssueExists(id))
            {
                return NotFound();
            }

            var issue = await _context.Issues
                .FirstOrDefaultAsync(m => m.ID == id);
            if (issue != null)
            {
                if (HasWriteAccess(issue))
                {
                    return View(issue);
                }
                else
                {
                    return NotFound("You're not allowed here.");
                }
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Issues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            _context.Issues.Remove(issue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssueExists(int id)
        {
            return _context.Issues.Any(e => e.ID == id);
        }
    }
}
