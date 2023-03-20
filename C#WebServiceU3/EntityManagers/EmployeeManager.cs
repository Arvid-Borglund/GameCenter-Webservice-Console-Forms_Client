using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplicationGameCenter.DAL;
using WebApplicationGameCenter.Interfaces;
using WebApplicationGameCenter.Models;

namespace WebApplicationGameCenter.EntityManagers
{
    internal class EmployeeManager : IEntityManager
    {
        private static GameCenterDatabaseContext _context = new GameCenterDatabaseContext();

        public string Load()
        {
            try
            {
                ICRUDRepository<Employee> employeeRepository = new EmployeeRepository(_context);
                var employees = employeeRepository.GetAll();

                return string.Join(Environment.NewLine, employees.Select(e => $"{e.EmployeeId} || {e.Name} || {e.Adress} || {e.Phonenumber} || {e.Email} || {e.HireDate.ToString("yyyy-MM-dd")} || {e.JobTitle}. -->"));

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
                ICRUDRepository<Employee> employeeRepository = new EmployeeRepository(_context);
                var employee = employeeRepository.GetById(idDelete);

                if (employee == null)
                {
                    return false;
                }

                employeeRepository.Delete(employee);
                return true;
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
                ICRUDRepository<Employee> employeeRepository = new EmployeeRepository(_context);

                var employeeId = entityData.FirstOrDefault(x => x.Key == "EmployeeId")?.Value;
                var name = entityData.FirstOrDefault(x => x.Key == "Name")?.Value;
                var address = entityData.FirstOrDefault(x => x.Key == "Address")?.Value;
                var phoneNumber = entityData.FirstOrDefault(x => x.Key == "PhoneNumber")?.Value;
                var email = entityData.FirstOrDefault(x => x.Key == "Email")?.Value;
                var jobTitle = entityData.FirstOrDefault(x => x.Key == "JobTitle")?.Value;

                if (string.IsNullOrWhiteSpace(employeeId) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(jobTitle))
                {
                    return false;
                }

                if (employeeRepository.GetAll().FirstOrDefault(e => e.EmployeeId == employeeId) != null)
                {
                    return false;
                }

                var employee = new Employee
                {
                    EmployeeId = employeeId,
                    Name = name,
                    Adress = address,
                    Phonenumber = phoneNumber,
                    Email = email,
                    HireDate = DateTime.Today,
                    JobTitle = jobTitle
                };

                employeeRepository.Create(employee);
                return true;
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }





    }
}
