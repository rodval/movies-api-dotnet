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

        [HttpGet("{imageId}")]
        public ActionResult<MovieImage> GetById(int imageId)
        {
            var image = _service.GetById(imageId);

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

        [HttpDelete("{imageId}")]
        public IActionResult Delete(int imageId)
        {
            var image = _service.GetById(imageId);

            if (image is not null)
            {
                _service.Delete(imageId);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}