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

        [HttpGet("{courseId:guid}/{studentId:guid}")]
        public ActionResult<ICollection<GradeDto>> GetGradesByStud([FromRoute] Guid courseId, [FromRoute] Guid studentId)
        {

            var grades = _gradeLogic.GetGradesByStud(courseId, studentId);

            return Ok(grades);

        }

        [HttpGet("{courseId:guid}/{studentId:guid}/final")]
        public ActionResult<ICollection<GradeDto>> GetFinalGrade([FromRoute] Guid courseId, [FromRoute] Guid studentId)
        {

            var finalGrade = _gradeLogic.ComputeLabFinalGrade(courseId, studentId);

            return Ok(finalGrade);

        }


        [HttpPost]
        public IActionResult Add([FromBody] GradeDto grade)
        {
            _gradeLogic.Add(grade);

            return Ok(grade);

        }
    }
}
