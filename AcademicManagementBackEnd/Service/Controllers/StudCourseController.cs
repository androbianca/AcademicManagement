using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;

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

        [HttpDelete("{studCourseId:guid}")]
        public IActionResult Delete([FromRoute] Guid studCourseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studCourses = _studCourseLogic.Delete(studCourseId);

            return Ok(studCourses);
        }

        [HttpGet("{studId:guid}")]
        public IActionResult GetByStudentId([FromRoute] Guid studId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studCourses = _studCourseLogic.GetByStudentId(studId);
            return Ok(studCourses);
        }

    }
}
