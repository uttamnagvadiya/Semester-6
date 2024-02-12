using CollegeFinder.Areas.INS_Streams.Models;
using CollegeFinder.DAL.INS_Streams;

namespace CollegeFinder.BAL.INS_Streams
{
    public class INS_Streams_BAL
    {
        INS_Streams_DAL stream_DAL = new INS_Streams_DAL();

        #region Method : GET ALL RECORDS OF INS_STREAMS ...
        public List<INS_StreamModel> PR_SELECT_RECORDS_INS_STREAMS()
        {
            try
            {
                return stream_DAL.PR_SELECT_RECORDS_INS_STREAMS();
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
                return stream_DAL.PR_SELECT_RECORD_BY_PK_INS_STREAMS(StreamID: StreamID);
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
