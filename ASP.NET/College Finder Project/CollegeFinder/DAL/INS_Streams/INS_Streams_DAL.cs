using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using CollegeFinder.DAL.DAL_Helpers;
using CollegeFinder.Areas.INS_Streams.Models;
using System.Data.Common;
using System.Data;

namespace CollegeFinder.DAL.INS_Streams
{
    public class INS_Streams_DAL : DAL_Helper
    {
        SqlDatabase sqlDB = new SqlDatabase(ConnectionString);

        #region Method : GET ALL RECORDS OF INS_STREAMS ...
        public List<INS_StreamModel> PR_SELECT_RECORDS_INS_STREAMS()
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_INS_STREAMS_SELECT_RECORDS");
                DataTable dataTable = new DataTable();

                using (IDataReader reader = sqlDB.ExecuteReader(dbCommand))
                {
                    dataTable.Load(reader);
                }

                List<INS_StreamModel> streamModelsList = new List<INS_StreamModel>();
                foreach (DataRow item in dataTable.Rows)
                {
                    INS_StreamModel streamModel = new INS_StreamModel
                    {
                        StreamID = Convert.ToInt32(item["StreamID"].ToString()),
                        StreamName = item["StreamName"].ToString(),
                        CreatedDate = Convert.ToDateTime(item["CreatedDate"].ToString()),
                        ModifiedDate = Convert.ToDateTime(item["ModifiedDate"].ToString()),
                    };

                    streamModelsList.Add(streamModel);
                }

                return streamModelsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Method : GET STREAM DETAILS BY STREAM ID ...
        public INS_StreamModel PR_SELECT_RECORD_BY_PK_INS_STREAMS(int StreamID)
        {
            try
            {
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("PR_INS_STREAMS_SELECT_RECORDS");
                sqlDB.AddInParameter(dbCommand, "@StreamID", SqlDbType.Int, StreamID);
                DataTable streamDataTable = new DataTable();

                using (IDataReader reader = sqlDB.ExecuteReader(dbCommand))
                {
                    streamDataTable.Load(reader);
                }

                INS_StreamModel streamModel = new INS_StreamModel
                {
                    StreamID = Convert.ToInt32(streamDataTable.Rows[0]["StreamID"].ToString()),
                    StreamName = streamDataTable.Rows[0]["StreamName"].ToString(),
                    StreamDescription = streamDataTable.Rows[0]["StreamDescription"].ToString(),
                    CreatedDate = Convert.ToDateTime(streamDataTable.Rows[0]["CreatedDate"].ToString()),
                    ModifiedDate = Convert.ToDateTime(streamDataTable.Rows[0]["ModifiedDate"].ToString()),
                };
                return streamModel;
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
