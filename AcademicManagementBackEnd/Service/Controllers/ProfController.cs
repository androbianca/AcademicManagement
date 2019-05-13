using BusinessLogic.Abstractions;
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
        public IActionResult AddProf([FromBody] ProfDto profDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prof = _profLogic.addProf(profDto);

            return Ok(prof);
        }

    }
}
