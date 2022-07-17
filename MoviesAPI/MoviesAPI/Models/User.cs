using System;
using System.ComponentModel.DataAnnotations;
using MoviesAPI.Utilities;

namespace MoviesAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        
        public string? UserName { get; set; }

        [Required]
        public UserRoleType Role { get; set; }

        public ICollection<Movie>? LikedMovies { get; set; }

        public ICollection<MovieApproach>? Approaches { get; set; }
    }
}
