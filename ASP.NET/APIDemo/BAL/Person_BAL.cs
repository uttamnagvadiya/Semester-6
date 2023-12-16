using APIDemo.DAL;
using APIDemo.Models;

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
    }
}
