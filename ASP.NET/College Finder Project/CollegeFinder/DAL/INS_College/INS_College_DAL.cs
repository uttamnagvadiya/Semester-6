using CollegeFinder.Areas.INS_College.Models;
using CollegeFinder.DAL.DAL_Helpers;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace CollegeFinder.DAL.INS_College
{
    public class INS_College_DAL : DAL_Helper
    {
        SqlDatabase sqlDB = new SqlDatabase(ConnectionString);

        #region Method : GET ALL RECORDS OF INS_COLLEGE ...
        public List<INS_CollegeModel> PR_SELECT_RECORDS_INS_COLLEGE()
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_INS_COLLEGE_SELECT_RECORDS");
                DataTable dataTable = new DataTable();

                using (IDataReader reader = sqlDB.ExecuteReader(dbCommand))
                {
                    dataTable.Load(reader);
                }

                List<INS_CollegeModel> collegeModelsList = new List<INS_CollegeModel>();
                foreach (DataRow item in dataTable.Rows)
                {
                    INS_CollegeModel collegeModel = new INS_CollegeModel
                    {
                        CollegeID = Convert.ToInt32(item["CollegeID"].ToString()),
                        CollegeLogo = item["CollegeLogo"].ToString(),
                        CollegeName = item["CollegeName"].ToString(),
                        CollegeShortName = item["CollegeShortName"].ToString(),
                        ApprovalID = Convert.ToInt32(item["ApprovalID"].ToString()),
                        ApprovalShortName = item["ApprovalShortName"].ToString(),
                        CollegeTypeID = Convert.ToInt32(item["CollegeTypeID"].ToString()),
                        CollegeTypeName = item["CollegeTypeName"].ToString(),
                        Address = item["Address"].ToString(),
                        CityID = Convert.ToInt32(item["CityID"].ToString()),
                        CityName = item["CityName"].ToString(),
                    };
                    collegeModelsList.Add(collegeModel);
                }

                return collegeModelsList;
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
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_INS_COLLEGE_SELECT_RECORD_BY_PK");
                sqlDB.AddInParameter(dbCommand, "@CollegeID", SqlDbType.Int, CollegeID);
                DataTable collegeDataTable = new DataTable();

                using (IDataReader reader = sqlDB.ExecuteReader(dbCommand))
                {
                    collegeDataTable.Load(reader);
                }

                INS_CollegeModel collegeModel = new INS_CollegeModel();
                collegeModel.CollegeID = Convert.ToInt32(collegeDataTable.Rows[0]["CollegeID"].ToString());
                collegeModel.CollegeLogo = collegeDataTable.Rows[0]["CollegeLogo"].ToString();
                collegeModel.CollegeName = collegeDataTable.Rows[0]["CollegeName"].ToString();
                collegeModel.CollegeShortName = collegeDataTable.Rows[0]["CollegeShortName"].ToString();
                collegeModel.CollegeDescription = collegeDataTable.Rows[0]["CollegeDescription"].ToString();
                collegeModel.CollegeTypeID = Convert.ToInt32(collegeDataTable.Rows[0]["CollegeTypeID"].ToString());
                collegeModel.CollegeTypeName = collegeDataTable.Rows[0]["CollegeTypeName"].ToString();
                collegeModel.ApprovalID = Convert.ToInt32(collegeDataTable.Rows[0]["ApprovalID"].ToString());
                collegeModel.ApprovalName = collegeDataTable.Rows[0]["ApprovalName"].ToString();
                collegeModel.ApprovalShortName = collegeDataTable.Rows[0]["ApprovalShortName"].ToString();
                collegeModel.AboutCourses = collegeDataTable.Rows[0]["AboutCourses"].ToString();
                collegeModel.AboutPlacement = collegeDataTable.Rows[0]["AboutPlacement"].ToString();
                collegeModel.Established = Convert.ToInt32(collegeDataTable.Rows[0]["Established"].ToString());
                collegeModel.IsUniversity = Convert.ToBoolean(collegeDataTable.Rows[0]["IsUniversity"].ToString());
                collegeModel.CampusType = collegeDataTable.Rows[0]["CampusType"].ToString();
                collegeModel.CampusArea = collegeDataTable.Rows[0]["CampusArea"].ToString();
                collegeModel.Email = collegeDataTable.Rows[0]["Email"].ToString();
                collegeModel.Phone = collegeDataTable.Rows[0]["Phone"].ToString();
                collegeModel.Website = collegeDataTable.Rows[0]["Website"].ToString();
                collegeModel.Address = collegeDataTable.Rows[0]["Address"].ToString();
                collegeModel.CityID = Convert.ToInt32(collegeDataTable.Rows[0]["CityID"].ToString());
                collegeModel.CityName = collegeDataTable.Rows[0]["CityName"].ToString();
                collegeModel.StateID = Convert.ToInt32(collegeDataTable.Rows[0]["StateID"].ToString());
                collegeModel.StateName = collegeDataTable.Rows[0]["StateName"].ToString();
                collegeModel.CountryID = Convert.ToInt32(collegeDataTable.Rows[0]["CountryID"].ToString());
                collegeModel.CountryName = collegeDataTable.Rows[0]["CountryName"].ToString();

                return collegeModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Method : GET DATATABLE OF INS_COLLEGE ...
        public DataTable PR_SELECT_RECORDS_INS_COLLEGE_DATATABLE()
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_INS_COLLEGE_SELECT_RECORDS");
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

        #region Method : INSERT RECORD OF COLLEGE ...
        public Boolean PR_INSERT_RECORD_INS_COLLEGE(INS_CollegeModel collegeModel)
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_INS_COLLEGE_INSERT_RECORD");
                sqlDB.AddInParameter(dbCommand, "", SqlDbType.NVarChar, collegeModel.CollegeLogo.ToString());
                sqlDB.AddInParameter(dbCommand, "", SqlDbType.NVarChar, collegeModel.CollegeName.ToString());
                sqlDB.AddInParameter(dbCommand, "", SqlDbType.NVarChar, collegeModel.CollegeShortName.ToString());
                sqlDB.AddInParameter(dbCommand, "", SqlDbType.NVarChar, collegeModel.CollegeDescription.ToString());
                sqlDB.AddInParameter(dbCommand, "", SqlDbType.Int, Convert.ToInt32(collegeModel.CollegeTypeID.ToString()));
                sqlDB.AddInParameter(dbCommand, "", SqlDbType.Int, Convert.ToInt32(collegeModel.ApprovalID.ToString()));
                sqlDB.AddInParameter(dbCommand, "", SqlDbType.Int, Convert.ToInt32(collegeModel.Established.ToString()));
                sqlDB.AddInParameter(dbCommand, "", SqlDbType.Bit, Convert.ToBoolean(collegeModel.IsUniversity.ToString()));
                sqlDB.AddInParameter(dbCommand, "", SqlDbType.NVarChar, collegeModel.CampusType.ToString());
                sqlDB.AddInParameter(dbCommand, "", SqlDbType.NVarChar, collegeModel.CampusArea.ToString());
                sqlDB.AddInParameter(dbCommand, "", SqlDbType.NVarChar, collegeModel.Email.ToString());
                sqlDB.AddInParameter(dbCommand, "", SqlDbType.NVarChar, collegeModel.Phone.ToString());
                sqlDB.AddInParameter(dbCommand, "", SqlDbType.NVarChar, collegeModel.Website.ToString());
                sqlDB.AddInParameter(dbCommand, "", SqlDbType.NVarChar, collegeModel.Address.ToString());
                sqlDB.AddInParameter(dbCommand, "", SqlDbType.Int, collegeModel.CityID.ToString());

                return true;
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
