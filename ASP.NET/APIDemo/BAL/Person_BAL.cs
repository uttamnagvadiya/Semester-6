using APIDemo.DAL;
using APIDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace APIDemo.BAL
{
    public class Person_BAL
    {
        Person_DAL person_DAL = new Person_DAL();

        #region Method : GET ALL RECORDS ...
        public List<PersonModel> PR_SELECT_ALL_PERSON()
        {
            try
            {
                List<PersonModel> personModels = person_DAL.PR_SELECT_ALL_PERSON();
                return personModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : GET RECORD BY ID ...
        public PersonModel PR_SELECT_BY_PK_PERSON(int PersonID)
        {
            try
            {
                PersonModel personModel = person_DAL.PR_SELECT_BY_PK_PERSON(PersonID);
                return personModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : DELETE RECORD BY ID ...
        public int PR_DELETE_BY_PK_PERSON(int PersonID)
        {
            try
            {
                return person_DAL.PR_DELETE_BY_PK_PERSON(PersonID);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region Method : INSERT RECORD ...
        public int PR_INSERT_RECORD_PERSON(string PersonName, string Email, string Phone)
        {
            try
            {
                return person_DAL.PR_INSERT_RECORD_PERSON(PersonName, Email, Phone);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region Method : UPDATE RECORD BY ID ...
        public int PR_UPDATE_RECORD_BY_PK_PERSON(int PersonID, string PersonName, string Email, string Phone)
        {
            try
            {
                return person_DAL.PR_UPDATE_RECORD_BY_PK_PERSON(PersonID, PersonName, Email, Phone);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion
    }
}
