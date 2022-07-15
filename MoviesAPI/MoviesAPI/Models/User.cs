using System;
using MoviesAPI.Utilities;

namespace MoviesAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }
        
        public string? UserName { get; set; }

        public UserRoleType Role { get; set; }

        public ICollection<Movie>? LikedMovies { get; set; }
    }

}