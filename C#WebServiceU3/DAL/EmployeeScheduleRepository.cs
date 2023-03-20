using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationGameCenter.Interfaces;
using WebApplicationGameCenter.Models;

namespace WebApplicationGameCenter.DAL
{
    internal class EmployeeScheduleRepository : ICRUDRepository<EmployeeSchedule>
    {
        private readonly GameCenterDatabaseContext _context;

        public EmployeeScheduleRepository(GameCenterDatabaseContext context)
        {
            _context = context;
        }
        // create CRUD for employee schedule class
        public void Create(EmployeeSchedule employeeSchedule)
        {
            _context.EmployeeSchedules.Add(employeeSchedule);
            _context.SaveChanges();
        }


        EmployeeSchedule ICRUDRepository<EmployeeSchedule>.GetById(string id)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeSchedule> GetAll()
        {
            return _context.EmployeeSchedules.ToList();
        }

        public void Update(EmployeeSchedule employeeSchedule)
        {
            _context.EmployeeSchedules.Update(employeeSchedule);
            _context.SaveChanges();
        }

        public void Delete(EmployeeSchedule employeeSchedule)
        {
            _context.EmployeeSchedules.Remove(employeeSchedule);
            _context.SaveChanges();
        }

        // create find by composite id method

        public EmployeeSchedule GetByCompositeId(string id, DateTime dateTime)
        {
            return _context.EmployeeSchedules.Find(id, dateTime);
        }


    }
}
