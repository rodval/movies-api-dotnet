using System;
using MoviesAPI.Models;
using MoviesAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieApproachController : ControllerBase
    {
        private readonly IMovieApproachService _service;

        public MovieApproachController(IMovieApproachService service)
        {
            _service = service;
        }

        [HttpGet("{approachId}/getbyid")]
        public ActionResult<MovieApproach> GetById(int approachId)
        {
            var movie = _service.GetById(approachId);

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

        [HttpPost("{userId}/{movieId}")]
        public IActionResult Create(int userId, int movieId, MovieApproach newApproach)
        {
            var approach = _service.Create(userId, movieId, newApproach);
            return CreatedAtAction(nameof(GetById), new { id = approach!.Id }, approach);
        }

        [HttpPut("{userId}")]
        public IActionResult Update(MovieApproach updateApproach)
        {
            var movieToUpdate = _service.GetById(updateApproach.Id);

            if (movieToUpdate is not null && updateApproach is not null)
            {
                _service.Update(updateApproach);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

