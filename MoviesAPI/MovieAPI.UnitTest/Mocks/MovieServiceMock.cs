using System;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;

namespace MovieAPI.UnitTest.Mocks
{
    public class MovieServiceMock : IMovieService
    {
        private readonly string _context;

        public MovieServiceMock(string context)
        {
            _context = context;
        }

        public void AddMovieImage(int userId, int MovieId, int MovieImageId)
        {
            throw new NotImplementedException();
        }

        public Movie? Create(int userId, Movie newMovie)
        {
            throw new NotImplementedException();
        }

        public void Delete(int userId, int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAllMovies(int userId, int numberOfResults, bool availability)
        {
            throw new NotImplementedException();
        }

        public Movie? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(int userId, Movie updateMovie)
        {
            throw new NotImplementedException();
        }
    }
}

