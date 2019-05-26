using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Service.Controllers
{

    [Route("api/notify")]
    [ApiController]
    public class NotificationController: ControllerBase
    {
        private readonly INotificationLogic _notificationLogic;

        public NotificationController(INotificationLogic notificationLogic)
        {
            _notificationLogic = notificationLogic;
        }

       [HttpPost]
       public IActionResult AddNotification(NotificationDto notification)
        {
            var id = getCurrentUserId();

            var result =  _notificationLogic.Create(notification);

            return Ok(result);
        }

        [HttpGet]
        public ActionResult<ICollection<NotificationDto>> Get()
        {
            var id = getCurrentUserId();

            var result = _notificationLogic.GetUserNotifications(id);

            return Ok(result);
        }

        private string getCurrentUserId()
        {
            var headerValue = Request.Headers["Authorization"];
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadToken(headerValue) as JwtSecurityToken;
            var id = token.Claims.FirstOrDefault(c => c.Type == "Identifier").Value;

            return id;

        }
    }
}
