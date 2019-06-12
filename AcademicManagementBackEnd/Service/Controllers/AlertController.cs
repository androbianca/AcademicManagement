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

        [HttpGet]
        public IActionResult GetAlert()
        {

            var alert = _alertLogic.GetAlert();

            return Ok(alert);

        }
    }
}
