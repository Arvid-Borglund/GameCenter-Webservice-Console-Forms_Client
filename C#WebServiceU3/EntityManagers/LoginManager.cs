using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationGameCenter.DAL;
using WebApplicationGameCenter.Interfaces;
using WebApplicationGameCenter.Models;

namespace WebApplicationGameCenter.EntityManagers
{
    internal class LoginManager : IEntityManager
    {
        private static GameCenterDatabaseContext _context = new GameCenterDatabaseContext();
        public string Load()
        {
            try
            {
                ICRUDRepository<Login> loginRepository = new LoginRepository(_context);
                var logins = loginRepository.GetAll();

                return string.Join(Environment.NewLine, logins.Select(l => $"{l.LoginId} || {l.Password} || {l.CustomerId} || {l.EmployeeId} || {l.AccessLevel}. -->"));
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }





        public bool Create(List<KeyValuePairCustom> entityData)
        {
            try
            {
                ICRUDRepository<Login> loginRepository = new LoginRepository(_context);
                ICRUDRepository<Employee> employeeRepository = new EmployeeRepository(_context);
                ICRUDRepository<Customer> customerRepository = new CustomerRepository(_context);

                var loginId = entityData.FirstOrDefault(x => x.Key == "LoginId")?.Value;
                var password = entityData.FirstOrDefault(x => x.Key == "Password")?.Value;
                var customerId = entityData.FirstOrDefault(x => x.Key == "CustomerId")?.Value;
                var employeeId = entityData.FirstOrDefault(x => x.Key == "EmployeeId")?.Value;
                var accessLevel = entityData.FirstOrDefault(x => x.Key == "AccessLevel")?.Value;

                if (string.IsNullOrWhiteSpace(loginId) || string.IsNullOrWhiteSpace(password) || (string.IsNullOrWhiteSpace(customerId) && string.IsNullOrWhiteSpace(employeeId)) || string.IsNullOrWhiteSpace(accessLevel))
                {
                    return false;
                }

                if (loginRepository.GetAll().FirstOrDefault(l => l.LoginId == loginId) != null)
                {
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(customerId) && customerId.Trim().Length > 0 && !customerRepository.GetAll().Any(c => c.CustomerId == customerId.Trim()))
                {
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(employeeId) && employeeId.Trim().Length > 0 && !employeeRepository.GetAll().Any(e => e.EmployeeId == employeeId.Trim()))
                {
                    return false;
                }

                var login = new Login
                {
                    LoginId = loginId,
                    Password = password,
                    CustomerId = string.IsNullOrWhiteSpace(customerId) ? null : customerId.Trim(),
                    EmployeeId = string.IsNullOrWhiteSpace(employeeId) ? null : employeeId.Trim(),
                    AccessLevel = accessLevel
                };

                loginRepository.Create(login);
                return true;
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }





        public bool Delete(string idDelete)
        {
            try
            {
                ICRUDRepository<Login> loginRepository = new LoginRepository(_context);
                var login = loginRepository.GetById(idDelete);

                if (login == null)
                {
                    return false;
                }

                loginRepository.Delete(login);
                return true;
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }

    }
}
