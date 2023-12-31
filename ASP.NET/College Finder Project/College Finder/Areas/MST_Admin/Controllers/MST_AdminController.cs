using Microsoft.AspNetCore.Mvc;

namespace College_Finder.Areas.MST_Admin.Controllers
{
    [Area("MST_Admin")]
    public class MST_AdminController : Controller
    {
        public IActionResult Index()
        {
            return View("AdminDashboard");
        }
    }
}
