using System;
using MovieAPI.UnitTest.Mocks;
using MoviesAPI.Controllers;
using MoviesAPI.Models;

namespace MovieAPI.UnitTest.Controllers
{
    public class MovieImageControllerTest
    {
        private readonly MockMovieImageService service;

        public MovieImageControllerTest()
        {
            service = new MockMovieImageService();
        }

        [Fact]
        public void GetImageById_ReturnsImage()
        {
            //Arrange
            var imageRepository = new MovieImageController(service);

            //Act
            var image = imageRepository.GetById(1);

            //Assert
            Assert.NotNull(image);
            Assert.Equal("wwww.myMovieImage.com", image.Value.UrlImage);
        }

        [Fact]
        public void CreateImage_ReturnsImage()
        {
            //Arrange
            var image = new MovieImage
            {
                Id = 3,
                UrlImage = "wwww.myMovieImage3.com"
            };

            var imageRepository = new MovieImageController(service);

            //Act
            imageRepository.Create(image);
            var newImage = imageRepository.GetById(3);

            //Assert
            Assert.Equal("wwww.myMovieImage3.com", newImage.Value.UrlImage);
        }

        [Fact]
        public void DeleteImage_ReturnNull()
        {
            //Arrange
            var imageRepository = new MovieImageController(service);

            //Act
            imageRepository.Delete(1);
            var image = imageRepository.GetById(1);

            //Assert
            Assert.Equal("Microsoft.AspNetCore.Mvc.NotFoundResult", image.Result.ToString());
        }
    }
}

