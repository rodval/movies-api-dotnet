using System;
using MovieAPI.UnitTest.Mocks;
using MoviesAPI.Controllers;
using MoviesAPI.Models;
using MoviesAPI.Utilities;

namespace MovieAPI.UnitTest.Controllers
{
    public class MovieApproachControllerTest
    {
        private readonly MockMovieApproachService service;

        public MovieApproachControllerTest()
        {
            service = new MockMovieApproachService();
        }

        [Fact]
        public void GetApproachById_ReturnsApprach()
        {
            //Arrange
            var approachRepository = new MovieApproachController(service);

            //Act
            var approach = approachRepository.GetById(1);

            //Assert
            Assert.NotNull(approach);
            Assert.Equal("Toy Story 1", approach.Value.Movie.Title);
        }

        [Fact]
        public void GetApproaches_ReturnsApproaches()
        {
            //Arrange
            var approachRepository = new MovieApproachController(service);

            //Act
            var approach = approachRepository.GetAllMovies(1);

            //Assert
            Assert.NotNull(approach);
            Assert.Single(approach);
        }

        [Fact]
        public void CreateApproach_ReturnsApproach()
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

            var approachRepository = new MovieApproachController(service);

            //Act
            approachRepository.Create(2, 2, approach);
            var newApproach = approachRepository.GetById(2);

            //Assert
            Assert.NotNull(newApproach);
            Assert.Equal("Toy Story 2", newApproach.Value.Movie.Title);
            Assert.Equal("alejandro", newApproach.Value.User.Name);
        }

        [Fact]
        public void UpdateApproach_ReturnsApproach()
        {
            //Arrange
            var approach = new MovieApproach
            {
                Id = 1,
                State = MovieApproachStateType.Cancel
            };

            var approachRepository = new MovieApproachController(service);

            //Act
            approachRepository.Update(approach);
            var newApproach = approachRepository.GetById(1);

            //Assert
            Assert.NotNull(newApproach);
            Assert.Equal(MovieApproachStateType.Cancel, newApproach.Value.State);
        }
    }
}

