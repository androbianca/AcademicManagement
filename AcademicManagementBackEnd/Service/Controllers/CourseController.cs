using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Service.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseLogic _courseLogic;

        public CourseController(ICourseLogic courseLogic)
        {
            _courseLogic = courseLogic;
        }

        [HttpGet]
        public ActionResult<ICollection<CourseDto>> Get()
        {
            var courses = _courseLogic.GetAll();

            return Ok(courses);
        }

        [HttpGet("current")]
        public ActionResult<ICollection<CourseDto>> GetAllByYear([FromRoute] int year)
        {
            var headerValue = Request.Headers["Authorization"];
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadToken(headerValue) as JwtSecurityToken;
            var id = token.Claims.FirstOrDefault(c => c.Type == "Identifier").Value;
            var courses = _courseLogic.GetByYear(id);

            return Ok(courses);
        }
    }
}
