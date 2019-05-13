using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{

    [Route("api/potentialUser")]
    [ApiController]
    public class PotentialUserController : ControllerBase
    {
        private readonly IPotentialUserLogic _potentialUserLogic;

        public PotentialUserController(IPotentialUserLogic potentialUserLogic)
        {
            _potentialUserLogic = potentialUserLogic;
        }

        [HttpPost]
        public IActionResult AddPotentilUser([FromBody] string userCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var potentialUserId = _potentialUserLogic.AddPotentialUser(userCode);

            return Ok(potentialUserId);
        }
    }
}
