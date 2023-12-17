using Issue_tracker_webapp.Data;
using Issue_tracker_webapp.DTOs;
using Issue_tracker_webapp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Issue_tracker_webapp.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _dataContext;
        public ProjectController(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;

        }
        public IActionResult Index()
        {
            return View();
        }
        public void AddProject( [FromBody] projectDTO Project)
        {
                
            var project_toCreate = new Project
            {
                projectID = Guid.NewGuid(),
                projectName=Project.projectTitle,
                projectDescription=Project.projectDescription,
            

            };
            _dataContext.projects.AddAsync(project_toCreate);
            _dataContext.SaveChangesAsync();
        }
    }
}
}
