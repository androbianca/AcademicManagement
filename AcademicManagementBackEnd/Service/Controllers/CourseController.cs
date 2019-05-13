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

        [HttpGet("current/stud")]
        public ActionResult<ICollection<CourseDto>> GetStudCourses()
        {
            var id = getCurrentUserId();
            var courses = _courseLogic.GetStudCourses(id);

            return Ok(courses);
        }

        [HttpGet("current/prof")]
        public ActionResult<ICollection<CourseDto>> GetProfCourses()
        {
            var id = getCurrentUserId();
            var courses = _courseLogic.GetProfCourses(id);

            return Ok(courses);
        }

        [HttpPost]
        public IActionResult AddCourse([FromBody] CourseDto courseDto)
        {

            var course = _courseLogic.AddCourse(courseDto);

            return Ok(course);
        }

        private string getCurrentUserId()
        {
            var headerValue = Request.Headers["Authorization"];
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadToken(headerValue) as JwtSecurityToken;
            var id = token.Claims.FirstOrDefault(c => c.Type == "Identifier").Value;

            return id;

        }
    }
}
