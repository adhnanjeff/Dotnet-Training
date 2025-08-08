using Microsoft.AspNetCore.Mvc;

namespace BugTrack.API.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
