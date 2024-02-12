using CollegeFinder.Areas.MST_Location.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using CollegeFinder.DAL.DAL_Helpers;
using System.Data.Common;
using System.Data;
using System.Windows.Input;

namespace CollegeFinder.DAL.MST_Location.LOC_City
{
    public class LOC_City_DAL : DAL_Helper
    {
        SqlDatabase sqlDB = new SqlDatabase(ConnectionString);

        #region Method : GET ALL RECODRS OF CITY ...
        public List<LOC_CityModel> PR_SELECT_RECORDS_LOC_CITY()
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_LOC_CITY_SELECT_RECORDS");
                DataTable dataTable = new DataTable();
                using (IDataReader reader = sqlDB.ExecuteReader(dbCommand))
                {
                    dataTable.Load(reader);
                }

                List<LOC_CityModel> cityModelsList = new List<LOC_CityModel>();
                foreach (DataRow item in dataTable.Rows)
                {
                    LOC_CityModel cityModel = new LOC_CityModel
                    {
                        CityID = Convert.ToInt32(item["CityID"].ToString()),
                        CityName = item["CityName"].ToString(),
                        CityCode = item["CityCode"].ToString() == "" ? "--" : item["CityCode"].ToString().ToUpper(),
                        StateID = Convert.ToInt32(item["StateID"].ToString()),
                        StateName = item["StateName"].ToString(),
                        StateCode = item["StateCode"].ToString() == "" ? "--" : item["StateCode"].ToString().ToUpper(),
                        CountryID = Convert.ToInt32(item["CountryID"].ToString()),
                        CountryName = item["CountryName"].ToString(),
                        CountryCode = item["CountryCode"].ToString() == "" ? "--" : item["CountryCode"].ToString().ToUpper(),
                        CreatedDate = Convert.ToDateTime(item["CreatedDate"].ToString()),
                        ModifiedDate = Convert.ToDateTime(item["ModifiedDate"].ToString()),
                    };
                    cityModelsList.Add(cityModel);
                }
                return cityModelsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Method : GET RECORD BY CITY ID ...
        public LOC_CityModel PR_SELECT_RECORD_BY_PK_LOC_CITY(int CityID)
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_LOC_CITY_SELECT_RECORD_BY_PK");
                sqlDB.AddInParameter(dbCommand, "@CityID", SqlDbType.Int, CityID);
                DataTable cityDataTable = new DataTable();

                using (IDataReader reader = sqlDB.ExecuteReader(dbCommand))
                {
                    cityDataTable.Load(reader);
                }
                LOC_CityModel cityModel = new LOC_CityModel
                {
                    CityID = Convert.ToInt32(cityDataTable.Rows[0]["CityID"].ToString()),
                    CityName = cityDataTable.Rows[0]["CityName"].ToString(),
                    CityCode = cityDataTable.Rows[0]["CityCode"].ToString(),
                    StateID = Convert.ToInt32(cityDataTable.Rows[0]["StateID"].ToString()),
                    StateName = cityDataTable.Rows[0]["StateName"].ToString(),
                    StateCode = cityDataTable.Rows[0]["StateCode"].ToString(),
                    CountryID = Convert.ToInt32(cityDataTable.Rows[0]["CountryID"].ToString()),
                    CountryName = cityDataTable.Rows[0]["CountryName"].ToString(),
                    CountryCode = cityDataTable.Rows[0]["CountryCode"].ToString(),
                    CreatedDate = Convert.ToDateTime(cityDataTable.Rows[0]["CreatedDate"].ToString()),
                    ModifiedDate = Convert.ToDateTime(cityDataTable.Rows[0]["ModifiedDate"].ToString()),
                };

                return cityModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Method : INSERT or UPDATE RECORD OF CITY ...
        public Boolean PR_INSERT_UPDATE_RECORD_LOC_CITY(LOC_CityModel cityModel)
        {
            try
            {
                DbCommand dbCommand;
                if (cityModel.CityID == null)
                {
                    dbCommand = sqlDB.GetStoredProcCommand("PR_LOC_CITY_INSERT_RECORD");
                }
                else
                {
                    dbCommand = sqlDB.GetStoredProcCommand("PR_LOC_CITY_UPDATE_RECORD");
                    sqlDB.AddInParameter(dbCommand, "@CityID", SqlDbType.Int, cityModel.CityID);
                }
                sqlDB.AddInParameter(dbCommand, "@CityName", SqlDbType.NVarChar, cityModel.CityName.ToString());
                sqlDB.AddInParameter(dbCommand, "@CityCode", SqlDbType.NVarChar, cityModel.CityCode?.ToString());
                sqlDB.AddInParameter(dbCommand, "@StateID", SqlDbType.Int, Convert.ToInt32(cityModel.StateID.ToString()));

                return Convert.ToBoolean(sqlDB.ExecuteNonQuery(dbCommand)) ? true : false;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return false;
            }
        }
        #endregion

        #region Method : DELETE RECORD OF CITY ...
        public Boolean PR_DELELTE_RECORD_LOC_CITY(int CityID)
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_LOC_CITY_DELETE_RECORD");
                sqlDB.AddInParameter(dbCommand, "@CityID", SqlDbType.Int, CityID);

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
