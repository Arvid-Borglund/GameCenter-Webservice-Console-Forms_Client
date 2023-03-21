using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationGameCenter.Interfaces;
using WebApplicationGameCenter.Models;

namespace WebApplicationGameCenter.DAL
{
    internal class CustomerRepository : ICRUDRepository<Customer>
    {
        private readonly GameCenterDatabaseContext _context;

        public CustomerRepository(GameCenterDatabaseContext context)
        {
            _context = context;
            
        }

        public void Create(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Customer> GetAll()
        {
            try
            {
                return _context.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer GetById(string id)
        {
            try
            {
                return _context.Customers.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Update(Customer customer)
        {
            try
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Customer customer)
        {
            try
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        Customer ICRUDRepository<Customer>.GetByCompositeId(string id, DateTime dateTime)
        {
            throw new NotImplementedException();
        }


        
    }
}
