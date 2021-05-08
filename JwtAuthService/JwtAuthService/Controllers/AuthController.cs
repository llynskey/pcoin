using JwtAuthService.Models;
using JwtAuthService.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Driver;

namespace JwtAuthService.Controllers
{
    [Route("/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ITokenBuilder _tokenBuilder;

        public AuthController(
            ITokenBuilder tokenBuilder,
            UserService userService)
        {
            _userService = userService;
            _tokenBuilder = tokenBuilder;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var dbUser = _userService.Get(user.Username);

            if (dbUser == null)
            {
                return NotFound("User not found.");
            }

            // This is just an example, made for simplicity; do not store plain passwords in the database
            // Always hash and salt your passwords
            var isValid = dbUser.Password == user.Password;

            if (!isValid)
            {
                return Unauthorized("Could not authenticate user.");
            }

            var token = _tokenBuilder.BuildToken(user.Username);

            //if(user.type.ElementAt(0).ToString() == "Vendor" )

            var cookie = Request.Cookies["ASP.Net_SessionId"];
            if (cookie != null)
            {
                //var httpOnly = cookie.HttpOnly; // <-- This is always false
            }


            return Ok(token);
            
        }
        


        /*[HttpGet("verify")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> VerifyToken()
        {
            var username = User
                .Claims
                .SingleOrDefault();

            if (username == null)
            {
                return Unauthorized();
            }

            var userExists = await _context
                .Users
                .AnyAsync(u => u.Username == username.Value);

            if (!userExists)
            {
                return Unauthorized();
            }

            return NoContent();
        }*/
    }
}
