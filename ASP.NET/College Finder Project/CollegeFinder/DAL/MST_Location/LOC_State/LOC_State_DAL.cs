using CollegeFinder.Areas.MST_Location.Models;
using CollegeFinder.DAL.DAL_Helpers;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace CollegeFinder.DAL.MST_Location.LOC_State
{
    public class LOC_State_DAL : DAL_Helper
    {
        SqlDatabase sqlDB = new SqlDatabase(ConnectionString);

        #region Method : GET ALL RECODRS OF STATE ...
        public List<LOC_StateModel> PR_SELECT_RECORDS_LOC_STATE()
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_LOC_STATE_SELECT_RECORDS");
                DataTable dataTable = new DataTable();

                using (IDataReader reader = sqlDB.ExecuteReader(dbCommand))
                {
                    dataTable.Load(reader);
                }

                List<LOC_StateModel> stateModelsList = new List<LOC_StateModel>();
                foreach (DataRow item in dataTable.Rows)
                {
                    LOC_StateModel stateModel = new LOC_StateModel
                    {
                        StateID = Convert.ToInt32(item["StateID"].ToString()),
                        StateName = item["StateName"].ToString(),
                        StateCode = item["StateCode"].ToString() == "" ? "--" : item["StateCode"].ToString().ToUpper(),
                        CountryID = Convert.ToInt32(item["CountryID"].ToString()),
                        CountryName = item["CountryName"].ToString(),
                        CountryCode = item["CountryCode"].ToString() == "" ? "--" : item["CountryCode"].ToString().ToUpper(),
                        CreatedDate = Convert.ToDateTime(item["CreatedDate"].ToString()),
                        ModifiedDate = Convert.ToDateTime(item["ModifiedDate"].ToString()),
                    };
                    stateModelsList.Add(stateModel);
                }
                return stateModelsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Method : GET RECORD BY STATE ID ...
        public LOC_StateModel PR_SELECT_RECORD_BY_PK_LOC_STATE(int StateID)
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_LOC_STATE_SELECT_RECORD_BY_PK_FK");
                sqlDB.AddInParameter(dbCommand, "@StateID", SqlDbType.Int, StateID);
                DataTable stateDataTable = new DataTable();

                using (IDataReader reader = sqlDB.ExecuteReader(dbCommand))
                {
                    stateDataTable.Load(reader);
                }
                LOC_StateModel stateModel = new LOC_StateModel
                {
                    StateID = Convert.ToInt32(stateDataTable.Rows[0]["StateID"].ToString()),
                    StateName = stateDataTable.Rows[0]["StateName"].ToString(),
                    StateCode = stateDataTable.Rows[0]["StateCode"].ToString(),
                    CountryID = Convert.ToInt32(stateDataTable.Rows[0]["CountryID"].ToString()),
                    CountryName = stateDataTable.Rows[0]["CountryName"].ToString(),
                    CountryCode = stateDataTable.Rows[0]["CountryCode"].ToString(),
                    CreatedDate = Convert.ToDateTime(stateDataTable.Rows[0]["CreatedDate"].ToString()),
                    ModifiedDate = Convert.ToDateTime(stateDataTable.Rows[0]["ModifiedDate"].ToString()),
                };

                return stateModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Method : GET RECORDS BY COUNTRY ID ...
        public List<LOC_StateModel> PR_SELECT_RECORDS_BY_FK_LOC_STATE(int CountryID)
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_LOC_STATE_SELECT_RECORD_BY_PK_FK");
                sqlDB.AddInParameter(dbCommand, "@CountryID", SqlDbType.Int, CountryID);
                DataTable stateDataTable = new DataTable();

                using (IDataReader reader = sqlDB.ExecuteReader(dbCommand))
                {
                    stateDataTable.Load(reader);
                }
                List<LOC_StateModel> stateModelsList = new List<LOC_StateModel>();
                foreach (DataRow item in stateDataTable.Rows)
                {
                    LOC_StateModel stateModel = new LOC_StateModel
                    {
                        StateID = Convert.ToInt32(item["StateID"].ToString()),
                        StateName = item["StateName"].ToString(),
                        StateCode = item["StateCode"].ToString() == "" ? "--" : item["StateCode"].ToString().ToUpper(),
                    };
                    stateModelsList.Add(stateModel);
                }
                return stateModelsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Method : INSERT or UPDATE RECORD OF STATE ...
        public Boolean PR_INSERT_UPDATE_RECORD_LOC_STATE(LOC_StateModel stateModel)
        {
            try
            {
                DbCommand dbCommand;
                if (stateModel.StateID == null)
                {
                    dbCommand = sqlDB.GetStoredProcCommand("PR_LOC_STATE_INSERT_RECORD");
                }
                else
                {
                    dbCommand = sqlDB.GetStoredProcCommand("PR_LOC_STATE_UPDATE_RECORD");
                    sqlDB.AddInParameter(dbCommand, "@StateID", SqlDbType.Int, Convert.ToInt32(stateModel.StateID.ToString()));
                }
                sqlDB.AddInParameter(dbCommand, "@StateName", SqlDbType.NVarChar, stateModel.StateName.ToString());
                sqlDB.AddInParameter(dbCommand, "@StateCode", SqlDbType.NVarChar, stateModel.StateCode?.ToString());
                sqlDB.AddInParameter(dbCommand, "@CountryID", SqlDbType.Int, stateModel.CountryID);

                return Convert.ToBoolean(sqlDB.ExecuteNonQuery(dbCommand).ToString()) ? true : false;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return false;
            }
        }
        #endregion

        #region Method : DELETE RECORD OF STATE ...
        public Boolean PR_DELELTE_RECORD_LOC_STATE(int StateID)
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_LOC_STATE_DELETE_RECORD");
                sqlDB.AddInParameter(dbCommand, "@StateID", SqlDbType.Int, StateID);

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
