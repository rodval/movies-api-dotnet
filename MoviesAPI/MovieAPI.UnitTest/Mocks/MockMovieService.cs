using System;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using MoviesAPI.Utilities;

namespace MovieAPI.UnitTest.Mocks
{
    public class MockMovieService : IMovieService
    {
        private List<Movie> movies = new()
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

        private MovieImage image = new()
        {
            Id = 1,
            UrlImage = "wwww.myMovieImage.com"
        };

        public void AddMovieImage(int userId, int MovieId, int MovieImageId)
        {
            var movieIndex = movies.FindIndex(m => m.Id == MovieId);

            if (userId != 1)
            {
                throw new InvalidOperationException(Erros.InvalidUser);
            }

            if (movieIndex == -1)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            if (MovieImageId != image.Id)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            movies[movieIndex].Images = new List<MovieImage>() { image };
        }

        public Movie? Create(int userId, Movie newMovie)
        {

            if (userId != 1)
            {
                throw new InvalidOperationException(Erros.InvalidUser);
            }

            movies.Add(newMovie);

            return movies.Last();
        }

        public void Delete(int userId, int id)
        {
            var movieIndex = movies.FindIndex(m => m.Id == id);

            if (userId != 1)
            {
                throw new InvalidOperationException(Erros.InvalidUser);
            }

            if (movieIndex == -1)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            movies.RemoveAt(movieIndex);
        }

        public IEnumerable<Movie> GetAllMovies(int userId, int numberOfResults, bool availability)
        {
            if (userId != 1)
            {
                throw new InvalidOperationException(Erros.InvalidUser);
            }

            if (userId == 1)
            {
                return movies
                        .Where(m => m.Availability == true)
                        .OrderBy(m => m.Title)
                        .ToList()
                        .Take(numberOfResults);
            }

            return movies
                    .Where(m => m.Availability == availability)
                    .OrderBy(m => m.Title)
                    .ToList()
                    .Take(numberOfResults);
        }

        public Movie? GetById(int id)
        {
            return movies.Find(m => m.Id == id);
        }

        public IEnumerable<Movie> GetByName(string name)
        {
            return movies
                    .Where(m => !String.IsNullOrEmpty(m.Title) && m.Title.ToLower().Contains(name))
                    .ToList();
        }

        public void Update(int userId, Movie updateMovie)
        {
            var movieIndex = movies.FindIndex(m => m.Id == updateMovie.Id);

            if (userId != 1)
            {
                throw new InvalidOperationException(Erros.InvalidUser);
            }

            if (movieIndex == -1)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            movies[movieIndex].Title = (updateMovie.Title is not null) ? updateMovie.Title : movies[movieIndex].Title;
            movies[movieIndex].Description = (updateMovie.Description is not null) ? updateMovie.Description : movies[movieIndex].Description;
            movies[movieIndex].Stock = (updateMovie.Stock is not null) ? updateMovie.Stock : movies[movieIndex].Stock;
            movies[movieIndex].RentalPrice = (updateMovie.RentalPrice is not null) ? updateMovie.RentalPrice : movies[movieIndex].RentalPrice;
            movies[movieIndex].SalePrice = (updateMovie.SalePrice is not null) ? updateMovie.SalePrice : movies[movieIndex].SalePrice;
            movies[movieIndex].Availability = (updateMovie.Availability is not null) ? updateMovie.Availability : movies[movieIndex].Availability;
            movies[movieIndex].Images = (updateMovie.Images is not null) ? updateMovie.Images : movies[movieIndex].Images;

        }
    }
}

