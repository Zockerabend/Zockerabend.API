using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Zockerabend.API.Data;
using Zockerabend.API.Dtos;
using Zockerabend.API.Models;

namespace Zockerabend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository repo;

        public AuthController(IAuthRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Hello()
        {
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] UserToRegisterDto userToRegister)
        {
            userToRegister.Username = userToRegister.Username.ToLower();

            if (await repo.UserExists(userToRegister.Username))
            {
                return BadRequest("Username already exists");
            }

            var newUser = new User
            {
                Username = userToRegister.Username,
                Email = userToRegister.Email
            };

            await repo.Register(newUser, userToRegister.Password);

            return StatusCode(201);
        }
    }
}
