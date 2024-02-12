using CollegeFinder.Areas.MST_Location.Models;
using CollegeFinder.DAL.MST_Location.LOC_State;

namespace CollegeFinder.BAL.MST_Location.LOC_State
{
    public class LOC_State_BAL
    {
        LOC_State_DAL state_DAL = new LOC_State_DAL();

        #region Method : GET ALL RECODRS OF STATE ...
        public List<LOC_StateModel> PR_SELECT_RECORDS_LOC_STATE()
        {
            try
            {
                return state_DAL.PR_SELECT_RECORDS_LOC_STATE();
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
                return state_DAL.PR_SELECT_RECORD_BY_PK_LOC_STATE(StateID: StateID);
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
                return state_DAL.PR_SELECT_RECORDS_BY_FK_LOC_STATE(CountryID: CountryID);
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
                return state_DAL.PR_INSERT_UPDATE_RECORD_LOC_STATE(stateModel: stateModel);
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
                return state_DAL.PR_DELELTE_RECORD_LOC_STATE(StateID: StateID);
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
