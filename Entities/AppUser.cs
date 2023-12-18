using Microsoft.AspNetCore.Identity;

namespace Issue_tracker_webapp.Entities
{
    public class AppUser:IdentityUser<int>  //just to tell that id is int
    {

        public string? Gender { get ; set; }
        public string? City { get; set; }
        

    }
}
