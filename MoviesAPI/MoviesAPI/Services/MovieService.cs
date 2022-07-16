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

        public Movie? GetById(int id)
        {
            return _context.Movies
                .AsNoTracking()
                .SingleOrDefault(p => p.Id == id);
        }

        public Movie? Create(Movie newMovie)
        {
            _context.Movies.Add(newMovie);
            _context.SaveChanges();

            return newMovie;
        }

        public void AddMovieImage(int MovieId, int MovieImageId)
        {
            var movieToUpdate = _context.Movies.Find(MovieId);
            var imageToAdd = _context.MovieImages.Find(MovieImageId);

            if (movieToUpdate is null || imageToAdd is null)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            if (movieToUpdate.Images is null)
            {
                movieToUpdate.Images = new List<MovieImage>();
            }

            movieToUpdate.Images.Add(imageToAdd);

            _context.SaveChanges();
        }

    }
}