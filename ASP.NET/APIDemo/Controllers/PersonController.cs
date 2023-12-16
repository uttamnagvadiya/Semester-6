using APIDemo.BAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class PersonController : Controller
    {
        Person_BAL person_BAL = new Person_BAL();

        #region GET ALL RECORDS ...
        [HttpGet]
        public IActionResult Get()
        {
            List<PersonModel> data = person_BAL.PR_SELECT_ALL_PERSON();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (data.Count > 0 && data != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", data);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region GET RECORD BY ID ...
        [HttpGet("{PersonID}")]
        public IActionResult Get(int PersonID)
        {
            PersonModel data = person_BAL.PR_SELECT_BY_PK_PERSON(PersonID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (data.PersonID != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", data);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion
    }
}
