using System;
using System.Text.Json.Serialization;

namespace MoviesAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public int Stock { get; set; }

        public double RentalPrice { get; set; }

        public double SalePrice { get; set; }

        public bool Availability { get; set; }

        public ICollection<MovieImage>? Images { get; set; }

        public ICollection<MovieApproach>? Approaches { get; set; }

        [JsonIgnore]
        public ICollection<User>? Users { get; set; }
    }
}

