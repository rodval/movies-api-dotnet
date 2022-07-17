using System;
using MoviesAPI.Models;
using MoviesAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        public ActionResult<User> GetById(int userId)
        {
            var user = _service.GetById(userId);

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
            return CreatedAtAction(nameof(GetById), new { userId = user!.Id }, user);
        }

        [HttpPut("{userId}/likedmovie")]
        public IActionResult LikedMovie(int userId, int movieId)
        {
            var userToUpdate = _service.GetById(userId);

            if (userToUpdate is not null)
            {
                _service.LikedMovie(userId, movieId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{userId}/unlikedmovie")]
        public IActionResult UnlikedMovie(int userId, int movieId)
        {
            var userToUpdate = _service.GetById(userId);

            if (userToUpdate is not null)
            {
                _service.UnlikedMovie(userId, movieId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

