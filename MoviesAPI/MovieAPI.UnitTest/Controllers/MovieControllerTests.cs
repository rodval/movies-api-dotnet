using Microsoft.EntityFrameworkCore;
using MovieAPI.UnitTest.Mocks;
using MoviesAPI.Controllers;
using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.Services;
using MoviesAPI.Utilities;

namespace MovieAPI.UnitTest
{
    public class MovieControllerTests
    {
        private readonly MockMovieService service;

        public MovieControllerTests()
        {
            service = new MockMovieService();
        }

        [Fact]
        public void GetAllMovies_ReturnsMovies()
        {
            //Arrange
            var movieRepository = new MovieController(service);

            //Act
            IEnumerable<Movie>? movies = movieRepository.GetAllMovies(1, 2, true);

            //Assert
            Assert.NotNull(movies);
            Assert.Equal(2, movies.Count());
        }

        [Fact]
        public void GetMoviesById_ReturnsMovie()
        {
            //Arrange
            var movieRepository = new MovieController(service);

            //Act
            var movies = movieRepository.GetById(1);

            //Assert
            Assert.NotNull(movies);
            Assert.Equal("Toy Story 1", movies.Value.Title);
        }

        [Fact]
        public void GetMoviesByName_ReturnsMovies()
        {
            //Arrange
            var movieRepository = new MovieController(service);

            //Act
            IEnumerable<Movie>? movies = movieRepository.GetByName("toy story");

            //Assert
            Assert.NotNull(movies);
            Assert.Equal(2, movies.Count());
        }


        [Fact]
        public void CreateMovies_ReturnsMovie()
        {
            //Arrange
            var movie = new Movie
            {
                Id = 5,
                Title = "Movie 1",
                Description = "An animated film",
                Stock = 10,
                RentalPrice = 7.99,
                SalePrice = 12,
                Availability = true,
                Images = null
            };

            var movieRepository = new MovieController(service);

            //Act
            movieRepository.Create(1, movie);
            var newMovie = movieRepository.GetById(5);

            //Assert
            Assert.Equal("Movie 1", newMovie.Value.Title);
        }

        [Fact]
        public void UpdateMovie_ReturnMovie()
        {
            //Arrange
            var modifyMovie = new Movie
            {
                Id = 3,
                Title = "Movie Example",
                Description = "An animated film",
                Stock = 10,
                RentalPrice = 7.99,
                SalePrice = 12,
                Availability = true
            };

            var movieRepository = new MovieController(service);

            //Act
            movieRepository.Update(1, modifyMovie);

            var movie = movieRepository.GetById(3);

            //Assert
            Assert.NotNull(movie);
            Assert.Equal(modifyMovie.Title, movie.Value.Title);
        }

        [Fact]
        public void DeleteMovie_ReturnNull()
        {
            //Arrange
            var movieRepository = new MovieController(service);

            //Act
            movieRepository.Delete(1, 4);
            var movie = movieRepository.GetById(4);

            //Assert
            Assert.Equal("Microsoft.AspNetCore.Mvc.NotFoundResult", movie.Result.ToString());
        }

        [Fact]
        public void AddMovieImage_ReturnMovie()
        {
            //Arrange
            var movieRepository = new MovieController(service);

            //Act
            movieRepository.AddImage(1, 1, 1);
            var movie = movieRepository.GetById(1);

            //Assert
            Assert.NotNull(movie);
            Assert.Single(movie.Value.Images);
        }
    }
}