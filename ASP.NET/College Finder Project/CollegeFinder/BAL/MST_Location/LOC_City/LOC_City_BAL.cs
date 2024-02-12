using CollegeFinder.Areas.MST_Location.Models;
using CollegeFinder.DAL.MST_Location.LOC_City;

namespace CollegeFinder.BAL.MST_Location.LOC_City
{
    public class LOC_City_BAL
    {
        LOC_City_DAL city_DAL = new LOC_City_DAL();

        #region Method : GET ALL RECODRS OF CITY ...
        public List<LOC_CityModel> PR_SELECT_RECORDS_LOC_CITY()
        {
            try
            {
                return city_DAL.PR_SELECT_RECORDS_LOC_CITY();
            }
            catch(Exception ex)
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
                return city_DAL.PR_SELECT_RECORD_BY_PK_LOC_CITY(CityID: CityID);
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
                return city_DAL.PR_INSERT_UPDATE_RECORD_LOC_CITY(cityModel: cityModel);
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
                return city_DAL.PR_DELELTE_RECORD_LOC_CITY(CityID: CityID);
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
