using System;
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
        public ActionResult<ICollection<CourseDto>> GetAll()
        {
            var courses = _courseLogic.GetAll();

            return Ok(courses);
        }

        [HttpGet("optionals")]
        public ActionResult<ICollection<CourseDto>> GetOptionals()
        {
            var id = getCurrentUserId();
            var courses = _courseLogic.getOptionalCourses();

            return Ok(courses);
        }

        [HttpGet("current/stud")]
        public ActionResult<ICollection<CourseDto>> GetStudCourses()
        {
            var id = getCurrentUserId();
            var courses = _courseLogic.GetStudCourses(id);

            return Ok(courses);
        }

        [HttpGet("{profId:guid}")]
        public ActionResult<ICollection<CourseDto>> GetProfCourses([FromRoute] Guid profId)
        {
            var courses = _courseLogic.GetProfCourses(profId);

            return Ok(courses);
        }

        [HttpGet("course/{courseId:guid}")]
        public ActionResult<CourseDto> GetById([FromRoute] Guid courseId)
        {
            var course = _courseLogic.GetById(courseId);

            return Ok(course);
        }

        [HttpPost("edit")]
        public IActionResult Edit([FromBody] CourseDto courseDto)
        {
            var course = _courseLogic.Update(courseDto);

            return Ok(course);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CourseDto courseDto)
        {

            var course = _courseLogic.Add(courseDto);

            return Ok(course);
        }

        [HttpDelete("{courseId:guid}")]
        public IActionResult Remove([FromRoute] Guid courseId)
        {
            var result = _courseLogic.Remove(courseId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        //[HttpPut]
        //public IActionResult Update([FromBody] CourseDto courseDto)
        //{
        //    var result = _courseLogic.Update(courseDto);

        //    if (result == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(result);

        //}


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
