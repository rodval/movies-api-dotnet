using System;
using MoviesAPI.Models;

namespace MoviesAPI.Interfaces
{
    public interface IUserService
    {
        public User? GetById(int id);
        public User? Create(User newUser);
        public void LikedMovie(int UserId, int MovieId);
        public void UnlikedMovie(int UserId, int MovieId);
    }
}