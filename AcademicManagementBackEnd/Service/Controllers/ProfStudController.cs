using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;

namespace Service.Controllers
{

    [Route("api/profstuds")]
    [ApiController]
    public class ProfStudController : ControllerBase
    {
        private readonly IProfStudLogic _profStudLogic;

        public ProfStudController(IProfStudLogic profStudLogic)
        {
            _profStudLogic = profStudLogic;
        }


        [HttpPost]
        public IActionResult Add([FromBody] IEnumerable<ProfStudDto> profStudDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profStuds = _profStudLogic.Add(profStudDto);

            return Ok(profStuds);
        }

    }
}

