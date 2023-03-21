using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationGameCenter.Interfaces;
using WebApplicationGameCenter.Models;

namespace WebApplicationGameCenter.DAL
{
    internal class ReservationRepository : ICRUDRepository<Reservation>
    {
        private readonly GameCenterDatabaseContext _context;

        public ReservationRepository(GameCenterDatabaseContext context)
        {
            _context = context;
        }

        // Create CRUD for reservation class
        public void Create(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }

        Reservation ICRUDRepository<Reservation>.GetById(string id)
        {
            throw new NotImplementedException();
        }


        public List<Reservation> GetAll()
        {
            return _context.Reservations.ToList();
        }

        public void Update(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
        }

        public void Delete(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }

        // create method to get reservation by composite id
        public Reservation GetByCompositeId(string id, DateTime dateTime)
        {
            return _context.Reservations.Find(id, dateTime);
        }

    }
}
