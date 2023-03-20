using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationGameCenter.DAL;
using WebApplicationGameCenter.Interfaces;
using WebApplicationGameCenter.Models;

namespace WebApplicationGameCenter.EntityManagers
{
    internal class GameManager : IEntityManager
    {
        private static GameCenterDatabaseContext _context = new GameCenterDatabaseContext();
        public string Load()
        {
            try
            {
                ICRUDRepository<Game> gameRepository = new GameRepository(_context);
                var games = gameRepository.GetAll();

                return string.Join(Environment.NewLine, games.Select(g => $"{g.GameId} || {g.ComputerId} || {g.Title} || {g.Genre}. -->"));
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
                ICRUDRepository<Game> gameRepository = new GameRepository(_context);
                var game = gameRepository.GetById(idDelete);

                if (game == null)
                {
                    return false;
                }

                gameRepository.Delete(game);
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
                ICRUDRepository<Game> gameRepository = new GameRepository(_context);
                ICRUDRepository<Computer> computerRepository = new ComputerRepository(_context);

                var gameId = entityData.FirstOrDefault(x => x.Key == "GameId")?.Value;
                var computerId = entityData.FirstOrDefault(x => x.Key == "ComputerId")?.Value;
                var title = entityData.FirstOrDefault(x => x.Key == "Title")?.Value;
                var genre = entityData.FirstOrDefault(x => x.Key == "Genre")?.Value;

                if (string.IsNullOrWhiteSpace(gameId) || string.IsNullOrWhiteSpace(computerId) || string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(genre))
                {
                    return false;
                }

                if (gameRepository.GetAll().FirstOrDefault(g => g.GameId == gameId) != null)
                {
                    return false;
                }

                if (computerRepository.GetAll().FirstOrDefault(c => c.ComputerId == computerId) == null)
                {
                    return false;
                }

                var game = new Game
                {
                    GameId = gameId,
                    ComputerId = computerId,
                    Title = title,
                    Genre = genre
                };

                gameRepository.Create(game);
                return true;
            }
            catch (Exception ex)
            {
                throw ex; // re-throw the exception
            }
        }




    }
}
