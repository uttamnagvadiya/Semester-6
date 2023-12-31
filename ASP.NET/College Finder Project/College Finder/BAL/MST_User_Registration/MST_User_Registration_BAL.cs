using College_Finder.Areas.MST_User_Registration.Models;
using College_Finder.DAL.MST_User_Registration_DAL;
using System.Data;

namespace College_Finder.BAL.MST_User_Registration
{
    public class MST_User_Registration_BAL
    {
        MST_User_Registration_DAL user_DAL = new MST_User_Registration_DAL();

        #region Method : GET RECORD BY (USERNAME or EMAIL) and PASSWORD ...
        public DataTable PR_LOGIN_SELECT_RECORD_BY_USERNAME_PASSWORD(MST_User_LoginModel userLoginModel)
        {
            try
            {
                return user_DAL.PR_LOGIN_SELECT_RECORD_BY_USERNAME_PASSWORD(userLoginModel);
            }catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return null;
            }
        }
        #endregion
    }
}
