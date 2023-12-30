using Issue_tracker_webapp.DTOs;
using Issue_tracker_webapp.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Issue_tracker_webapp.Models
{
    public class ProjectViewModel
    {
        public List<projectDTO> projectList { get; set; }  
        public Project projectview { get; set; }
        public Issue issue  { get; set; }
        public SelectList users { get; set; }
        public SelectList Priority { get; set; } = new SelectList(new List<string> { "low", "high", "medium" });
        public SelectList type { get; set; } = new SelectList(new List<string> { "bug", "task" });
        public SelectList status { get; set; } = new SelectList(new List<string> { "solved", "unsolved" });
        public string userdID { get; set; }
    }

}
