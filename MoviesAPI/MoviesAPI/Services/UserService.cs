using System;
using MoviesAPI.Models;
using MoviesAPI.Data;
using MoviesAPI.Utilities;
using MoviesAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Services
{
    public class UserService : IUserService
    {
        private readonly MovieContext _context;

        public UserService(MovieContext context)
        {
            _context = context;
        }

        public User? GetById(int userId)
        {
            return _context.Users
                .Include(u => u.LikedMovies)
                .AsNoTracking()
                .SingleOrDefault(u => u.Id == userId);
        }

        public User? Create(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();

            return newUser;
        }

        public void LikedMovie(int UserId, int MovieId)
        {
            var userToUpdate = _context.Users.Find(UserId);
            var movieToAdd = _context.Movies.Find(MovieId);

            if (userToUpdate is null || movieToAdd is null)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            if (userToUpdate.LikedMovies is null)
            {
                userToUpdate.LikedMovies = new List<Movie>();
            }

            userToUpdate.LikedMovies.Add(movieToAdd);

            _context.SaveChanges();
        }

        public void UnlikedMovie(int UserId, int MovieId)
        {
            var userToUpdate = _context.Users.Find(UserId);
            var movieToAdd = _context.Movies.Find(MovieId);

            if (userToUpdate is null || movieToAdd is null)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            if (userToUpdate.LikedMovies is null)
            {
                userToUpdate.LikedMovies = new List<Movie>();
            }

            userToUpdate.LikedMovies.Remove(movieToAdd);

            _context.SaveChanges();
        }
    }
}

