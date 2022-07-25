
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.Services;
using MoviesAPI.Utilities;

namespace MovieAPI.UnitTest
{
    public class MovieApproachServiceTests
    {
        private readonly DbContextOptions<MovieContext> options;

        public MovieApproachServiceTests()
        {
            options = new DbContextOptionsBuilder<MovieContext>()
                .UseInMemoryDatabase(databaseName: "Approaches")
                .Options;

            //Global Arrange
            using (var context = new MovieContext(options))
            {
                if (context.Users.Any()
                    && context.Movies.Any())
                {
                    return;
                }

                var movie = new Movie
                {
                    Id = 2,
                    Title = "Toy Story 2",
                    Description = "An animated toys film",
                    Stock = 10,
                    RentalPrice = 7.99,
                    SalePrice = 12,
                    Availability = true
                };

                var approach = new MovieApproach
                {
                    Id = 1,
                    Approach = MovieApproachType.Purchase,
                    ApproachDate = "2022/07/25",
                    NumberOfCopies = 2,
                    State = MovieApproachStateType.Defeated,
                    User = new User
                    {
                        Id = 1,
                        Name = "Rodrigo",
                        UserName = "rod",
                        Role = UserRoleType.Admin
                    },
                    Movie = new Movie
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

                context.MovieApproaches.Add(approach);
                context.Movies.Add(movie);
                context.SaveChanges();
            }
        }

        [Fact]
        public void GetMovieApproachById_ReturnsMovieApproach()
        {
            using (var context = new MovieContext(options))
            {
                //Act
                var approachRepository = new MovieApproachService(context);
                var approach = approachRepository.GetById(1);

                //Assert
                Assert.NotNull(approach);
                Assert.Equal("2022/07/25", approach.ApproachDate);
                Assert.Equal("Rodrigo", approach.User.Name);
            }
        }

        [Fact]
        public void GetMovieApproachByUser_ReturnsMovieApproach()
        {
            using (var context = new MovieContext(options))
            {
                //Arrange
                var approachRepository = new MovieApproachService(context);

                //Act
                var approach = approachRepository.GetAll(1);

                //Assert
                Assert.NotNull(approach);
                Assert.Single(approach);
            }
        }

        [Fact]
        public void CreateMovieApproach_ReturnsApproach()
        {
            //Arrange
            var approach = new MovieApproach
            {
                Id = 2,
                Approach = MovieApproachType.Purchase,
                ApproachDate = "2022/07/25",
                NumberOfCopies = 2,
                State = MovieApproachStateType.Defeated
            };

            using (var context = new MovieContext(options))
            {
                //Arrange
                var approachRepository = new MovieApproachService(context);

                //Act
                var newApproach = approachRepository.Create(1, 2, approach);

                //Assert
                Assert.NotNull(newApproach);
                Assert.Equal("Rodrigo", approach.User.Name);
                Assert.Equal("Toy Story 2", approach.Movie.Title);
            }
        }

        [Fact]
        public void UpdateovieApproach_ReturnsApproach()
        {
            //Arrange
            var modifyApproach = new MovieApproach
            {
                Id = 1,
                Approach = MovieApproachType.Purchase,
                ApproachDate = "2022/07/25",
                NumberOfCopies = 2,
                State = MovieApproachStateType.Cancel
            };

            using (var context = new MovieContext(options))
            {
                //Arrange
                var approachRepository = new MovieApproachService(context);

                //Act
                approachRepository.Update(modifyApproach);

                var approach = approachRepository.GetById(1);

                //Assert
                Assert.NotNull(approach);
                Assert.Equal(MovieApproachStateType.Cancel, approach.State);
            }
        }
    }
}
