﻿using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;

namespace Service.Controllers
{
    [Route("api/profs")]
    [ApiController]
    public class ProfController : ControllerBase
    {
        private readonly IProfLogic _profLogic;

        public ProfController(IProfLogic profLogic)
        {
            _profLogic = profLogic;
        }

        [HttpGet]
        public ActionResult<ICollection<ProfDto>> GetAll()
        {

            var profs = _profLogic.GetAll();

            return Ok(profs);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProfDto profDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prof = _profLogic.Add(profDto);

            return Ok(prof);
        }

        [HttpDelete("{profId:guid}")]
        public IActionResult Remove([FromRoute] Guid profId)
        {
            var result = _profLogic.Remove(profId);

            if (result == null)
            {
                return NotFound();
            }
     
            return Ok(result);
        }

    }
}
