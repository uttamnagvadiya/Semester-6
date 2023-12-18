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
                    reader.Read();
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

        #region Method : DELETE RECORD BY ID ...
        public int PR_DELETE_BY_PK_PERSON (int PersonID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(connectionString);
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("API_PERSON_DELETE_RECORD_BY_PK");
                sqlDB.AddInParameter(dbCommand, "@PersonID", SqlDbType.Int, PersonID);

                return sqlDB.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region Method : INSERT RECORD ...
        public int PR_INSERT_RECORD_PERSON(PersonModel personModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(connectionString);
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("API_PERSON_INSERT_RECORD");
                sqlDB.AddInParameter(dbCommand, "@PersonName", SqlDbType.VarChar, personModel.PersonName);
                sqlDB.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, personModel.Email);
                sqlDB.AddInParameter(dbCommand, "@Phone", SqlDbType.VarChar, personModel.Phone);

                return sqlDB.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region Method : UPDATE RECORD BY ID ...
        public int PR_UPDATE_RECORD_BY_PK_PERSON(PersonModel personModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(connectionString);
                DbCommand dbCommand = sqlDB.GetStoredProcCommand("API_PERSON_UPDATE_RECORD_BY_PK");
                sqlDB.AddInParameter(dbCommand, "@PersonID", SqlDbType.Int, personModel.PersonID);
                sqlDB.AddInParameter(dbCommand, "@PersonName", SqlDbType.VarChar, personModel.PersonName);
                sqlDB.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, personModel.Email);
                sqlDB.AddInParameter(dbCommand, "@Phone", SqlDbType.VarChar, personModel.Phone);

                return sqlDB.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion
    }
}
