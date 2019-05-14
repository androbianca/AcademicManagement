using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Controllers
{
    [Route("api/studcourses")]
    [ApiController]
    public class StudCourseController : ControllerBase
    {
        private IStudCourseLogic _studCourseLogic;

        public StudCourseController(IStudCourseLogic studCourseLogic)
        {
            _studCourseLogic = studCourseLogic;
        }

        [HttpPost]
        public IActionResult Add([FromBody] IEnumerable<StudCourseDto> studCourseDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studCourses = _studCourseLogic.Add(studCourseDtos);

            return Ok(studCourses);
        }

    }
}
