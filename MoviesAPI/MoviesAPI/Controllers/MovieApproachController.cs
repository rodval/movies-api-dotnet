using System;
using MoviesAPI.Services;
using MoviesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieApproachController : ControllerBase
    {
        private readonly MovieApproachService _service;

        public MovieApproachController(MovieApproachService service)
        {
            _service = service;
        }

        [HttpGet("{id}/getbyid")]
        public ActionResult<MovieApproach> GetById(int id)
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

        [HttpGet("{id}")]
        public IEnumerable<MovieApproach> GetAllMovies(int userId)
        {
            return _service.GetAll(userId);
        }

        [HttpPost]
        public IActionResult Create(MovieApproach newMovie)
        {
            var movie = _service.Create(newMovie);
            return CreatedAtAction(nameof(GetById), new { id = movie!.Id }, movie);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MovieApproach updateMovie)
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
    }
}

