using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebApplicationGameCenter.DAL;
using WebApplicationGameCenter.DAL.SqlExceptionHandler;
using WebApplicationGameCenter.EntityManagers.EntityManagerFactory;
using WebApplicationGameCenter.Interfaces;
using WebApplicationGameCenter.Models;


namespace WebApplicationGameCenter
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebServiceGameCenter : System.Web.Services.WebService
    {
        private static GameCenterDatabaseContext _context = new GameCenterDatabaseContext();
        private static string errorMessageStatic = "";

        [WebMethod]
        public bool VerifyCredentials(string id, string loginPassword, out string role)
        {
            role = null;
            try
            {
                ICRUDRepository<Login> loginRepository = new LoginRepository(_context);
                var login = loginRepository.GetById(id);

                if (login == null || login.Password != loginPassword)
                {
                    return false;
                }

                role = login.AccessLevel;
                return true;
            }

            catch (Exception ex)
            {
                string errorMessage = SqlExHandler.HandleSqlException(ex);

                errorMessageStatic = errorMessage;

                return false;
            }
        }


        [WebMethod]
        public string VerifyCredentialsJava(string id, string loginPassword)
        {
            try
            {
                ICRUDRepository<Login> loginRepository = new LoginRepository(_context);
                Login login = loginRepository.GetById(id);

                if (login == null || login.Password != loginPassword)
                {
                    return null;
                }

                return login.AccessLevel;
            }
            catch (Exception ex)
            {
                string errorMessage = SqlExHandler.HandleSqlException(ex);

                errorMessageStatic = errorMessage;

                return null;
            }
        }


        [WebMethod]
        public string GetSelectedEntityData(string selectedEntityCon, string role)
        {
            try
            {
                if (selectedEntityCon == "Login" && role != "Admin")
                {
                    return "Only Admins can access the login-credentials page. Please select another page.";
                }

                IEntityManager entityManager = EntityManagerFactory.GetEntityManager(selectedEntityCon);
                return entityManager.Load();
            }
            catch (Exception ex)
            {
                string errorMessage = SqlExHandler.HandleSqlException(ex);

                errorMessageStatic = errorMessage;

                return null;
            }
        }


        [WebMethod]
        public bool Create(List<KeyValuePairCustom> entityData, string selectedEntityCon, string role)
        {
            if (selectedEntityCon == "Login" && role != "Admin")
            {
                return false;
            }

            try
            {
                IEntityManager entityManager = EntityManagerFactory.GetEntityManager(selectedEntityCon);
                return entityManager.Create(entityData);
            }
            catch (Exception ex)
            {
                string errorMessage = SqlExHandler.HandleSqlException(ex);

                errorMessageStatic = errorMessage;

                return false;
            }
        }



        [WebMethod]
        public bool Delete(string idDelete, string selectedEntityCon, string role)
        {
            if (selectedEntityCon == "Login" && role != "Admin")
            {
                return false;
            }

            try
            {
                IEntityManager entityManager = EntityManagerFactory.GetEntityManager(selectedEntityCon);
                return entityManager.Delete(idDelete);
            }
            catch (Exception ex)
            {
                string errorMessage = SqlExHandler.HandleSqlException(ex);

                errorMessageStatic = errorMessage;

                return false;
            }
        }

        [WebMethod]
        public string GetErrorMessage()
        {
            // Retrieve the error message from the static variable
            string errorMessage = errorMessageStatic;

            // Clear the error message from the static variable
            errorMessageStatic = "";

            return errorMessage;
        }

        [WebMethod]
        public string TryErrorHandling()
        {
            try
            {
                throw new MyCustomSqlException(4060);
            }
            catch (MyCustomSqlException ex)
            {
                // handle the custom SQL exception
                errorMessageStatic = SqlExHandler.HandleSqlException(ex);
            }
            catch (Exception ex)
            {
                // handle all other exceptions
                errorMessageStatic = "An error occurred while verifying credentials.";
            }

        return "Handling works";
        }

    }
}
