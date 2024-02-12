using CollegeFinder.Areas.MST_Location.Models;
using CollegeFinder.DAL.DAL_Helpers;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace CollegeFinder.DAL.MST_Location.LOC_Country
{
    public class LOC_Country_DAL : DAL_Helper
    {
        SqlDatabase sqlDB = new SqlDatabase(ConnectionString);

        #region Method : GET ALL RECORDS OF COUNTRY ...
        public List<LOC_CountryModel> PR_SELECT_RECORDS_LOC_COUNTRY()
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_LOC_COUNTRY_SELECT_RECORDS");
                DataTable countryDataTable = new DataTable();

                using (IDataReader reader = sqlDB.ExecuteReader(dbCommand))
                {
                    countryDataTable.Load(reader);
                }

                List<LOC_CountryModel> countryModelsList = new List<LOC_CountryModel>();
                foreach (DataRow item in countryDataTable.Rows)
                {
                    LOC_CountryModel countryModel = new LOC_CountryModel
                    {
                        CountryID = Convert.ToInt32(item["CountryID"].ToString()),
                        CountryName = item["CountryName"].ToString(),
                        CountryCode = item["CountryCode"].ToString() == "" ? "--" : item["CountryCode"].ToString().ToUpper(),
                        CreatedDate = Convert.ToDateTime(item["CreatedDate"].ToString()),
                        ModifiedDate = Convert.ToDateTime(item["ModifiedDate"].ToString())
                    };

                    countryModelsList.Add(countryModel);
                }

                return countryModelsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Method : GET RECORD BY COUNTRY ID ...
        public LOC_CountryModel PR_SELECT_RECORD_BY_PK_LOC_COUNTRY(int CountryID)
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_LOC_COUNTRY_SELECT_RECORD_BY_PK");
                sqlDB.AddInParameter(dbCommand, "@CountryID", SqlDbType.Int, CountryID);
                DataTable countryDataTable = new DataTable();

                using (IDataReader reader = sqlDB.ExecuteReader(dbCommand))
                {
                    countryDataTable.Load(reader);
                }
                    LOC_CountryModel countryModel = new LOC_CountryModel
                    {
                        CountryID = Convert.ToInt32(countryDataTable.Rows[0]["CountryID"].ToString()),
                        CountryName = countryDataTable.Rows[0]["CountryName"].ToString(),
                        CountryCode = countryDataTable.Rows[0]["CountryCode"].ToString(),
                        CreatedDate = Convert.ToDateTime(countryDataTable.Rows[0]["CreatedDate"].ToString()),
                        ModifiedDate = Convert.ToDateTime(countryDataTable.Rows[0]["ModifiedDate"].ToString())
                    };

                return countryModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Method : INSERT or UPDATE RECORD OF COUNTRY ...
        public Boolean PR_INSERT_UPDATE_RECORD_LOC_COUNTRY(LOC_CountryModel countryModel)
        {
            try
            {
                DbCommand dbCommand;
                if (countryModel.CountryID == null)
                {
                    dbCommand = sqlDB.GetStoredProcCommand("PR_LOC_COUNTRY_INSERT_RECORD");
                }
                else
                {
                    dbCommand = sqlDB.GetStoredProcCommand("PR_LOC_COUNTRY_UPDATE_RECORD");
                    sqlDB.AddInParameter(dbCommand, "@CountryID", SqlDbType.Int, Convert.ToInt32(countryModel.CountryID.ToString()));
                }
                sqlDB.AddInParameter(dbCommand, "@CountryName", SqlDbType.NVarChar, countryModel.CountryName.ToString());
                sqlDB.AddInParameter(dbCommand, "@CountryCode", SqlDbType.NVarChar, countryModel.CountryCode?.ToString());

                return Convert.ToBoolean(sqlDB.ExecuteNonQuery(dbCommand)) ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return false;
            }
        }
        #endregion

        #region Method : DELETE RECORD OF COUNTRY ...
        public Boolean PR_DELETE_RECORD_LOC_COUNTRY(int CountryID)
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_LOC_COUNTRY_DELETE_RECORD");
                sqlDB.AddInParameter(dbCommand, "@CountryID", SqlDbType.Int, CountryID);

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
