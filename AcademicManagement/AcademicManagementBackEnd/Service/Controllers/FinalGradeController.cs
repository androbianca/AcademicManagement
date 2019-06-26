using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;

namespace Service.Controllers
{
    [ApiController]
    [Route("api/finalgrades")]
    public class FinalGradeController : ControllerBase
    {

        private readonly IFinalGradeLogic _finalGradeLogic;

        public FinalGradeController(IFinalGradeLogic finalGradeLogic)
        {
            _finalGradeLogic = finalGradeLogic;
        }

        [HttpGet("{courseId:guid}")]
        public ActionResult<ICollection<FinalGradeDto>> GetAll([FromRoute]Guid courseId)
        {
            var grades = _finalGradeLogic.GetAllByCourseId(courseId);

            return Ok(grades);
        }
    }
}
