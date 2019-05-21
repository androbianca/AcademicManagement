using System;
using System.Collections.Generic;
using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Service.Controllers
{

    [Route("api/feedback")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {


        private readonly IFeedbackLogic _feedbackLogic;

        public FeedbackController(IFeedbackLogic feedbackLogic)
        {
            _feedbackLogic = feedbackLogic;
        }

        [HttpPost]
        public IActionResult AddFeedback(FeedbackDto feedbackDto)
        {

            var result = _feedbackLogic.Add(feedbackDto);

            return Ok(result);
        }

        [HttpGet("{profId:guid}")]
        public ActionResult<ICollection<FeedbackDto>> GetByProfId([FromRoute] Guid profId)
       {

            var result = _feedbackLogic.GetByProfId(profId);

            return Ok(result);
        }

    }
}
