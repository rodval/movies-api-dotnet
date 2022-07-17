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

        [HttpGet("{userId}/getallappraches")]
        public IEnumerable<MovieApproach> GetAllMovies(int userId)
        {
            return _service.GetAll(userId);
        }

        [HttpGet("{approachId}")]
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

        [HttpPost("{userId}/{movieId}")]
        public IActionResult Create(int userId, int movieId, MovieApproach newApproach)
        {
            var approach = _service.Create(userId, movieId, newApproach);
            return CreatedAtAction(nameof(GetById), new { approachId = approach!.Id }, approach);
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

