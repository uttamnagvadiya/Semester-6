using CollegeFinder.Areas.MST_Location.Models;
using CollegeFinder.BAL;
using CollegeFinder.BAL.MST_Location.LOC_COUNTRY;
using CollegeFinder.BAL.MST_Location.LOC_State;
using Microsoft.AspNetCore.Mvc;

namespace CollegeFinder.Areas.MST_Location.Controllers
{
    [CheckAccess]
    [Area("MST_Location")]
    public class LOC_StateController : Controller
    {
        LOC_State_BAL state_BAL = new LOC_State_BAL();
        MST_LocationViewModel viewModel = new MST_LocationViewModel();

        #region ... Get State List ...
        public IActionResult Index()
        {
            try
            {
                viewModel.StateModelsList = state_BAL.PR_SELECT_RECORDS_LOC_STATE();
                viewModel.CountryModelsList = new LOC_Country_BAL().PR_SELECT_RECORDS_LOC_COUNTRY();
                return View("LOC_State", viewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return View("LOC_State");
            }
        }
        #endregion

        #region ... Get State List by Country ID ...
        public IActionResult GetStateListByCountryID(int CountryID)
        {
            try
            {
                List<LOC_StateModel> stateListByCountry = state_BAL.PR_SELECT_RECORDS_BY_FK_LOC_STATE(CountryID: CountryID);
                return Json(stateListByCountry);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region ... Update State Record ...
        public IActionResult Update(int StateID)
        {
            try
            {
                viewModel.StateModelsList = state_BAL.PR_SELECT_RECORDS_LOC_STATE();
                viewModel.CountryModelsList = new LOC_Country_BAL().PR_SELECT_RECORDS_LOC_COUNTRY();
                viewModel.StateModel = state_BAL.PR_SELECT_RECORD_BY_PK_LOC_STATE(StateID: Convert.ToInt32(StateID.ToString()));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message :: {ex.Message}");
                return View("LOC_State");
            }
            return View("LOC_State", viewModel);
        }
        #endregion

        #region ... Save State Record ...
        public IActionResult Save(LOC_StateModel stateModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    state_BAL.PR_INSERT_UPDATE_RECORD_LOC_STATE(stateModel: stateModel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Message : {ex.Message}");
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region ... Delete State Record ...
        public IActionResult Delete(int StateID)
        {
            try
            {
                state_BAL.PR_DELELTE_RECORD_LOC_STATE(StateID: StateID);
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
