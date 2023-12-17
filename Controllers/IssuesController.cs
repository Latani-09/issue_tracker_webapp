using Issue_tracker_webapp.Data;
using Issue_tracker_webapp.DTOs;
using Issue_tracker_webapp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Issue_tracker_webapp.Controllers
{
    public class IssuesController : Controller

    {
        private readonly ApplicationDbContext _dataContext;
        public IssuesController(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;

        }
        public IActionResult Index()
        {
            return View();
        }


        public void AddIssue(int projectid, [FromBody] issueDTO issue)
        {
            var project = _dataContext.projects.SingleOrDefault(
                   p => p.projectID == projectid);
            if (project == null) { Console.WriteLine("project not found"); }
            else
            {
                Console.WriteLine("projwct added to cart----------------------------------------------------------------");
                Console.WriteLine(project.projectName);
            }

            //Console.WriteLine("shopping cart id------------------------------------------------------");


            // Create a new cart item if no cart item exists.                 
            var issue_toCreate = new Issue
            {
                issueID = Guid.NewGuid(),
                projectID = projectid,
                createdAt = DateTime.Now,
                issueTitle = issue.issueTitle,
                issueDescription = issue.issueDescription,

            };
            _dataContext.issues.AddAsync(issue_toCreate);
            _dataContext.SaveChangesAsync();
        }
    }
}
