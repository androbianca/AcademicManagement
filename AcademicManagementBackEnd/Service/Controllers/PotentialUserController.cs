using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<string> Add([FromBody] string userCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var potentialUserId = _potentialUserLogic.Add(userCode);

            return Ok(potentialUserId);
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
