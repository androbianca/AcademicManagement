using BusinessLogic.Abstractions;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [Route("/api/timer")]
    [ApiController]

    public class SchedulersController : Controller
    {
        [HttpPost]
        public IActionResult SendMailHourly()
        {

            RecurringJob.AddOrUpdate<ISchedulerLogic>(service => service.SendAlert(), Cron.Hourly);
            return Ok();
        }

        private string GetCurrentUser()
        {


            return "1";
        }
    }
}
