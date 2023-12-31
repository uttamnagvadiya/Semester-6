using College_Finder.Areas.MST_User_Registration.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace College_Finder.DAL.MST_User_Registration_DAL
{
    public class MST_User_Registration_DAL : DAL_Helpers
    {
        SqlDatabase sqlDB = new SqlDatabase(ConnectionString);

        #region Method : GET RECORD BY (USERNAME or EMAIL) and PASSWORD ...
        public DataTable PR_LOGIN_SELECT_RECORD_BY_USERNAME_PASSWORD(MST_User_LoginModel userLoginModel)
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_MST_USER_REGISTRATION_SELECT_BY_USERNAME_PASSWORD");
                sqlDB.AddInParameter(dbCommand, "@Username", SqlDbType.NVarChar, userLoginModel.Username.ToString());
                sqlDB.AddInParameter(dbCommand, "@Password", SqlDbType.NVarChar, userLoginModel.Password.ToString());
                DataTable dataTable = new DataTable();
                using (IDataReader reader = sqlDB.ExecuteReader(dbCommand))
                {
                    dataTable.Load(reader);
                }

                return dataTable;
            } catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return null;
            }
        }
        #endregion
    }
}
