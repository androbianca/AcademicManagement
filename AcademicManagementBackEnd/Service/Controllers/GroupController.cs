using System.Collections.Generic;
using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Service.Controllers
{
    [Route("api/group")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupLogic _groupLogic;

        public GroupController(IGroupLogic groupLogic)
        {
            _groupLogic = groupLogic;
        }

        [HttpGet]
        public ActionResult<ICollection<GradeDto>> getAll()
        {

            var groups = _groupLogic.getAll();

            return Ok(groups);
        }
    }
}
