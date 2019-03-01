using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace Service.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthLogic _authLogic;

        public AuthController(IAuthLogic authLogic)
        {
            _authLogic = authLogic;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]AccountDto user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            if (user.Code == "1" && user.Password == "1")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:44304",
                    audience: "http://localhost:44304",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegistrationDto registration)
        {
            var potentialUser = _authLogic.Create(registration);
            return Ok(ModelState);
        }


    }
}

