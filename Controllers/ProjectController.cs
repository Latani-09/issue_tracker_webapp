using Issue_tracker_webapp.Data;
using Issue_tracker_webapp.DTOs;
using Issue_tracker_webapp.Entities;
using Issue_tracker_webapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [HttpGet]
        public async Task<ActionResult> Index()
        {

            var viewModel = new ProjectViewModel();
            viewModel.projectList = new List<projectDTO> { new projectDTO() };
            var projects = await _dataContext.projects.ToArrayAsync();

            foreach (var project in projects)
            {
                Console.WriteLine(project.projectID.ToString());
                var projectviewmodel = new projectDTO
                {
                    projectID = project.projectID.ToString(),
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
       
        public async Task<IActionResult> viewProject(string projectID)
        {
            var viewModel = new ProjectViewModel();
            var userList = await _dataContext.Users.ToListAsync();
            var userSelectList = new SelectList(userList, nameof(AppUser.Id), nameof(AppUser.UserName));
            viewModel.users= userSelectList;
            Console.Write( "project",projectID);
            var project =await _dataContext.projects.Include(x=>x.issues).SingleOrDefaultAsync(p=>(p.projectID).ToString()==projectID);
            if (project != null)
            {
                viewModel.projectview = project;
                return View(viewModel);
            }
            return BadRequest();
        }
    }
}

