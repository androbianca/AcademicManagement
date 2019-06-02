using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;

namespace Service.Controllers
{
    [Route("api/gradecategories")]
    [ApiController]
    public class GradeCategoryController : ControllerBase
    {
        private readonly IGradeCategoryLogic _gradeCategoryLogic;

        public GradeCategoryController(IGradeCategoryLogic gradeCategoryLogic)
        {
            _gradeCategoryLogic = gradeCategoryLogic;
        }

        [HttpPost]
        public IActionResult Add([FromBody] GradeCategoryDto gadeCategoryDto)
        {

            var gadeCategory = _gradeCategoryLogic.Add(gadeCategoryDto);

            return Ok(gadeCategoryDto);
        }

        [HttpGet("{courseId:guid}")]
        public ActionResult<ICollection<GradeCategoryDto>> GetByCourseId([FromRoute] Guid courseId)
        {
            var gadeCategories = _gradeCategoryLogic.GetByCourseId(courseId);

            return Ok(gadeCategories);
        }

    }
}
