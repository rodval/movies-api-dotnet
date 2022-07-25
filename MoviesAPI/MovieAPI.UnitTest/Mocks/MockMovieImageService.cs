using System;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using MoviesAPI.Utilities;

namespace MovieAPI.UnitTest.Mocks
{
    public class MockMovieImageService : IMovieImageService
    {
        private List<MovieImage> images = new()
        {
            new MovieImage
            {
                Id = 1,
                UrlImage = "wwww.myMovieImage.com"
            },
            new MovieImage
            {
                Id = 2,
                UrlImage = "wwww.myMovieImage.com"
            }
        };

        public MovieImage? Create(MovieImage newImage)
        {
            images.Add(newImage);

            return images.Last();
        }

        public MovieImage? GetById(int id)
        {
            return images.Find(m => m.Id == id);
        }

        public void Delete(int id)
        {
            var imageIndex = images.FindIndex(m => m.Id == id);

            if (imageIndex == -1)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            images.RemoveAt(imageIndex);
        }
    }
}

