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

            var id = GetCurrentUser();
            RecurringJob.AddOrUpdate<ISchedulerLogic>(service => service.SendAlert(id), Cron.MinuteInterval(2));
            return Ok();
        }

        private string GetCurrentUser()
        {


            return "1";
        }
    }
}
