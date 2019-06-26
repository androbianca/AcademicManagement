using System;
using System.Collections.Generic;
using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Service.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupLogic _groupLogic;

        public GroupController(IGroupLogic groupLogic)
        {
            _groupLogic = groupLogic;
        }

        [HttpGet]
        public ActionResult<ICollection<GroupDto>> GetAll()
        {

            var groups = _groupLogic.GetAll();

            return Ok(groups);
        }


        [HttpGet("{groupId}")]
        public ActionResult<GroupDto> GetById([FromRoute] Guid groupId)
        {

            var group = _groupLogic.GetById(groupId);

            return Ok(group);
        }

        [HttpPost]
        public ActionResult Add(GroupDto groupDto)
        {

            var group = _groupLogic.Add(groupDto);
            return Ok(group);
        }

        [HttpGet("{profId:guid}/{courseId:guid}")]
        public ActionResult<IEnumerable<GroupDto>> Add([FromRoute] Guid profId, [FromRoute] Guid courseId)
        {
            var groups = _groupLogic.getProfGroups(profId, courseId);
            return Ok(groups);
        }

        [HttpDelete("{groupId:guid}")]
        public IActionResult Remove([FromRoute] Guid groupId)
        {

            var group = _groupLogic.Remove(groupId);

            return Ok(group);
        }

    }
}
