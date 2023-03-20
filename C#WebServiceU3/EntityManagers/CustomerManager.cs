using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplicationGameCenter.DAL;
using WebApplicationGameCenter.Interfaces;
using WebApplicationGameCenter.Models;

namespace WebApplicationGameCenter.EntityManagers
{
    internal class CustomerManager : IEntityManager
    {
        private static GameCenterDatabaseContext _context = new GameCenterDatabaseContext();


        public string Load()
        {
            try
            {
                ICRUDRepository<Customer> customerRepository = new CustomerRepository(_context);
                var customers = customerRepository.GetAll();

                return string.Join(Environment.NewLine, customers.Select(c => $"{c.CustomerId} || {c.Name} || {c.Adress} || {c.Phonenumber} || {c.Email} || {c.LoyaltyLevel}. -->"));
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

                ICRUDRepository<Customer> customerRepository = new CustomerRepository(_context);
                var customer = customerRepository.GetById(idDelete);

                if (customer == null)
                {
                    return false;
                }

                customerRepository.Delete(customer);
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
                ICRUDRepository<Customer> customerRepository = new CustomerRepository(_context);

                var customerId = entityData.FirstOrDefault(x => x.Key == "CustomerId")?.Value;
                var name = entityData.FirstOrDefault(x => x.Key == "Name")?.Value;
                var address = entityData.FirstOrDefault(x => x.Key == "Address")?.Value;
                var phoneNumber = entityData.FirstOrDefault(x => x.Key == "PhoneNumber")?.Value;
                var email = entityData.FirstOrDefault(x => x.Key == "Email")?.Value;
                var loyaltyLevel = entityData.FirstOrDefault(x => x.Key == "LoyaltyLevel")?.Value;

                if (string.IsNullOrWhiteSpace(customerId) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(loyaltyLevel))
                {
                    return false;
                }

                if (customerRepository.GetById(customerId) != null)
                {
                    return false;
                }

                if (!int.TryParse(loyaltyLevel, out int loyaltyLevelValue))
                {
                    return false;
                }

                var customer = new Customer
                {
                    CustomerId = customerId,
                    Name = name,
                    Adress = address,
                    Phonenumber = phoneNumber,
                    Email = email,
                    LoyaltyLevel = loyaltyLevelValue
                };

                customerRepository.Create(customer);
                return true;
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }




    }
}
