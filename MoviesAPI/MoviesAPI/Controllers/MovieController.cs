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
        private readonly MovieService _service;

        public MovieController(MovieService service)
        {
            _service = service;
        }

        [HttpGet("{title}/getbyname")]
        public IEnumerable<Movie> GetByName(string title)
        {
            return _service.GetByName(title);
        }

        [HttpGet("{id}")]
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

        [HttpPost]
        public IActionResult Create(Movie newMovie)
        {
            var movie = _service.Create(newMovie);
            return CreatedAtAction(nameof(GetById), new { id = movie!.Id }, movie);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Movie updateMovie)
        {
            var movieToUpdate = _service.GetById(id);

            if (movieToUpdate is not null && updateMovie is not null)
            {
                _service.Update(id, updateMovie);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _service.GetById(id);

            if (movie is not null)
            {
                _service.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}/addimage")]
        public IActionResult AddImage(int id, int imageId)
        {
            var movieToUpdate = _service.GetById(id);

            if (movieToUpdate is not null)
            {
                _service.AddMovieImage(id, imageId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}/removeimage")]
        public IActionResult RemoveImage(int id, int imageId)
        {
            var movieToUpdate = _service.GetById(id);

            if (movieToUpdate is not null)
            {
                _service.RemoveMovieImage(id, imageId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}