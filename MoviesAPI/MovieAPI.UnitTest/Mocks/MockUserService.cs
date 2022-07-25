using System;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using MoviesAPI.Utilities;

namespace MovieAPI.UnitTest.Mocks
{
    public class MockUserService : IUserService
    {

        private List<User> users = new()
        {
            new User
            {
                Id = 1,
                Name = "Rodrigo",
                UserName = "rod",
                Role = UserRoleType.Admin
            },
            new User
            {
                Id = 2,
                Name = "Alejandro",
                UserName = "alj",
                Role = UserRoleType.Client,
                LikedMovies = new List<Movie>
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
                }
            },
            new User
            {
                Id = 3,
                Name = "Mejia",
                UserName = "mej",
                Role = UserRoleType.Client
            }
        };

        private Movie movies = new()
        {
            Id = 2,
            Title = "Toy Story 2",
            Description = "An animated toys film",
            Stock = 10,
            RentalPrice = 7.99,
            SalePrice = 12,
            Availability = true
        };

        public User? Create(User newUser)
        {
            users.Add(newUser);

            return users.Last();
        }

        public User? GetById(int id)
        {
            return users.Find(m => m.Id == id);
        }

        public void LikedMovie(int UserId, int MovieId)
        {
            var userIndex = users.FindIndex(m => m.Id == UserId);

            if (userIndex == -1 || MovieId != movies.Id)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            users[userIndex].LikedMovies = new List<Movie>() { movies };
        }

        public void UnlikedMovie(int UserId, int MovieId)
        {
            var userIndex = users.FindIndex(m => m.Id == UserId);

            if (userIndex == -1)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            var movie = users[userIndex].LikedMovies.FirstOrDefault(m => m.Id == MovieId);

            users[userIndex].LikedMovies.Remove(movie);
        }
    }
}


