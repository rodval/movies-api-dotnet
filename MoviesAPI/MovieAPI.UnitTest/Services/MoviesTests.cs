
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.Services;

namespace MovieAPI.UnitTest
{
    public class MoviesServiceTests
    {
        private readonly DbContextOptions<MovieContext> options;

        public MoviesServiceTests()
        {
            options = new DbContextOptionsBuilder<MovieContext>()
                .UseInMemoryDatabase(databaseName: "MoviesList")
                .Options;
        }

        [Fact]
        public void GetMoviesById_ReturnsMovie()
        {
            //Arrange
            using (var context = new MovieContext(options))
            {
                var movies = new Movie[]
                {
                    new Movie
                    {
                        Title = "Toy Story",
                        Description = "An animated toys film",
                        Stock = 10,
                        RentalPrice = 7.99,
                        SalePrice = 12,
                        Availability = true
                    },
                    new Movie
                    {
                        Title = "Cars",
                        Description = "An animated toys film",
                        Stock = 10,
                        RentalPrice = 7.99,
                        SalePrice = 12,
                        Availability = true
                    }
                };

                context.Movies.AddRange(movies);
                context.SaveChanges();
            }

            using (var context = new MovieContext(options))
            {
                //Act
                var movieRepository = new MovieService(context);
                var movies = movieRepository.GetById(2);

                //Assert
                Assert.NotNull(movies);
                Assert.Equal("Cars", movies.Title);
            }
        }

        [Fact]
        public void GetMoviesByName_ReturnsMovies()
        {
            //Arrange
            using (var context = new MovieContext(options))
            {
                var movies = new Movie[]
                {
                    new Movie
                    {
                        Title = "Movie 1",
                        Description = "An animated film",
                        Stock = 10,
                        RentalPrice = 7.99,
                        SalePrice = 12,
                        Availability = true
                    },
                    new Movie
                    {
                        Title = "Movie 2",
                        Description = "An animated film",
                        Stock = 10,
                        RentalPrice = 7.99,
                        SalePrice = 12,
                        Availability = true
                    }
                };

                context.Movies.AddRange(movies);
                context.SaveChanges();
            }

            using (var context = new MovieContext(options))
            {
                //Act
                var movieRepository = new MovieService(context);
                var movies = movieRepository.GetByName("movie");

                //Assert
                Assert.NotNull(movies);
                Assert.Equal(2, movies.Count());
            }
        }
    }
}