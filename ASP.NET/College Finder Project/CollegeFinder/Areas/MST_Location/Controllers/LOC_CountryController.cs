using CollegeFinder.Areas.MST_Location.Models;
using CollegeFinder.BAL;
using CollegeFinder.BAL.MST_Location.LOC_COUNTRY;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CollegeFinder.Areas.MST_Location.Controllers
{
    [CheckAccess]
    [Area("MST_Location")]
    public class LOC_CountryController : Controller
    {
        LOC_Country_BAL country_BAL = new LOC_Country_BAL();
        MST_LocationViewModel viewModel = new MST_LocationViewModel();

        #region ... Get Country List ...
        public IActionResult Index()
        {
            try
            {
                viewModel.CountryModelsList = country_BAL.PR_SELECT_RECORDS_LOC_COUNTRY();
                return View("LOC_Country", viewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return View("LOC_Country");
            }
        }
        #endregion

        #region ... Update Country Record ...
        public IActionResult Update(int CountryID)
        {
            try
            {
                viewModel.CountryModelsList = country_BAL.PR_SELECT_RECORDS_LOC_COUNTRY();
                viewModel.CountryModel = country_BAL.PR_SELECT_RECORD_BY_PK_LOC_COUNTRY(CountryID: Convert.ToInt32(CountryID.ToString()));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return View("LOC_Country");
            }
            return View("LOC_Country", viewModel);
        }
        #endregion

        #region ... Save Country Record ...
        public IActionResult Save(LOC_CountryModel countryModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    country_BAL.PR_INSERT_UPDATE_RECORD_LOC_COUNTRY(countryModel: countryModel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Message : {ex.Message}");
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region ... Delete Country Record ...
        public IActionResult Delete(int CountryID)
        {
            try
            {
                country_BAL.PR_DELELTE_RECORD_LOC_COUNTRY(CountryID: CountryID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message : {ex.Message}");
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}
