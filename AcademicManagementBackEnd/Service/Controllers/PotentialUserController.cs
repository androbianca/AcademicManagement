using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;

namespace Service.Controllers
{

    [Route("api/potentialusers")]
    [ApiController]
    public class PotentialUserController : ControllerBase
    {
        private readonly IPotentialUserLogic _potentialUserLogic;

        public PotentialUserController(IPotentialUserLogic potentialUserLogic)
        {
            _potentialUserLogic = potentialUserLogic;
        }

        [HttpPost]
        public ActionResult<string> Add([FromBody] PotentialUserDto potentialUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var potentialUser = _potentialUserLogic.Add(potentialUserDto);

            return Ok(potentialUser);
        }

        [HttpGet("{id}")]
        public IActionResult GetByUserCode([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var potentialUser = _potentialUserLogic.GetByUserCode(id);

            return Ok(potentialUser);
        }

        [HttpDelete("potentialUserId:guid")]
        public IActionResult Remove([FromRoute] Guid potentialUserId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var potentialUser = _potentialUserLogic.Remove(potentialUserId);

            return Ok(potentialUser);
        }
    }
}
