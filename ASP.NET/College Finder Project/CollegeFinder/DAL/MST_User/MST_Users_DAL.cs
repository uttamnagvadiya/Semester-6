using CollegeFinder.Areas.MST_Users.Models;
using CollegeFinder.DAL.DAL_Helpers;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace CollegeFinder.DAL.MST_User
{
    public class MST_Users_DAL : DAL_Helper
    {
        SqlDatabase sqlDB = new SqlDatabase(ConnectionString);

        #region Method : GET RECORD BY (USERNAME | EMAIL) and PASSWORD ...
        public DataTable PR_LOGIN_SELECT_RECORD_BY_USERNAME_PASSWORD(string Username, string Password)
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_MST_USER_REGISTRATION_SELECT_BY_USERNAME_PASSWORD");
                sqlDB.AddInParameter(dbCommand, "@Username", SqlDbType.NVarChar, Username.ToString());
                sqlDB.AddInParameter(dbCommand, "@Password", SqlDbType.NVarChar, Password.ToString());
                DataTable dataTable = new DataTable();
                using (IDataReader reader = sqlDB.ExecuteReader(dbCommand))
                {
                    dataTable.Load(reader);
                }
                return dataTable;
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
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_MST_USER_REGISTRATION_INSERT_RECORD");
                sqlDB.AddInParameter(dbCommand, "@Username", SqlDbType.NVarChar, userModel.Username.ToString());
                sqlDB.AddInParameter(dbCommand, "@Email", SqlDbType.NVarChar, userModel.Email.ToString());
                sqlDB.AddInParameter(dbCommand, "@Password", SqlDbType.NVarChar, userModel.ConfirmPassword.ToString());

                return Convert.ToBoolean(sqlDB.ExecuteNonQuery(dbCommand)) ? true : false;
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
