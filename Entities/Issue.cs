using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Issue_tracker_webapp.Entities
{
    public class Issue
    {
        [Required]
        public Guid issueID { get; set; }
        public Guid projectID1 { get; set; }
        public Project Project { get; set; }

        public string issueTitle { get; set; }
        public string issueDescription { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string assigneeID { get; set; }
        public string reporterID { get; set; }
        public string type { get; set; }
        public Priority priority { get; set; }
        public string status { get; set; }

    }


}

public enum Priority
    {
        Low,
        Medium,
        High
    }


