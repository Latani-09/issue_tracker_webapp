using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Issue_tracker_webapp.Entities
{
    public class Project
    {
        [Required]
        public Guid projectID { get; set; }
        public string projectName { get; set; }
        public string projectDescription { get; set; }
        public ICollection<Issue> issues { get; set; }
        public ICollection<IdentityUser> users {get; set;}    

    }
}
