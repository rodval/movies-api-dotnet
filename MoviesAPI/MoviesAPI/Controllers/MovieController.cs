﻿using System;
using MoviesAPI.Models;
using MoviesAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet("{title}/getbyname")]
        public IEnumerable<Movie> GetByName(string title)
        {
            return _service.GetByName(title);
        }

        [HttpGet("{id}/getbyid")]
        public ActionResult<Movie> GetById(int id)
        {
            var movie = _service.GetById(id);

            if (movie is not null)
            {
                return movie;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/{numberOfResults}")]
        public IEnumerable<Movie> GetAllMovies(int userId, int numberOfResults, bool availability)
        {
            return _service.GetAllMovies(userId, numberOfResults, availability);
        }

        [HttpPost("{userId}")]
        public IActionResult Create(int userId, Movie newMovie)
        {
            var movie = _service.Create(userId, newMovie);
            return CreatedAtAction(nameof(GetById), new { id = movie!.Id }, movie);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int userId, Movie updateMovie)
        {
            var movieToUpdate = _service.GetById(updateMovie.Id);

            if (movieToUpdate is not null && updateMovie is not null)
            {
                _service.Update(userId, updateMovie);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int userId, int id)
        {
            var movie = _service.GetById(id);

            if (movie is not null)
            {
                _service.Delete(userId, id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}/addimage")]
        public IActionResult AddImage(int userId, int id, int imageId)
        {
            var movieToUpdate = _service.GetById(id);

            if (movieToUpdate is not null)
            {
                _service.AddMovieImage(userId, id, imageId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}