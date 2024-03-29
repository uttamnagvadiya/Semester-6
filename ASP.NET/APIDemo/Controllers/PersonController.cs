﻿using APIDemo.BAL;
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

        #region DELETE RECORD BY ID ...
        [HttpDelete]
        public IActionResult Delete(int PersonID)
        {
            if (person_BAL.PR_DELETE_BY_PK_PERSON(PersonID) > 0)
            {
                return Ok("Record Deleted Successfully!");
            }
            return NotFound("Record not deleted!");
        }
        #endregion

        #region INSERT RECORD ...
        [HttpPost]
        public IActionResult Post([FromBody] PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                if (person_BAL.PR_INSERT_RECORD_PERSON(personModel) > 0)
                {
                    return Ok("Record inserted successfully!");
                }
            }
            return NotFound("Record not inserted!");
        }
        #endregion

        #region UPDATE RECORD BY ID ...
        [HttpPut("{PersonID}")]
        public IActionResult Put([FromBody] PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                if (person_BAL.PR_UPDATE_RECORD_BY_PK_PERSON(personModel) > 0)
                {
                    return Ok("Record updated successfully!");
                }
            }
            return NotFound("Record not updated!");
        }
        #endregion

        [HttpPost]
        public IActionResult UserPost([FromBody] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                    return Ok("Data validated successfully!");
            }
            return NotFound("Data not validate!");
        }

    }
}
