
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.Services;
using MoviesAPI.Utilities;

namespace MovieAPI.UnitTest
{
    public class MoviesServiceTests
    {
        private readonly DbContextOptions<MovieContext> options;

        public MoviesServiceTests()
        {
            options = new DbContextOptionsBuilder<MovieContext>()
                .UseInMemoryDatabase(databaseName: "Movies")
                .Options;

            //Global Arrange
            using (var context = new MovieContext(options))
            {
                if (context.Users.Any()
                    && context.Movies.Any()
                    && context.MovieImages.Any())
                {
                    return;
                }

                var user = new User
                {
                    Name = "Rodrigo",
                    UserName = "rod",
                    Role = UserRoleType.Admin
                };

                var movies = new Movie[]
                {
                    new Movie
                    {
                        Id = 1,
                        Title = "Toy Story 1",
                        Description = "An animated toys film",
                        Stock = 10,
                        RentalPrice = 7.99,
                        SalePrice = 12,
                        Availability = true
                    },
                    new Movie
                    {
                        Id = 2,
                        Title = "Toy Story 2",
                        Description = "An animated toys film",
                        Stock = 10,
                        RentalPrice = 7.99,
                        SalePrice = 12,
                        Availability = true
                    },
                    new Movie
                    {
                        Id = 3,
                        Title = "Cars",
                        Description = "An animated toys film",
                        Stock = 10,
                        RentalPrice = 7.99,
                        SalePrice = 12,
                        Availability = false
                    },
                    new Movie
                    {
                        Id = 4,
                        Title = "Cars 2",
                        Description = "An animated toys film",
                        Stock = 10,
                        RentalPrice = 7.99,
                        SalePrice = 12,
                        Availability = false
                    }
                };

                var image = new MovieImage
                {
                    Id = 1,
                    UrlImage = "https://theobjectivestandard.com/wp-content/uploads/2022/03/3-Idiots-Written-and-Directed-by-Rajkumar-Hirani.jpg"
                };

                context.Users.Add(user);
                context.Movies.AddRange(movies);
                context.MovieImages.Add(image);
                context.SaveChanges();
            }
        }

        [Fact]
        public void GetAllMovies_ReturnsMovies()
        {
            using (var context = new MovieContext(options))
            {
                //Act
                var movieRepository = new MovieService(context);
                var movies = movieRepository.GetAllMovies(1,2,true);

                //Assert
                Assert.NotNull(movies);
                Assert.Equal(2, movies.Count());
            }
        }

        [Fact]
        public void GetMoviesById_ReturnsMovie()
        {
            using (var context = new MovieContext(options))
            {
                //Act
                var movieRepository = new MovieService(context);
                var movies = movieRepository.GetById(1);

                //Assert
                Assert.NotNull(movies);
                Assert.Equal("Toy Story 1", movies.Title);
            }
        }

        [Fact]
        public void GetMoviesByName_ReturnsMovies()
        {
            using (var context = new MovieContext(options))
            {
                //Act
                var movieRepository = new MovieService(context);
                IEnumerable<Movie>? movies = movieRepository.GetByName("toy story");

                //Assert
                Assert.NotNull(movies);
                Assert.Equal(2, movies.Count());
            }
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
                Availability = true
            };

            using (var context = new MovieContext(options))
            {
                //Act
                var movieRepository = new MovieService(context);
                var newMovie = movieRepository.Create(1, movie);

                //Assert
                Assert.NotNull(newMovie);
                Assert.Equal(movie.Title, newMovie.Title);
            }
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

            using (var context = new MovieContext(options))
            {
                //Act
                var movieRepository = new MovieService(context);
                movieRepository.Update(1, modifyMovie);

                var movie = movieRepository.GetById(3);

                //Assert
                Assert.NotNull(movie);
                Assert.Equal(modifyMovie.Title, movie.Title);
            }
        }

        [Fact]
        public void DeleteMovie_ReturnNull()
        {
            using (var context = new MovieContext(options))
            {
                //Act
                var movieRepository = new MovieService(context);
                movieRepository.Delete(1, 4);

                var movie = movieRepository.GetById(4);

                //Assert
                Assert.Null(movie);
            }
        }

        [Fact]
        public void AddMovieImage_ReturnNull()
        {
            using (var context = new MovieContext(options))
            {
                //Act
                var movieRepository = new MovieService(context);
                movieRepository.AddMovieImage(1, 1, 1);

                var movie = movieRepository.GetById(1);

                //Assert
                Assert.NotNull(movie);
                Assert.Single(movie.Images);
            }
        }
    }
}