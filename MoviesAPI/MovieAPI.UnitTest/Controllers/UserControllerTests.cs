using System;
using MovieAPI.UnitTest.Mocks;
using MoviesAPI.Controllers;
using MoviesAPI.Models;
using MoviesAPI.Utilities;

namespace MovieAPI.UnitTest.Controllers
{
    public class UserControllerTests
    {
        private readonly MockUserService service;

        public UserControllerTests()
        {
            service = new MockUserService();
        }

        [Fact]
        public void GetUsersById_ReturnsUser()
        {
            //Arrange
            var userRepository = new UserController(service);

            //Act
            var user = userRepository.GetById(1);

            //Assert
            Assert.NotNull(user);
            Assert.Equal("Rodrigo", user.Value.Name);
        }

        [Fact]
        public void CreateUser_ReturnsUser()
        {
            //Arrange
            var user = new User
            {
                Id = 4,
                Name = "Valladares",
                UserName = "val",
                Role = UserRoleType.Admin
            };

            var userRepository = new UserController(service);

            //Act
            userRepository.Create(user);
            var newUser = userRepository.GetById(4);

            //Assert
            Assert.Equal("Valladares", newUser.Value.Name);
        }

        [Fact]
        public void AddLikedMovie_ReturnMovies()
        {
            //Arrange
            var userRepository = new UserController(service);

            //Act
            userRepository.LikedMovie(3, 2);
            var user = userRepository.GetById(2);

            //Assert
            Assert.NotNull(user);
            Assert.Single(user.Value.LikedMovies);
        }

        [Fact]
        public void RemoveLikedMovie_ReturnMovies()
        {
            //Arrange
            var userRepository = new UserController(service);

            //Act
            userRepository.UnlikedMovie(2, 1);
            var user = userRepository.GetById(2);

            //Assert
            Assert.NotNull(user);
            Assert.Empty(user.Value.LikedMovies);
        }
    }
}

