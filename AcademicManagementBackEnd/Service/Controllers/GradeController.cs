using System;
using System.Collections.Generic;
using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Service.Controllers
{
    [Route("api/grade")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeLogic _gradeLogic;

        public GradeController(IGradeLogic gradeLogic)
        {
            _gradeLogic = gradeLogic;
        }

        [HttpGet("{courseId:guid}/{studentId:guid}/{profId:guid}")]
        public ActionResult<ICollection<GradeDto>> getGrades([FromRoute] Guid courseId, [FromRoute] Guid studentId, [FromRoute] Guid profId)
        {

            var grades = _gradeLogic.getGrades(courseId, studentId, profId);

            return Ok(grades);

        }

        [HttpGet("{courseId:guid}/{studentId:guid}")]
        public ActionResult<ICollection<GradeDto>> getGrades2([FromRoute] Guid courseId, [FromRoute] Guid studentId)
        {

            var grades = _gradeLogic.getGrades2(courseId, studentId);

            return Ok(grades);

        }

        [HttpPost]
        public IActionResult addGrade ([FromBody] GradeDto grade)
        {
            _gradeLogic.addGrade(grade);

            return Ok(grade);

        }
    }
}
