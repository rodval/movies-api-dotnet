using System;
using System.ComponentModel.DataAnnotations;
using MoviesAPI.Utilities;

namespace MoviesAPI.Models
{
    public class MovieApproach
    {
        public int Id { get; set; }

        [Required]
        public MovieApproachType? Approach { get; set; }

        [Required]
        public string? ApproachDate { get; set; }

        public string? ReturnDate { get; set; }

        [Required]
        public int? NumberOfCopies { get; set; }

        [Required]
        public MovieApproachStateType? State { get; set; }

        [Required]
        public User? User { get; set; }

        [Required]
        public Movie? Movie { get; set; }
    }
}

