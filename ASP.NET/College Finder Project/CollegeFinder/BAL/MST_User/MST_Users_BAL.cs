using CollegeFinder.Areas.MST_Users.Models;
using CollegeFinder.DAL.MST_User;
using System.Data;

namespace CollegeFinder.BAL.MST_User
{
    public class MST_Users_BAL
    {
        MST_Users_DAL user_DAL = new MST_Users_DAL();

        #region Method : GET RECORD BY (USERNAME | EMAIL) and PASSWORD ...
        public DataTable PR_LOGIN_SELECT_RECORD_BY_USERNAME_PASSWORD(string Username, string Password)
        {
            try
            {
                return user_DAL.PR_LOGIN_SELECT_RECORD_BY_USERNAME_PASSWORD(Username: Username, Password: Password);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Method : INSERT RECORD WHEN USER SIGN UP ...
        public Boolean PR_REGISTER_INSERT_RECORD(MST_UserModel userModel)
        {
            try
            {
                return Convert.ToBoolean(user_DAL.PR_REGISTER_INSERT_RECORD(userModel)) ? true : false;
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
