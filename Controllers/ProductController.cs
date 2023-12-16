using Microsoft.AspNetCore.Mvc;

namespace Issue_tracker_webapp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
