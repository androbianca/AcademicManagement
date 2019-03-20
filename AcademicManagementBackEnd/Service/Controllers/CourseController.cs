using System.Collections.Generic;
using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Service.Controllers
{
    [Route("api/course")]
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

        [HttpGet("{year:int}")]
        public ActionResult<ICollection<CourseDto>> GetAllByYear([FromRoute] int year)
        {
            var courses = _courseLogic.GetByYear(year);

            return Ok(courses);
        }
    }
}
