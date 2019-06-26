using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Service.Controllers
{

    [ApiController]
    [Route("api/userroles")]
    public class UserRoleController : ControllerBase
    {

        private readonly IUserRoleLogic _userRoleLogic;

        public UserRoleController(IUserRoleLogic userRoleLogic)
        {
            _userRoleLogic = userRoleLogic;
        }

        [HttpGet("student")]
        public IActionResult GetStudRoleId()
        {
            var role = _userRoleLogic.getStudentRoleId();

            return Ok(role);
        }

        [HttpGet("professor")]
        public IActionResult GetProfRoleId()
        {
            var role = _userRoleLogic.getProfRoleId();

            return Ok(role);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetByUd([FromRoute] Guid id)
        {
            var role = _userRoleLogic.getById(id);

            return Ok(role);
        }
    }
}