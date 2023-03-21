using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationGameCenter.Interfaces;
using WebApplicationGameCenter.Models;

namespace WebApplicationGameCenter.DAL
{
    internal class LoginRepository : ICRUDRepository<Login>
    {
        private readonly GameCenterDatabaseContext _context;

        public LoginRepository(GameCenterDatabaseContext context)
        {
            _context = context;
        }

        // Create CRUD for login class

        public void Create(Login login)
        {
            try
            {
                _context.Logins.Add(login);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }

        public Login GetById(string id)
        {
            try
            {
                return _context.Logins.Find(id);
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }
        

        public List<Login> GetAll()
        {
            try
            {
                return _context.Logins.ToList();
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }

        public void Update(Login login)
        {
            try
            {
                _context.Logins.Update(login);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }

        public void Delete(Login login)
        {
            try
            {
                _context.Logins.Remove(login);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }


        Login ICRUDRepository<Login>.GetByCompositeId(string id, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

    }
}
