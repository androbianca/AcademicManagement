using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;

namespace Service.Controllers
{
    [ApiController]
    [Route("api/formulas")]
    public class CourseFormulaController : ControllerBase
    {
        private readonly ICourseFormulaLogic _courseFormulaLogic;

        public CourseFormulaController(ICourseFormulaLogic courseFormulaLogic)
        {
            _courseFormulaLogic = courseFormulaLogic;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CourseFormulaDto courseFormulaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseFormula = _courseFormulaLogic.Add(courseFormulaDto);

            return Ok(courseFormula);
        }

        [HttpPost("edit")]
        public IActionResult Edit([FromBody] CourseFormulaDto courseFormulaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseFormula = _courseFormulaLogic.Edit(courseFormulaDto);

            return Ok(courseFormula);
        }

        [HttpGet("{courseId:guid}")]
        public IActionResult GetByCourseId([FromRoute] Guid courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseFormula = _courseFormulaLogic.GetFormulaByCourseId(courseId);

            return Ok(courseFormula);
        }
    }
}
