using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationGameCenter.DAL;
using WebApplicationGameCenter.Interfaces;
using WebApplicationGameCenter.Models;

namespace WebApplicationGameCenter.EntityManagers
{
    internal class ComputerManager : IEntityManager
    {
        private static GameCenterDatabaseContext _context = new GameCenterDatabaseContext();
        public string Load()
        {
            try
            {
                ICRUDRepository<Computer> computerRepository = new ComputerRepository(_context);
                var computers = computerRepository.GetAll();
                return string.Join(Environment.NewLine, computers.Select(c => $"{c.ComputerId} || {c.Cpu} || {c.Gpu} || {c.Ram} || {c.DataStorage}. -->"));
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
                ICRUDRepository<Computer> computerRepository = new ComputerRepository(_context);

                var computerId = entityData.FirstOrDefault(x => x.Key == "ComputerId")?.Value;
                var cpu = entityData.FirstOrDefault(x => x.Key == "Cpu")?.Value;
                var gpu = entityData.FirstOrDefault(x => x.Key == "Gpu")?.Value;
                var ram = entityData.FirstOrDefault(x => x.Key == "Ram")?.Value;
                var dataStorage = entityData.FirstOrDefault(x => x.Key == "DataStorage")?.Value;

                if (string.IsNullOrWhiteSpace(computerId) || string.IsNullOrWhiteSpace(cpu) || string.IsNullOrWhiteSpace(gpu) || string.IsNullOrWhiteSpace(ram) || string.IsNullOrWhiteSpace(dataStorage))
                {
                    return false;
                }

                if (computerRepository.GetById(computerId) != null)
                {
                    return false;
                }

                if (!int.TryParse(ram, out int ramValue))
                {
                    return false;
                }

                var computer = new Computer
                {
                    ComputerId = computerId,
                    Cpu = cpu,
                    Gpu = gpu,
                    Ram = ramValue,
                    DataStorage = dataStorage
                };

                computerRepository.Create(computer);
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
                ICRUDRepository<Computer> computerRepository = new ComputerRepository(_context);
                var computer = computerRepository.GetById(idDelete);

                if (computer == null)
                {
                    return false;
                }

                computerRepository.Delete(computer);
                return true;
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }


    }
}
