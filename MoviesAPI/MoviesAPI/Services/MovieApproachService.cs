using System;
using MoviesAPI.Models;
using MoviesAPI.Data;
using MoviesAPI.Utilities;
using MoviesAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Services
{
    public class MovieApproachService : IMovieApproachService
    {
        private readonly MovieContext _context;

        public MovieApproachService(MovieContext context)
        {
            _context = context;
        }

        public MovieApproach? GetById(int id)
        {
            return _context.MovieApproaches
                            .AsNoTracking()
                            .SingleOrDefault(m => m.Id == id);
        }

        public IEnumerable<MovieApproach> GetAll(int id)
        {
            return _context.MovieApproaches
                            .Include(m => m.Movie)
                            .AsNoTracking()
                            .Where(m => m.User.Id == id)
                            .ToList();
        }

        public MovieApproach? Create(int userId, int movieId, MovieApproach newApproach)
        {
            var movieToAdd = _context.Movies.Find(movieId);
            var userToAdd = _context.Users.Find(userId);

            if (movieToAdd is null || userToAdd is null)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            newApproach.User = userToAdd;
            newApproach.Movie = movieToAdd;

            _context.MovieApproaches.Add(newApproach);
            _context.SaveChanges();
            return newApproach;
        }

        public void Update(MovieApproach updateApproach)
        {
            var approachToUpdate = _context.MovieApproaches.Find(updateApproach.Id);

            if (approachToUpdate is null)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            approachToUpdate.State = (updateApproach.State is not null) ? updateApproach.State : approachToUpdate.State;
            approachToUpdate.ReturnDate = (updateApproach.ReturnDate is not null) ? updateApproach.ReturnDate : approachToUpdate.ReturnDate;

            _context.SaveChanges();
        }
    }
}