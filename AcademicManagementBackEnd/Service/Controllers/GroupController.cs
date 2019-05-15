﻿using System;
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

        [HttpPost]
        public ActionResult Add(GroupDto groupDto)
        {

            var group = _groupLogic.Add(groupDto);
            return Ok(group);
        }

        [HttpDelete("{groupId:guid}")]
        public IActionResult Remove([FromRoute] Guid groupId)
        {

            var group = _groupLogic.Remove(groupId);

            return Ok(group);
        }

    }
}
