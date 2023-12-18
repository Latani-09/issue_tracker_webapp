using Issue_tracker_webapp.DTOs;
using Issue_tracker_webapp.Entities;

namespace Issue_tracker_webapp.Models
{
    public class ProjectViewModel
    {
        public List<projectDTO> projectList { get; set; }  
        public Project projectview { get; set; }

    }

}
