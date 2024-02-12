using CollegeFinder.Areas.MST_Location.Models;
using CollegeFinder.BAL;
using CollegeFinder.BAL.MST_Location.LOC_City;
using CollegeFinder.BAL.MST_Location.LOC_COUNTRY;
using CollegeFinder.BAL.MST_Location.LOC_State;
using Microsoft.AspNetCore.Mvc;

namespace CollegeFinder.Areas.MST_Location.Controllers
{
    [CheckAccess]
    [Area("MST_Location")]
    public class LOC_CityController : Controller
    {
        LOC_City_BAL city_BAL = new LOC_City_BAL();
        MST_LocationViewModel viewModel = new MST_LocationViewModel();

        #region ... Get City List ...
        public IActionResult Index()
        {
            try
            {
                viewModel.CityModelsList = city_BAL.PR_SELECT_RECORDS_LOC_CITY();
                viewModel.StateModelsList = new LOC_State_BAL().PR_SELECT_RECORDS_LOC_STATE();
                viewModel.CountryModelsList = new LOC_Country_BAL().PR_SELECT_RECORDS_LOC_COUNTRY();

                return View("LOC_City", viewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return View("LOC_City");
            }
        }
        #endregion

        #region ... Update City Record ...
        public IActionResult Update(int CityID)
        {
            try
            {
                viewModel.CityModelsList = city_BAL.PR_SELECT_RECORDS_LOC_CITY();
                viewModel.CityModel = city_BAL.PR_SELECT_RECORD_BY_PK_LOC_CITY(CityID: CityID);
                viewModel.StateModelsList = new LOC_State_BAL().PR_SELECT_RECORDS_BY_FK_LOC_STATE((int)viewModel.CityModel.CountryID);
                viewModel.CountryModelsList = new LOC_Country_BAL().PR_SELECT_RECORDS_LOC_COUNTRY();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return View("LOC_City");
            }

            return View("LOC_City", viewModel);
        }
        #endregion

        #region ... Save City Record ...
        public IActionResult Save(LOC_CityModel cityModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    city_BAL.PR_INSERT_UPDATE_RECORD_LOC_CITY(cityModel: cityModel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Message :: {ex.Message}");
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region ... Delete City Record ...
        public IActionResult Delete(int CityID)
        {
            try
            {
                city_BAL.PR_DELELTE_RECORD_LOC_CITY(CityID: CityID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}
