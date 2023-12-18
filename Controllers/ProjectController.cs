using Issue_tracker_webapp.Data;
using Issue_tracker_webapp.DTOs;
using Issue_tracker_webapp.Entities;
using Issue_tracker_webapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Issue_tracker_webapp.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _dataContext;
        public ProjectController(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;

        }
        public async Task<ActionResult> Index()
        {

            var viewModel = new ProjectViewModel();
            viewModel.projectList = new List<projectDTO> { new projectDTO() };
            var projects = await _dataContext.projects.ToArrayAsync();

            foreach (var project in projects)
            {
                var projectviewmodel = new projectDTO
                {
                    projectID = project.projectID,
                    projectName = project.projectName,
                    projectDescription = project.projectDescription
                };
                viewModel.projectList.Add(projectviewmodel);
            }

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectViewModel project)
        {
            Console.Write(project.projectview.projectName, project.projectview.projectDescription);
            var project_toCreate = new Project
            {
                projectID = Guid.NewGuid(),
                projectName = project.projectview.projectName,
                projectDescription = project.projectview.projectDescription,


            };
            Console.WriteLine("project --------------------", project_toCreate.projectName, project_toCreate.projectDescription);
            await _dataContext.projects.AddAsync(project_toCreate);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost ("{projectID}")]
        public async Task<IActionResult> viewProject(Guid  projectID, ErrorViewModel errorViewModel)
        {
            Console.Write(projectID);
            var project =await _dataContext.projects.SingleOrDefaultAsync(p=>p.projectID==projectID);
            if (project != null)
            {
                return View(project);
            }
            return BadRequest();
        }
    }
}

