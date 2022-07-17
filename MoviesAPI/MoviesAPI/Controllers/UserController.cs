using System;
using MoviesAPI.Services;
using MoviesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var user = _service.GetById(id);

            if (user is not null)
            {
                return user;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create(User newUser)
        {
            var user = _service.Create(newUser);
            return CreatedAtAction(nameof(GetById), new { id = user!.Id }, user);
        }

        [HttpPut("{id}/likedmovie")]
        public IActionResult LikedMovie(int id, int movieId)
        {
            var userToUpdate = _service.GetById(id);

            if (userToUpdate is not null)
            {
                _service.LikedMovie(id, movieId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}/unlikedmovie")]
        public IActionResult UnlikedMovie(int id, int movieId)
        {
            var userToUpdate = _service.GetById(id);

            if (userToUpdate is not null)
            {
                _service.UnlikedMovie(id, movieId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

