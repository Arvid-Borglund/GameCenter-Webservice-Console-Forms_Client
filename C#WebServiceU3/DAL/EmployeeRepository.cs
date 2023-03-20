using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationGameCenter.Interfaces;
using WebApplicationGameCenter.Models;

namespace WebApplicationGameCenter.DAL
{
    internal class EmployeeRepository : ICRUDRepository<Employee>
    {
        private readonly GameCenterDatabaseContext _context;

        public EmployeeRepository(GameCenterDatabaseContext context)
        {
            _context = context;
           
        }


        public void Create(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }

        public Employee GetById(String id)
        {
            try
            {
                return _context.Employees.Find(id);
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }

        public List<Employee> GetAll()
        {
            try
            {
                return _context.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }

        public void Update(Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }

        public void Delete(Employee employee)
        {
            try
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }


        Employee ICRUDRepository<Employee>.GetByCompositeId(string id, DateTime dateTime)
        {
            throw new NotImplementedException();
        }



    }
}
