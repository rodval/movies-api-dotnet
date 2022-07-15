using System;
using MoviesAPI.Utilities;
using System.Text.Json.Serialization;

namespace MoviesAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }
        
        public string? UserName { get; set; }

        public UserRoleType Role { get; set; }

        [JsonIgnore]
        public ICollection<Movie>? LikedMovies { get; set; }
    }

}