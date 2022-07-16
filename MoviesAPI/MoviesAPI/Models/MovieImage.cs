using System;

namespace MoviesAPI.Models
{
    public class MovieImage
    {
        public int Id { get; set; }
        
        public string? UrlImage { get; set; }

        public Movie? Movie { get; set; }
    }
}

