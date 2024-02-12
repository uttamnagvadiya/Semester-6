using CollegeFinder.Areas.INS_College.Models;
using CollegeFinder.BAL;
using CollegeFinder.BAL.INS_College;
using CollegeFinder.DAL.INS_College;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CollegeFinder.Areas.INS_College.Controllers
{
    [Area("INS_College")]
    public class INS_CollegeController : Controller
    {
        INS_College_BAL college_BAL = new INS_College_BAL();
        INS_CollegeViewModel collegeViewModel = new INS_CollegeViewModel();

        #region ... Get College List ...
        public IActionResult Index()
        {
            DataTable dataTable = new INS_College_DAL().PR_SELECT_RECORDS_INS_COLLEGE_DATATABLE();
            return View("CollegeList", dataTable);
        }
        #endregion

        #region ... Get College Details ...
        public IActionResult AboutCollege(int CollegeID)
        {
            collegeViewModel.CollegeDetailsModel = college_BAL.PR_SELECT_RECORD_BY_PK_INS_COLLEGE(CollegeID: CollegeID);
            return View(collegeViewModel);
        }
        #endregion

        #region ... Insert New College ...
        [CheckAccess]
        public IActionResult AddNewCollege(int? CollegeID)
        {
            return View();
        }
        #endregion

        public IActionResult Save()
        {
            return RedirectToAction("Index");
        }
    }
}
