using Issue_tracker_webapp.Data;
using Issue_tracker_webapp.DTOs;
using Issue_tracker_webapp.Entities;
using Issue_tracker_webapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Issue_tracker_webapp.Controllers
{
    public class IssuesController : Controller

    {
        private readonly ApplicationDbContext _dataContext;
        private readonly UserManager<IdentityUser> _userManager;
        public IssuesController(ApplicationDbContext dataContext, UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
        
            _dataContext = dataContext;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddIssue(  Guid projectID, ProjectViewModel viewmodel)
        {
          
            var project = await _dataContext.projects.SingleOrDefaultAsync(p => p.projectID == projectID);
            if (project == null) { Console.WriteLine("project not found"); }
            else
            {
                Console.WriteLine("issue to project ----------------------------------------------------------------");
                Console.WriteLine(project.projectName);
            }

            //Console.WriteLine("shopping cart id------------------------------------------------------");

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            // Create a new cart item if no cart item exists.                 
            var issue_toCreate = new Issue
            {
                issueID = Guid.NewGuid(),
                projectID1 = projectID,
                reporterID = currentUser.Id,
                createdAt = DateTime.Now,
                issueTitle = viewmodel.issue.issueTitle,
                assigneeID = viewmodel.issue.assigneeID,
                issueDescription =  viewmodel.issue.issueDescription,
                status="not ",
                priority=viewmodel.issue.priority,
                type=viewmodel.issue.type,

            };
            Console.WriteLine(issue_toCreate);
            await _dataContext.issues.AddAsync(issue_toCreate);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
