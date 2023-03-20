using System;
using WebApplicationGameCenter.Interfaces;

namespace WebApplicationGameCenter.EntityManagers.EntityManagerFactory
{
    public class EntityManagerFactory
    {
        public static IEntityManager GetEntityManager(string entityName)
        {
            switch (entityName)
            {
                case "Employee":
                    return new EmployeeManager();
                case "Customer":
                    return new CustomerManager();
                case "Computer":
                    return new ComputerManager();
                case "Game":
                    return new GameManager();
                case "Login":
                    return new LoginManager();

                default:
                    throw new ArgumentException("Invalid entity name");
            }
        }

    }
}
