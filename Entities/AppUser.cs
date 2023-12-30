using Microsoft.AspNetCore.Identity;

namespace Issue_tracker_webapp.Entities
{
    public class AppUser:IdentityUser<string>  
    {

        public string? Gender { get ; set; }
        public string? City { get; set; }
        

    }
}
