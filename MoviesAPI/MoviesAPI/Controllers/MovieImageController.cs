using System;
using MoviesAPI.Services;
using MoviesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieImageController : ControllerBase
    {
        private readonly MovieImageService _service;

        public MovieImageController(MovieImageService service)
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

    }
}