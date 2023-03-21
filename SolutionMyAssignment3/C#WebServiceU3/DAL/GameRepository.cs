using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationGameCenter.Interfaces;
using WebApplicationGameCenter.Models;

namespace WebApplicationGameCenter.DAL
{
    internal class GameRepository : ICRUDRepository<Game>
    {
        private readonly GameCenterDatabaseContext _context;

        public GameRepository(GameCenterDatabaseContext context)
        {
            _context = context;
        }

        // Create CRUD methods for Game class
        public void Create(Game game)
        {
            try
            {
                _context.Games.Add(game);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Game GetById(String id)
        {
            try
            {
                return _context.Games.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Game> GetAll()
        {
            try
            {
                return _context.Games.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Game game)
        {
            try
            {
                _context.Games.Update(game);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Game game)
        {
            try
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        Game ICRUDRepository<Game>.GetByCompositeId(string id, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

    }
}
