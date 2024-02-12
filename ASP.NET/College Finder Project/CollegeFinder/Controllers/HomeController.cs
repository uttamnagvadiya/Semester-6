using CollegeFinder.BAL.INS_College;
using CollegeFinder.BAL.INS_Streams;
using CollegeFinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeFinder.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewModel viewModel = new ViewModel();

            viewModel.streamModelsList = new INS_Streams_BAL().PR_SELECT_RECORDS_INS_STREAMS();
            viewModel.collegeModelsList = new INS_College_BAL().PR_SELECT_RECORDS_INS_COLLEGE();

            return View(viewModel);
        }
    }
}