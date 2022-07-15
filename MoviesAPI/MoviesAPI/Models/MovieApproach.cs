using System;
using MoviesAPI.Utilities;

namespace MoviesAPI.Models
{
    public class MovieApproach
    {
        public int Id { get; set; }

        public MovieApproachType? Approach { get; set; }

        public string? ApproachDate { get; set; }

        public string? ReturnDate { get; set; }

        public int NumberOfCopies { get; set; }



    }
}

