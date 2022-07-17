using System;
using MoviesAPI.Models;
using MoviesAPI.Data;
using MoviesAPI.Utilities;
using MoviesAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieContext _context;

        public MovieService(MovieContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAllMovies(int id, int numberOfResults, bool availability)
        {
            var user = _context.Users.Find(id);

            if (user is null)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            if (user.Role == UserRoleType.Client)
            {
                return _context.Movies
                                .Include(m => m.Images)
                                .AsNoTracking()
                                .Where(m => m.Availability == true)
                                .ToList()
                                .Take(numberOfResults);
            }

            return _context.Movies
                                .Include(m => m.Images)
                                .AsNoTracking()
                                .Where(m => m.Availability == availability)
                                .ToList()
                                .Take(numberOfResults);
        }

        public Movie? GetById(int id)
        {
            return _context.Movies
                            .Include(m => m.Images)
                            .AsNoTracking()
                            .SingleOrDefault(m => m.Id == id);
        }

        public IEnumerable<Movie> GetByName(string name)
        {
            return _context.Movies
                            .Include(m => m.Images)
                            .AsNoTracking()
                            .Where(m => m.Title.ToLower().Contains(name))
                            .ToList();
        }

        public Movie? Create(Movie newMovie)
        {
            _context.Movies.Add(newMovie);
            _context.SaveChanges();

            return newMovie;
        }

        public void Update(int id, Movie updateMovie)
        {
            var movieToUpdate = _context.Movies.Find(id);

            if (movieToUpdate is null)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            movieToUpdate.Title = (updateMovie.Title is not null) ? updateMovie.Title : movieToUpdate.Title;
            movieToUpdate.Description = (updateMovie.Description is not null) ? updateMovie.Description : movieToUpdate.Description;
            movieToUpdate.Stock = (updateMovie.Stock is not null) ? updateMovie.Stock : movieToUpdate.Stock;
            movieToUpdate.RentalPrice = (updateMovie.RentalPrice is not null) ? updateMovie.RentalPrice : movieToUpdate.RentalPrice;
            movieToUpdate.SalePrice = (updateMovie.SalePrice is not null) ? updateMovie.SalePrice : movieToUpdate.SalePrice;
            movieToUpdate.Availability = (updateMovie.Availability is not null) ? updateMovie.Availability : movieToUpdate.Availability;
            movieToUpdate.Images = (updateMovie.Images is not null) ? updateMovie.Images : movieToUpdate.Images;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movieToDelete = _context.Movies.Find(id);
            if (movieToDelete is not null)
            {
                _context.Movies.Remove(movieToDelete);
                _context.SaveChanges();
            }
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