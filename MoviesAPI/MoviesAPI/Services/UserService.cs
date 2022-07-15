using System;
using MoviesAPI.Models;
using MoviesAPI.Data;
using MoviesAPI.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Services
{
    public class UserService
    {
        private readonly MovieContext _context;

        public UserService(MovieContext context)
        {
            _context = context;
        }

        public bool CheckUser(int idUser, UserRoleType role)
        {
            var validUser = _context.Users
                                    .AsNoTracking()
                                    .SingleOrDefault(u => u.Id == idUser && u.Role == role);

            if(validUser is null)
            {
                return false;
            }

            return true;
        }

        public User? GetById(int id)
        {
            return _context.Users
                            .AsNoTracking()
                            .SingleOrDefault(p=> p.Id == id);
        }

        public void AddLikedMovie(int UserId, int MovieId)
        {
            var movieToAdd = _context.Movies
                                        .AsNoTracking()
                                        .SingleOrDefault(m => m.Id == MovieId && m.Availability);

            var userToUpdate = _context.Users.Find(UserId);

            if (userToUpdate is null || movieToAdd is null)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            if(userToUpdate.LikedMovies is null)
            {
                userToUpdate.LikedMovies = new List<Movie>();
            }

            userToUpdate.LikedMovies.Add(movieToAdd);

            _context.SaveChanges();
        }

    }
}

