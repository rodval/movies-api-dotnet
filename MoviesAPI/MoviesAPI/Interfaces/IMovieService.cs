using System;
using MoviesAPI.Models;

namespace MoviesAPI.Interfaces
{
    public interface IMovieService
    {
        public IEnumerable<Movie> GetAllMovies(int id, int numberOfResults, bool availability);
        public Movie? GetById(int id);
        public IEnumerable<Movie> GetByName(string name);
        public Movie? Create(Movie newMovie);
        public void Update(int id, Movie updateMovie);
        public void Delete(int id);
        public void AddMovieImage(int MovieId, int MovieImageId);
    }
}