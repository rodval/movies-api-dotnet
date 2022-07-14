using System;
namespace MoviesAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public ICollection<MovieImage>? Images { get; set; }
        public int Stock { get; set; }
        public double RentalPrice { get; set; }
        public double SalePrice { get; set; }
        public bool Availability { get; set; }
    }
}

