
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.Services;
using MoviesAPI.Utilities;

namespace MovieAPI.UnitTest
{
    public class UserServiceTests
    {
        private readonly DbContextOptions<MovieContext> options;

        public UserServiceTests()
        {
            options = new DbContextOptionsBuilder<MovieContext>()
                .UseInMemoryDatabase(databaseName: "Users")
                .Options;

            //Global Arrange
            using (var context = new MovieContext(options))
            {
                if (context.Users.Any()
                    && context.Movies.Any())
                {
                    return;
                }

                var user = new User
                {
                    Id = 1,
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
                    }
                };

                context.Users.Add(user);
                context.Movies.AddRange(movies);
                context.SaveChanges();
            }
        }

        [Fact]
        public void GetUserById_ReturnsUser()
        {
            using (var context = new MovieContext(options))
            {
                //Act
                var userRepository = new UserService(context);
                var user = userRepository.GetById(1);

                //Assert
                Assert.NotNull(user);
                Assert.Equal("Rodrigo", user.Name);
            }
        }

        [Fact]
        public void CreateUsers_ReturnsUser()
        {
            //Arrange
            var user = new User
            {
                Id = 2,
                Name = "Ajeandro",
                UserName = "ale",
                Role = UserRoleType.Client
            };

            using (var context = new MovieContext(options))
            {
                //Act
                var userRepository = new UserService(context);
                var newUser = userRepository.Create(user);

                //Assert
                Assert.NotNull(newUser);
                Assert.Equal("Ajeandro", user.Name);
                Assert.Equal(UserRoleType.Client, user.Role);
            }
        }

        [Fact]
        public void AddLikedMovie_ReturnsUserLikedList()
        {
            using (var context = new MovieContext(options))
            {
                //Act
                var userRepository = new UserService(context);
                userRepository.LikedMovie(1, 1);
                var user = userRepository.GetById(1);

                //Assert
                Assert.NotNull(user);
                Assert.Equal(1, user.LikedMovies.Count);
            }
        }
    }
}