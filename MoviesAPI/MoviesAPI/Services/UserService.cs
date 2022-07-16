using System;
using MoviesAPI.Models;
using MoviesAPI.Data;
using MoviesAPI.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Services
{
    public class UserService
    {
        private readonly MovieContext _context;

        public UserService(MovieContext context)
        {
            _context = context;
        }

        public User? GetById(int id)
        {
            return _context.Users
                .AsNoTracking()
                .SingleOrDefault(p => p.Id == id);
        }

        public User? Create(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();

            return newUser;
        }

    }
}

