using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Issue_tracker_webapp.Entities
{
    public class Issue
    {
        [Required]
        public Guid issueID { get; set; }
        public string projectID { get; set; }
        public string issueTitle { get; set; }
        public string issueDescription { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int assigneeID { get; set; }
        public int reporterID { get; set; }
        public string type { get; set; }
        public string priority { get; set; }
        public string status { get; set; }

    }
}
