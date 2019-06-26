using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [Route("api/alerts")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly IAlertLogic _alertLogic;

        public AlertController(IAlertLogic alertLogic)
        {
            _alertLogic = alertLogic;
        }

        [HttpGet("{userCode}")]
        public IActionResult GetAlert([FromRoute] string userCode)
        {

            var alert = _alertLogic.GetAlert(userCode);

            return Ok(alert);

        }
    }
}
