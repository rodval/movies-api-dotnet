using System;
using MoviesAPI.Models;
using MoviesAPI.Data;
using MoviesAPI.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Services
{
    public class MovieService
    {
        private readonly MovieContext _context;

        public MovieService(MovieContext context)
        {
            _context = context;
        }

        private User? CheckUser(int idUser, UserRoleType role)
        {
            var validUser = _context.Users
                                    .AsNoTracking()
                                    .SingleOrDefault(u => u.Id == idUser && u.Role == role);

            if(validUser is null)
            {
                throw new InvalidOperationException(Erros.InvalidUser);
            }

            return validUser;
        }

        public Movie? GetById(int id)
        {
            return _context.Movies
                            .AsNoTracking()
                            .SingleOrDefault(p=> p.Id == id);
        }

        public Movie? Create(Movie newMovie, int userId)
        {
            var validUser = CheckUser(userId, UserRoleType.Admin);

            if(validUser is not null)
            {
                _context.Movies.Add(newMovie);
                _context.SaveChanges();

                return newMovie;
            } else 
            {
                throw new InvalidOperationException(Erros.NotFound);
            }
        }

        public void UpdateById(Movie modifyMovie, int userId)
        {
            var movieToUpdate = _context.Movies.Find(modifyMovie.Id);
            var validUser = CheckUser(userId, UserRoleType.Admin);

            if (movieToUpdate is not null && validUser is not null)
            {
                movieToUpdate = modifyMovie;
                _context.SaveChanges();
            }  else {
                throw new InvalidOperationException(Erros.NotFound);
            }
        }

        public void RemoveById(int MovieId, int userId, bool available)
        {
            var movieToRemove = _context.Movies.Find(MovieId);
            var validUser = CheckUser(userId, UserRoleType.Admin);

            if (movieToRemove is not null && validUser is not null)
            {
                movieToRemove.Availability = available;
                _context.SaveChanges();
            }  else {
                throw new InvalidOperationException(Erros.NotFound);
            }
        }

        public void DeleteById(int MovieId, int userId)
        {
            var movieToDelete = _context.Movies.Find(MovieId);
            var validUser = CheckUser(userId, UserRoleType.Admin);

            if (movieToDelete is not null && validUser is not null)
            {
                _context.Movies.Remove(movieToDelete);
                _context.SaveChanges();
            }  else {
                throw new InvalidOperationException(Erros.NotFound);
            }
        }
    }
}