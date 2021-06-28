using JwtAuthService.Models;
using JwtAuthService.services;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthService.Controllers
{
    [Route("/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ITokenBuilder _tokenBuilder;

        public AuthController(ITokenBuilder tokenBuilder, UserService userService)
        {
            _userService = userService;
            _tokenBuilder = tokenBuilder;
        }

       [HttpPost("create")]
       public ActionResult CreateToken(User user)
        {
            System.Console.WriteLine(user.Username + " " + user._id + " " + user.Type);
            var token = _tokenBuilder.BuildToken(user._id,user.Username,user.Type);
            return Ok(token);
        }
        
        /* [HttpPost("login")]
        public ActionResult<User> Login(User user)
        {
            if (user == null)
            {
                return NotFound();
            }
            var u = _userService.Get(user.Username);
            if (u != null)
            {
                var isValid = u.Pass == user.Pass;
                System.Console.WriteLine("Username: " + u.Username);
                if (isValid)
                {
                    var token = _tokenBuilder.BuildToken(user.Username);

                    return Ok(token);
                }
                else
                {
                    return Unauthorized("Wrong Password");
                }
            }
            else
            {
                return Unauthorized("User not found");
            }
            
        }

        [HttpPost("")]
        public Task<IActionResult> Login([FromBody] User user)
        {
            System.Console.WriteLine("function start!");
            string uname = user.Username;
            System.Console.WriteLine("ping " + uname);
            var dbUser = _userService.Get(uname);

            if (dbUser == null)
            {
                return NotFound("User not found.");
            }

            // This is just an example, made for simplicity; do not store plain passwords in the database
            // Always hash and salt your passwords
            var isValid = dbUser.Pass == user.Pass;

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
    
        
        


        [HttpGet("verify")]
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

          

            if (!userExists)
            {
                return Unauthorized();
            }

            return NoContent();
        }*/
    }
    
}
