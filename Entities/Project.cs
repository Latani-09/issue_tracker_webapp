using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Issue_tracker_webapp.Entities
{
    public class Project
    {
        [Required]
        public Guid projectID { get; set; }

        [Required]
        public string projectName { get; set; }

        public string projectDescription { get; set; }

        public ICollection<Issue> issues { get; set; } = new List<Issue>();

        public ICollection<IdentityUser> Users { get; set; } = new List<IdentityUser>();
    }

}