using System;
using System.Collections.Generic;
using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Service.Controllers
{
    [Route("api/grades")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeLogic _gradeLogic;

        public GradeController(IGradeLogic gradeLogic)
        {
            _gradeLogic = gradeLogic;
        }

        [HttpGet("{courseId:guid}/{studentId:guid}/{profId:guid}")]
        public ActionResult<ICollection<GradeDto>> GetGradesByStud([FromRoute] Guid courseId, [FromRoute] Guid studentId, [FromRoute] Guid profId)
        {

            var grades = _gradeLogic.GetGradesByStud(courseId, studentId, profId);

            return Ok(grades);

        }

        [HttpGet("{courseId:guid}/{studentId:guid}")]
        public ActionResult<ICollection<GradeDto>> GetGradesByProf([FromRoute] Guid courseId, [FromRoute] Guid studentId)
        {

            var grades = _gradeLogic.GetGradesByProf(courseId, studentId);

            return Ok(grades);

        }

        [HttpPost]
        public IActionResult Add([FromBody] GradeDto grade)
        {
            _gradeLogic.Add(grade);

            return Ok(grade);

        }
    }
}
