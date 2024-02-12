using CollegeFinder.Areas.MST_Location.Models;
using CollegeFinder.DAL.MST_Location.LOC_Country;
using System.Data;

namespace CollegeFinder.BAL.MST_Location.LOC_COUNTRY
{
    public class LOC_Country_BAL
    {
        LOC_Country_DAL country_DAL = new LOC_Country_DAL();

        #region Method : GET ALL RECODRS OF COUNTRY ...
        public List<LOC_CountryModel> PR_SELECT_RECORDS_LOC_COUNTRY()
        {
            try
            {
                return country_DAL.PR_SELECT_RECORDS_LOC_COUNTRY();
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
                return country_DAL.PR_SELECT_RECORD_BY_PK_LOC_COUNTRY(CountryID: CountryID);
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
                return country_DAL.PR_INSERT_UPDATE_RECORD_LOC_COUNTRY(countryModel: countryModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return false;
            }
        }
        #endregion

        #region Method : DELETE RECORD OF COUNTRY ...
        public Boolean PR_DELELTE_RECORD_LOC_COUNTRY(int CountryID)
        {
            try
            {
                return country_DAL.PR_DELETE_RECORD_LOC_COUNTRY(CountryID: CountryID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return false;
            }
        }

        internal LOC_CountryModel? PR_SELECT_RECORD_BY_PK_LOC_COUNTRY(int? CountryID)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
