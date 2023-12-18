using Microsoft.AspNetCore.Identity;
using Issue_tracker_webapp.Entities;

namespace Issue_tracker_webapp.Interface
{
    public interface ITokenService
    {
         Task<string> createToken(AppUser user);
    }
}
