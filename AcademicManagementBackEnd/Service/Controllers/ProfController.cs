using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using BusinessLogic.Abstractions;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Service.Controllers
{
    [Route("api/prof")]
    [ApiController]
    public class ProfController : ControllerBase
    {
        private readonly IProfLogic _profLogic;

        public ProfController(IProfLogic profLogic)
        {
            _profLogic = profLogic;
        }


        [HttpPost]
        public ActionResult<Professor> AddCourse([FromBody] ProfDto profDto)
        {

            var course = _profLogic.addProf(profDto);

            return Ok(course);
        }

    }
}
