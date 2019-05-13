using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace Service.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AccountDto user)
        {
            var ceva = _userLogic.Authenticate(user.UserCode, user.Password);
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            if (ceva == null)
            {
                return Unauthorized();
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim("Identifier", user.UserCode),
            };

            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:44304",
                audience: "http://localhost:44304",
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new { Token = tokenString, Role = ceva.Role });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]UserDto user)
        {
            var potentialUser = _userLogic.Create(user);
            if (potentialUser == null)
            {
                return BadRequest("Invalid client request");

            }
            return Ok(ModelState);
        }

        [HttpGet("user/current")]
        public IActionResult Get()
        {
            var headerValue = Request.Headers["Authorization"];
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadToken(headerValue) as JwtSecurityToken;
            var id = token.Claims.FirstOrDefault(c => c.Type == "Identifier").Value;
            var user = _userLogic.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}

