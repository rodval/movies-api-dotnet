﻿using System;
using MoviesAPI.Models;

namespace MoviesAPI.Interfaces
{
    public interface IMovieApproachService
    {
        public MovieApproach? GetById(int id);
        public IEnumerable<MovieApproach> GetAll(int id);
        public MovieApproach? Create(int userId, int movieId, MovieApproach newMovie);
        public void Update(MovieApproach updateMovie);
    }
}

