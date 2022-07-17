using System;
using MoviesAPI.Models;
using MoviesAPI.Data;
using MoviesAPI.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Services
{
    public class MovieApproachService
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

        public MovieApproach? Create(MovieApproach newMovie)
        {
            _context.MovieApproaches.Add(newMovie);
            _context.SaveChanges();

            return newMovie;
        }

        public void Update(int id, MovieApproach updateMovie)
        {
            var movieToUpdate = _context.MovieApproaches.Find(id);

            if (movieToUpdate is null)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            movieToUpdate.State = (updateMovie.State is not null) ? updateMovie.State : movieToUpdate.State;
            movieToUpdate.ReturnDate = (updateMovie.ReturnDate is not null) ? updateMovie.ReturnDate : movieToUpdate.ReturnDate;

            _context.SaveChanges();
        }
    }
}