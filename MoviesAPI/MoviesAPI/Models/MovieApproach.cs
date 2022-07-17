using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
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

        [JsonIgnore]
        public User? User { get; set; }

        [JsonIgnore]
        public Movie? Movie { get; set; }
    }
}

