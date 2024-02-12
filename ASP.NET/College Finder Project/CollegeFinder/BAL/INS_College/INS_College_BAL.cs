using CollegeFinder.Areas.INS_College.Models;
using CollegeFinder.DAL.INS_College;

namespace CollegeFinder.BAL.INS_College
{
    public class INS_College_BAL
    {
        INS_College_DAL college_DAL = new INS_College_DAL();

        #region Method : GET ALL RECORDS OF INS_COLLEGE ...
        public List<INS_CollegeModel> PR_SELECT_RECORDS_INS_COLLEGE()
        {
            try
            {
                return college_DAL.PR_SELECT_RECORDS_INS_COLLEGE();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Method : GET RECORD BY COLLEGE ID OF INS_COLLEGE ...
        public INS_CollegeModel PR_SELECT_RECORD_BY_PK_INS_COLLEGE(int CollegeID)
        {
            try
            {
                return college_DAL.PR_SELECT_RECORD_BY_PK_INS_COLLEGE(CollegeID: CollegeID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return null;
            }
        }
        #endregion
    }
}
