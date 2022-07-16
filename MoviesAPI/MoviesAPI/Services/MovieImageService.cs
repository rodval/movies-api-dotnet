using System;
using MoviesAPI.Models;
using MoviesAPI.Data;
using MoviesAPI.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Services
{
    public class MovieImageService
    {
        private readonly MovieContext _context;

        public MovieImageService(MovieContext context)
        {
            _context = context;
        }

        public MovieImage? GetById(int id)
        {
            return _context.MovieImages
                .AsNoTracking()
                .SingleOrDefault(p => p.Id == id);
        }

        public MovieImage? Create(MovieImage newMovieImage)
        {
            _context.MovieImages.Add(newMovieImage);
            _context.SaveChanges();

            return newMovieImage;
        }

    }
}
