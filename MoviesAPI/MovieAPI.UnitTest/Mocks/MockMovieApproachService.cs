using System;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using MoviesAPI.Utilities;

namespace MovieAPI.UnitTest.Mocks
{
    public class MockMovieApproachService : IMovieApproachService
    {
        private Movie movie = new Movie
        {
            Id = 2,
            Title = "Toy Story 2",
            Description = "An animated toys film",
            Stock = 10,
            RentalPrice = 7.99,
            SalePrice = 12,
            Availability = true
        };

        private User user = new User
        {
            Id = 2,
            Name = "alejandro",
            UserName = "al",
            Role = UserRoleType.Client
        };

        private List<MovieApproach> approach = new()
        {
            new MovieApproach
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
            }
        };

        public MovieApproach? Create(int userId, int movieId, MovieApproach newApproach)
        {
            if (userId != user.Id || movieId != movie.Id)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            newApproach.User = user;
            newApproach.Movie = movie;

            approach.Add(newApproach);

            return approach.Last();
        }

        public IEnumerable<MovieApproach> GetAll(int id)
        {
            return approach
                        .Where(m => m.Id == id)
                        .ToList();
        }

        public MovieApproach? GetById(int id)
        {
            return approach.Find(m => m.Id == id);
        }

        public void Update(MovieApproach updateApproach)
        {
            var approachIndex = approach.FindIndex(m => m.Id == updateApproach.Id);

            if (approachIndex == -1)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            approach[approachIndex].State = (updateApproach.State is not null) ? updateApproach.State : approach[approachIndex].State;
            approach[approachIndex].ReturnDate = (updateApproach.ReturnDate is not null) ? updateApproach.ReturnDate : approach[approachIndex].ReturnDate;
        }
    }
}

