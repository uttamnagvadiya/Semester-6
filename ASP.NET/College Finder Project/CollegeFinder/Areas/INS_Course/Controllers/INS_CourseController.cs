using CollegeFinder.Areas.INS_Course.Models;
using CollegeFinder.Areas.INS_Streams.Models;
using CollegeFinder.BAL;
using CollegeFinder.BAL.MST_Location.LOC_COUNTRY;
using CollegeFinder.BAL.MST_Location.LOC_State;
using CollegeFinder.DAL.INS_Streams;
using CollegeFinder.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CollegeFinder.Areas.INS_Course.Controllers
{
    [Area("INS_Course")]
    public class INS_CourseController : Controller
    {
        INS_Course_BAL course_BAL = new INS_Course_BAL();

        #region ... Get Course List ...
        public IActionResult Index()
        {
            DataTable courseDataTable = course_BAL.PR_SELECT_RECORD_INS_COURSE();
            return View("CourseList", courseDataTable);
        }
        #endregion

        #region ... Get Course Details ...
        public IActionResult AboutCourse(int CourseID)
        {
            INS_CourseModel courseModel = course_BAL.PR_SELECT_RECORD_BY_PK_INS_COURSE(CourseID: CourseID);
            return View(courseModel);
        }
        #endregion

        #region ... Course Registration Form ...
        [CheckAccess]
        public IActionResult AddNewCourse()
        {
            List<INS_StreamModel> streamsList = new INS_Streams_DAL().PR_SELECT_RECORDS_INS_STREAMS();
            ViewBag.StreamList = streamsList;

            return View();
        }
        #endregion

        #region ... Update Course Record ...
        [CheckAccess]
        public IActionResult Update(int CourseID)
        {
            INS_CourseModel courseModel;
            try
            {
                List<INS_StreamModel> streamsList = new INS_Streams_DAL().PR_SELECT_RECORDS_INS_STREAMS();
                ViewBag.StreamList = streamsList;
                courseModel = course_BAL.PR_SELECT_RECORD_BY_PK_INS_COURSE(CourseID: CourseID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return View("AddNewCourse");
            }
            return View("AddNewCourse", courseModel);
        }
        #endregion

        #region ... Save Course Record ...
        [CheckAccess]
        public IActionResult Save(INS_CourseModel courseModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    course_BAL.PR_INSERT_UPDATE_RECORD_INS_COURSE(courseModel: courseModel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Message :: {ex.Message}");
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region ... Delete Course Record ...
        [CheckAccess]
        public IActionResult Delete(int CourseID)
        {
            try
            {
                course_BAL.PR_DELETE_RECORD_INS_COURSE(CourseID: CourseID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}
