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
        private readonly UserService _user;

        public MovieService(MovieContext context)
        {
            _context = context;
            _user = new UserService(context);
        }

        public Movie? GetById(int id)
        {
            return _context.Movies
                            .AsNoTracking()
                            .SingleOrDefault(p=> p.Id == id);
        }

        public Movie? Create(Movie newMovie, int userId)
        {
            var validUser = _user.CheckUser(userId, UserRoleType.Admin);

            if(validUser)
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
            var validUser = _user.CheckUser(userId, UserRoleType.Admin);

            if (movieToUpdate is not null && validUser)
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
            var validUser = _user.CheckUser(userId, UserRoleType.Admin);

            if (movieToRemove is not null && validUser)
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
            var validUser = _user.CheckUser(userId, UserRoleType.Admin);

            if (movieToDelete is not null && validUser)
            {
                _context.Movies.Remove(movieToDelete);
                _context.SaveChanges();
            }  else {
                throw new InvalidOperationException(Erros.NotFound);
            }
        }
    }
}