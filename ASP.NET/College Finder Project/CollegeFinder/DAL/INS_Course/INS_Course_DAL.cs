using CollegeFinder.Areas.INS_Course.Models;
using CollegeFinder.DAL.DAL_Helpers;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace CollegeFinder.DAL.INS_Course
{
    public class INS_Course_DAL : DAL_Helper
    {
        SqlDatabase sqlDB = new SqlDatabase(ConnectionString);

        #region Method : GET COURSE LIST ...
        public DataTable PR_SELECT_RECORDS_INS_COURSE()
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_INS_COURSE_SELECT_RECORDS");
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

        #region Method : GET RECORD BY ID ...
        public INS_CourseModel PR_SELECT_RECORD_BY_PK_INS_COURSE(int CourseID)
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_INS_COURSE_SELECT_RECORD_BY_PK");
                sqlDB.AddInParameter(dbCommand, "@CourseID", SqlDbType.Int, CourseID);
                DataTable dataTable = new DataTable();

                using (IDataReader reader = sqlDB.ExecuteReader(dbCommand))
                {
                    dataTable.Load(reader);
                }

                INS_CourseModel courseModel = new INS_CourseModel
                {
                    CourseID = Convert.ToInt32(dataTable.Rows[0]["CourseID"].ToString()),
                    CourseLogo = dataTable.Rows[0]["CourseLogo"].ToString(),
                    CourseName = dataTable.Rows[0]["CourseName"].ToString(),
                    CourseShortName = dataTable.Rows[0]["CourseShortName"].ToString(),
                    CourseDefinition = dataTable.Rows[0]["CourseDefinition"].ToString(),
                    CourseDescription = dataTable.Rows[0]["CourseDescription"].ToString(),
                    CourseDuration = dataTable.Rows[0]["CourseDuration"].ToString(),
                    CourseFees = dataTable.Rows[0]["CourseFees"].ToString(),
                    IsYearly = Convert.ToBoolean(dataTable.Rows[0]["IsYearly"].ToString()),
                    StreamID = Convert.ToInt32(dataTable.Rows[0]["StreamID"].ToString()),
                    StreamName = dataTable.Rows[0]["StreamName"].ToString(),
                };

                return courseModel;
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
                DbCommand dbCommand;
                if (courseModel.CourseID == null)
                {
                    dbCommand = sqlDB.GetStoredProcCommand("PR_INS_COURSE_INSERT_RECORD");
                }
                else
                {
                    dbCommand = sqlDB.GetStoredProcCommand("PR_INS_COURSE_UPDATE_RECORD");
                    sqlDB.AddInParameter(dbCommand, "@CourseID", SqlDbType.Int, courseModel.CourseID);
                }
                sqlDB.AddInParameter(dbCommand, "@CourseName", SqlDbType.NVarChar, courseModel.CourseName);
                sqlDB.AddInParameter(dbCommand, "@CourseShortName", SqlDbType.NVarChar, courseModel.CourseShortName);
                sqlDB.AddInParameter(dbCommand, "@CourseDefinition", SqlDbType.NVarChar, courseModel.CourseDefinition);
                sqlDB.AddInParameter(dbCommand, "@CourseDescription", SqlDbType.NVarChar, courseModel.CourseDescription);
                sqlDB.AddInParameter(dbCommand, "@CourseDuration", SqlDbType.NVarChar, courseModel.CourseDuration);
                sqlDB.AddInParameter(dbCommand, "@CourseFees", SqlDbType.NVarChar, courseModel.CourseFees);
                sqlDB.AddInParameter(dbCommand, "@IsYearly", SqlDbType.Bit, courseModel.IsYearly);
                sqlDB.AddInParameter(dbCommand, "@StreamID", SqlDbType.Int, courseModel.StreamID);

                return Convert.ToBoolean(sqlDB.ExecuteNonQuery(dbCommand)) ? true : false;
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
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_INS_COURSE_DELETE_RECORD");
                sqlDB.AddInParameter(dbCommand, "@CourseID", SqlDbType.Int, CourseID);

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
