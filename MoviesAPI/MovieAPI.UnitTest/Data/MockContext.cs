using System;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MovieAPI.UnitTest.Data
{
    public class MockContext
    {
        public static DbContextOptions<MovieContext> MockMovieContext()
        {
            var options = new DbContextOptionsBuilder<MovieContext>()
                .UseInMemoryDatabase(databaseName: "MovieListDatabase")
                .Options;

            return options;
        }
    }
}


