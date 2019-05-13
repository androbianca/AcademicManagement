using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;

namespace Service.Controllers
{

    [Route("api/profStud")]
    [ApiController]
    public class ProfStudController : ControllerBase
    {
        private readonly IProfStudLogic _profStudLogic;

        public ProfStudController(IProfStudLogic profStudLogic)
        {
            _profStudLogic = profStudLogic;
        }


        [HttpPost]
        public IActionResult AddProf([FromBody] IEnumerable<ProfStudDto> profStudDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profStuds = _profStudLogic.AddProfStud(profStudDto);

            return Ok(profStuds);
        }

    }
}

