using System;
using MoviesAPI.Models;

namespace MoviesAPI.Interfaces
{
    public interface IMovieService
    {
        public IEnumerable<Movie> GetAllMovies(int userId, int numberOfResults, bool availability);
        public Movie? GetById(int id);
        public IEnumerable<Movie> GetByName(string name);
        public Movie? Create(int userId, Movie newMovie);
        public void Update(int userId, Movie updateMovie);
        public void Delete(int userId, int id);
        public void AddMovieImage(int userId, int MovieId, int MovieImageId);
    }
}