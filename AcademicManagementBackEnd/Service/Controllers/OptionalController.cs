using BusinessLogic;
using BusinessLogic.Abstractions;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    [ApiController]
    [Route("api/optionals")]
    public class OptionalController : ControllerBase
    {
        private readonly IOptionalLogic _optionalLogic;

        public OptionalController(IOptionalLogic optionalLogic)
        {
            _optionalLogic = optionalLogic;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFilesTask()
        {
            var file = Request.Form.Files[0];
            var link = Request.Form.Keys.ToArray()[0];
            var date = Request.Form.Keys.ToArray()[1];

    
           var optional = await _optionalLogic.UploadFiles(file,link,date);

            if (optional == null)
                return NotFound("Course not found!");
           
           

            return Ok(optional);
        }

        [HttpGet]
        public ICollection<OptionalDto> GetAll()
        {
            var result = _optionalLogic.GetAll();

            return result;
        }

        [HttpDelete("{itemId}")]
        public ActionResult<Optional> Delete ([FromRoute] Guid itemId)
        {
            var result = _optionalLogic.Delete(itemId);
            return Ok(result);
        }
    }
}
