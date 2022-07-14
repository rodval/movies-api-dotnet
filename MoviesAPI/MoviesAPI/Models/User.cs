using System;
using MoviesAPI.Utilities;

namespace MoviesAPI.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? User { get; set; }
        public UserRoleType Role { get; set; }
    }

}