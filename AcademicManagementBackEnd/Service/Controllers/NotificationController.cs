using BusinessLogic.Abstractions;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Controllers
{

    [Route("api/notifications")]
    [ApiController]
    public class NotificationController: ControllerBase
    {
        private readonly INotificationLogic _notificationLogic;

        public NotificationController(INotificationLogic notificationLogic)
        {
            _notificationLogic = notificationLogic;
        }

       [HttpPost]
       public ActionResult<Notification> AddNotification(NotificationDto notification)
        {
            var id = getCurrentUserId();

            var result =  _notificationLogic.Create(notification);

            return Ok(result);
        }

        [HttpGet]
        public ActionResult<ICollection<Notification>> Get()
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
