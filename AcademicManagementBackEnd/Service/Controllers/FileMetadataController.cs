using BusinessLogic.Abstractions;
using BusinessLogic.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FileMetadataController : ControllerBase
    {
        private readonly IFileMetadataLogic _fileMetadataLogic;

        public FileMetadataController(IFileMetadataLogic fileMetadataLogic)
        {
            _fileMetadataLogic = fileMetadataLogic;
        }

        [HttpGet("{courseId:guid}/upload")]
        public ActionResult UploadPage(List<IFormFile> files)
        {
            return File("~/UploadPage.html", "text/html");
        }

        [HttpPost("{courseId:guid}/{isExcel:bool}/upload")]
        public async Task<IActionResult> UploadFilesTask([FromRoute] Guid courseId, [FromRoute] bool isExcel)
        {
            var file = Request.Form.Files[0];

            var id = getCurrentUserId();

            var fileDto = await _fileMetadataLogic.UploadFiles(courseId, file, isExcel, id);

            if (fileDto == null)
                return NotFound("Course not found!");
            if (!isExcel)
            {
                var newFile = _fileMetadataLogic.Create(fileDto);
                return Ok(newFile);
            }

            return Ok(null);
        }

        [HttpPut("{fileId:guid}")]
        public IActionResult Update([FromBody] FileMetadataDto fileMetadataDto, [FromRoute] Guid fileId)
        {
            var result = _fileMetadataLogic.Update(fileMetadataDto, fileId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{fileId:guid}")]
        public IActionResult Delete([FromRoute] Guid fileId)
        {
            var result = _fileMetadataLogic.Delete(fileId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{fileId:guid}")]
        public IActionResult GetById([FromRoute] Guid fileId)
        {
            var file = _fileMetadataLogic.GetFile(fileId, this);

            if (file == null)
            {
                return NotFound();
            }

            return file;
        }

        [HttpGet("{courseId:guid}")]
        public IActionResult GetByCourseId([FromRoute] Guid courseId)
        {
            var result = _fileMetadataLogic.GetByCourseId(courseId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public ICollection<FileMetadataDto> GetAll()
        {
            var result = _fileMetadataLogic.GetAll();

            return result;
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
