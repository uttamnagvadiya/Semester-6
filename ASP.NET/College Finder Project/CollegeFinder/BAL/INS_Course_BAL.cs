using CollegeFinder.Areas.INS_Course.Models;
using CollegeFinder.DAL.INS_Course;
using System.Data;
using System.Data.Common;

namespace CollegeFinder.BAL
{
    public class INS_Course_BAL
    {
        INS_Course_DAL course_DAL = new INS_Course_DAL();

        #region Method : GET COURSE LIST ...
        public DataTable PR_SELECT_RECORD_INS_COURSE()
        {
            try
            {
              return course_DAL.PR_SELECT_RECORDS_INS_COURSE();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Method : GET RECORD BY ID ...
        public INS_CourseModel PR_SELECT_RECORD_BY_PK_INS_COURSE(int CourseID)
        {
            try
            {
                return course_DAL.PR_SELECT_RECORD_BY_PK_INS_COURSE(CourseID: CourseID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Method : INSERT or UPDATE RECORD ...
        public Boolean PR_INSERT_UPDATE_RECORD_INS_COURSE(INS_CourseModel courseModel)
        {
            try
            {
                return course_DAL.PR_INSERT_UPDATE_RECORD_INS_COURSE(courseModel: courseModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return false;
            }
        }
        #endregion

        #region Method : DELETE RECORD BY ID ...
        public Boolean PR_DELETE_RECORD_INS_COURSE(int CourseID)
        {
            try
            {
                return course_DAL.PR_DELETE_RECORD_INS_COURSE(CourseID: CourseID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return false;
            }
        }
        #endregion
    }
}
