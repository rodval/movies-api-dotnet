using System;
using MoviesAPI.Models;
using MoviesAPI.Data;
using MoviesAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Services
{
    public class MovieImageService : IMovieImageService
    {
        private readonly MovieContext _context;

        public MovieImageService(MovieContext context)
        {
            _context = context;
        }

        public MovieImage? GetById(int imageId)
        {
            return _context.MovieImages
                .AsNoTracking()
                .SingleOrDefault(p => p.Id == imageId);
        }

        public MovieImage? Create(MovieImage newMovieImage)
        {
            _context.MovieImages.Add(newMovieImage);
            _context.SaveChanges();
            return newMovieImage;
        }

        public void Delete(int imageId)
        {
            var imageToDelete = _context.MovieImages.Find(imageId);
            if (imageToDelete is not null)
            {
                _context.MovieImages.Remove(imageToDelete);
                _context.SaveChanges();
            }
        }
    }
}
