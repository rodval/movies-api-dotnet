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
        UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpPut("{id}/addlikedmovie")]
        public IActionResult AddTopping(int id, int movieId)
        {
            var validUser = _service.GetById(id);

            if (validUser is not null)
            {
                _service.AddLikedMovie(id, movieId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

