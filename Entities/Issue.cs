using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Issue_tracker_webapp.Entities
{
    public class Issue
    {
        public int issueID;
        public int projectID;
        public string issueTitle;
        public string issueDescription;
        public DateTime createdAt;
        public DateTime updatedAt;
        public int assigneeID;
        public int reporterID;
        public string type;
        public string priority;
        public string status;

    }
}
