using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationGameCenter.Interfaces;
using WebApplicationGameCenter.Models;

namespace WebApplicationGameCenter.DAL
{
    internal class ComputerRepository : ICRUDRepository<Computer>
    {
        private readonly GameCenterDatabaseContext _context;

        public ComputerRepository(GameCenterDatabaseContext context)
        {
            _context = context;


        }

        public void Create(Computer computer)
        {
            try
            {
                _context.Computers.Add(computer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }

        public List<Computer> GetAll()
        {
            try
            {
                return _context.Computers.ToList();
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }

        public Computer GetById(String id)
        {
            try
            {
                return _context.Computers.Find(id);
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }

        public void Update(Computer computer)
        {
            try
            {
                _context.Computers.Update(computer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }

        public void Delete(Computer computer)
        {
            try
            {
                _context.Computers.Remove(computer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }

        Computer ICRUDRepository<Computer>.GetByCompositeId(string id, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

    }
}
