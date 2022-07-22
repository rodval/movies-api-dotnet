
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.Services;
using MoviesAPI.Utilities;

namespace MovieAPI.UnitTest
{
    public class MovieImageServiceTests
    {
        private readonly DbContextOptions<MovieContext> options;

        public MovieImageServiceTests()
        {
            options = new DbContextOptionsBuilder<MovieContext>()
                .UseInMemoryDatabase(databaseName: "Images")
                .Options;

            //Global Arrange
            using (var context = new MovieContext(options))
            {
                if (context.MovieImages.Any())
                {
                    return;
                }

                var images = new MovieImage[]
                {
                    new MovieImage
                    {
                        Id = 1,
                        UrlImage = "https://theobjectivestandard.com/wp-content/uploads/2022/03/3-Idiots-Written-and-Directed-by-Rajkumar-Hirani.jpg"
                    },
                    new MovieImage
                    {
                        Id = 2,
                        UrlImage = "https://theobjectivestandard.com/wp-content/uploads/2022/03/3-Idiots-Written-and-Directed-by-Rajkumar-Hirani.jpg"
                    }
                };

                context.MovieImages.AddRange(images);
                context.SaveChanges();
            }
        }

        [Fact]
        public void GetImageById_ReturnsNotNull()
        {
            using (var context = new MovieContext(options))
            {
                //Act
                var imageRepository = new MovieImageService(context);
                var image = imageRepository.GetById(1);

                //Assert
                Assert.NotNull(image);
            }
        }

        [Fact]
        public void CreateUsers_ReturnsUser()
        {
            //Arrange
            var image = new MovieImage
            {
                Id = 3,
                UrlImage = "https://theobjectivestandard.com/wp-content/uploads/2022/03/3-Idiots-Written-and-Directed-by-Rajkumar-Hirani.jpg"
            };

            using (var context = new MovieContext(options))
            {
                //Act
                var imageRepository = new MovieImageService(context);
                var newImage = imageRepository.Create(image);

                //Assert
                Assert.NotNull(newImage);
            }
        }

        [Fact]
        public void DeleteImage_ReturnsNull()
        {
            using (var context = new MovieContext(options))
            {
                //Act
                var imageRepository = new MovieImageService(context);
                imageRepository.Delete(2);
                var image = imageRepository.GetById(2);

                //Assert
                Assert.Null(image);
            }
        }
    }
}
