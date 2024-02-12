using CollegeFinder.BAL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeFinder.Areas.MST_Admin.Controllers
{
    [CheckAccess]
    [Area("MST_Admin")]
    public class MST_AdminController : Controller
    {
        public IActionResult Index()
        {
            return View("AdminDashboard");
        }
    }
}
