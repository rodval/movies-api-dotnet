using System;
using System.Text.Json.Serialization;

namespace MoviesAPI.Models
{
    public class MovieImage
    {
        public int Id { get; set; }
        
        public string? UrlImage { get; set; }

        [JsonIgnore]
        public ICollection<Movie>? Movies { get; set; }
    }
}

