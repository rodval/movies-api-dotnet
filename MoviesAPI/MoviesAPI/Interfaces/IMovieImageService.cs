using System;
using MoviesAPI.Models;

namespace MoviesAPI.Interfaces
{
    public interface IMovieImageService
    {
        public MovieImage? GetById(int id);
        public MovieImage? Create(MovieImage newMovieImage);
        public void Delete(int id);
    }
}

