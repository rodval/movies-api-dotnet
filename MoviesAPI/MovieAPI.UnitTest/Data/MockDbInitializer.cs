using System;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MovieAPI.UnitTest.Data
{
    public class MockDbInitializer
    {
        private readonly DbContextOptions<MovieContext> _options;

        public MockDbInitializer(DbContextOptions<MovieContext> options)
        {
            _options = options;
        }

        public void AddMoviesInitializer()
        {
            using var context = new MovieContext(_options);

            var movies = new Movie[]
            {
                new Movie
                {
                    Title = "Toy Story",
                    Description = "An animated toys film",
                    Stock = 10,
                    RentalPrice = 7.99,
                    SalePrice = 12,
                    Availability = true,
                    Images = new List<MovieImage>
                    {
                        new MovieImage
                        {
                            UrlImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/Toy_Story.svg/2560px-Toy_Story.svg.png"
                        }
                    }
                },
                new Movie
                {
                    Title = "Cars",
                    Description = "An animated cars film",
                    Stock = 10,
                    RentalPrice = 7.99,
                    SalePrice = 12,
                    Availability = true,
                    Images = new List<MovieImage>
                    {
                        new MovieImage
                        {
                            UrlImage = "https://i.pinimg.com/564x/2e/0a/40/2e0a405b438030a836baac35b474c01f.jpg"
                        }
                    }
                }
            };


            context.Movies.AddRange(movies);
            context.SaveChanges();
        }
    }
}

