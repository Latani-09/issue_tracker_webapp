using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Issue_tracker_webapp.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var allUsersExceptCurrentUser = await _userManager.Users.Where(a => a.Id != currentUser.Id).ToListAsync();
            Console.WriteLine(currentUser);
            return View(allUsersExceptCurrentUser);
        }
    }
}
