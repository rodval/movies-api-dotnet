using System;
using MoviesAPI.Services;
using MoviesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        MovieService _service;

        public MovieController(MovieService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        private ActionResult<Movie> GetById(int id)
        {
            var movie = _service.GetById(id);

            if(movie is not null)
            {
                return movie;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create(Movie newMovie, int userId)
        {
            var movie = _service.Create(newMovie, userId);
            return CreatedAtAction(nameof(GetById), new { id = movie!.Id }, movie);
        }

        [HttpPut("{id}/updateMovie")]
        public IActionResult UpdateMovie(Movie movieId, int userId)
        {
            var movie = _service.GetById(movieId.Id);

            if (movie is not null)
            {
                _service.UpdateById(movieId, userId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}/removeMovie")]
        public IActionResult RemoveMovie(int movieId, int userId, bool available)
        {
            var movie = _service.GetById(movieId);

            if (movie is not null)
            {
                _service.RemoveById(movieId, userId, available);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int movieId, int userId)
        {
            var movie = _service.GetById(movieId);

            if(movie is not null)
            {
                _service.DeleteById(movieId, userId);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}