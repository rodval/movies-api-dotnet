
using Microsoft.EntityFrameworkCore;
using MovieAPI.UnitTest.Data;
using MoviesAPI.Controllers;
using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.Services;

namespace MovieAPI.UnitTest
{
    public class MoviesValidatorShould
    {
        [Fact]
        public void GetMovies_ReturnsMove()
        {
            //Arrange
            var options = MockContext.MockMovieContext();
            var initializer = new MockDbInitializer(options);
            using var context = new MovieContext(options);
            var movieRepository = new MovieService(context);
            Movie? movies = new();

            //Act
            initializer.AddMoviesInitializer();
            movies = movieRepository.GetById(2);

            Assert.NotNull(movies);
            Assert.Equal("Cars", movies.Title);
        }
    }
}