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

        private bool ValidAdminUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user is null)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            if (user.Role == UserRoleType.Client)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<Movie> GetAllMovies(int userId, int numberOfResults, bool availability)
        {
            var validUser = ValidAdminUser(userId);

            if (!validUser)
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

        public Movie? GetById(int movieId)
        {
            return _context.Movies
                            .Include(m => m.Images)
                            .AsNoTracking()
                            .SingleOrDefault(m => m.Id == movieId);
        }

        public IEnumerable<Movie> GetByName(string name)
        {
            return _context.Movies
                            .Include(m => m.Images)
                            .AsNoTracking()
                            .Where(m => m.Title.ToLower().Contains(name))
                            .ToList();
        }

        public Movie? Create(int userId, Movie newMovie)
        {
            var validUser = ValidAdminUser(userId);

            if (!validUser)
            {
                throw new InvalidOperationException(Erros.InvalidUser);
            }

            _context.Movies.Add(newMovie);
            _context.SaveChanges();

            return newMovie;
        }

        public void Update(int userId, Movie updateMovie)
        {
            var validUser = ValidAdminUser(userId);

            if (!validUser)
            {
                throw new InvalidOperationException(Erros.InvalidUser);
            }

            var movieToUpdate = _context.Movies.Find(updateMovie.Id);

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

        public void Delete(int userId, int movieId)
        {
            var validUser = ValidAdminUser(userId);

            if (!validUser)
            {
                throw new InvalidOperationException(Erros.InvalidUser);
            }

            var movieToDelete = _context.Movies.Find(movieId);
            if (movieToDelete is not null)
            {
                _context.Movies.Remove(movieToDelete);
                _context.SaveChanges();
            }
        }

        public void AddMovieImage(int userId, int MovieId, int MovieImageId)
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