using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpPost]
        public IActionResult addGrade ([FromBody] GradeDto grade)
        {
            _gradeLogic.addGrade(grade);

            return Ok(grade);

        }
    }
}
