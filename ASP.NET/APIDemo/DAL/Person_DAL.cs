using APIDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace APIDemo.DAL
{
    public class Person_DAL : DAL_Helpers
    {
        #region Method : GET ALL RECORDS ...
        public List<PersonModel> PR_SELECT_ALL_PERSON()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(connectionString);
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("API_PERSON_SELECT_ALL");
                List<PersonModel> personModels = new List<PersonModel>();
                using (IDataReader reader = sqlDB.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        PersonModel personModel = new PersonModel();
                        personModel.PersonID = Convert.ToInt32(reader["PersonID"].ToString());
                        personModel.PersonName = reader["PersonName"].ToString();
                        personModel.Email = reader["Email"].ToString();
                        personModel.Phone = reader["Phone"].ToString();
                        personModels.Add(personModel);
                    }
                }
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
                SqlDatabase sqlDB = new SqlDatabase(connectionString);
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("API_PERSON_SELECT_BY_PK");
                sqlDB.AddInParameter(dbCommand, "@PersonID", SqlDbType.Int, PersonID);
                PersonModel personModel = new PersonModel();
                using (IDataReader reader = sqlDB.ExecuteReader(dbCommand))
                {
                    personModel.PersonID = Convert.ToInt32(reader["PersonID"].ToString());
                    personModel.PersonName = reader["PersonName"].ToString();
                    personModel.Email = reader["Email"].ToString();
                    personModel.Phone = reader["Phone"].ToString();
                }
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
