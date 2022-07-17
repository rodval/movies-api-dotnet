using System;
using MoviesAPI.Models;
using MoviesAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieImageController : ControllerBase
    {
        private readonly IMovieImageService _service;

        public MovieImageController(IMovieImageService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<MovieImage> GetById(int id)
        {
            var image = _service.GetById(id);

            if (image is not null)
            {
                return image;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create(MovieImage newImage)
        {
            var image = _service.Create(newImage);
            return CreatedAtAction(nameof(GetById), new { id = image!.Id }, image);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var image = _service.GetById(id);

            if (image is not null)
            {
                _service.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}