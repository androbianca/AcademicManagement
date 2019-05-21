using BusinessLogic.Abstractions;
using BusinessLogic.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
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

        [HttpPost("{courseId:guid}/upload")]
        public async Task<IActionResult> UploadFilesTask([FromRoute] Guid courseId)
        {
            var file = HttpContext.Request.Form;
            var fileDto = await _fileMetadataLogic.UploadFiles(courseId, null);

            if (fileDto == null)
                return NotFound("Course not found!");

            var newFile = _fileMetadataLogic.Create(fileDto);

            return CreatedAtAction(nameof(GetById), new { fileEntityId = newFile.Id }, fileDto);
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
    }
}
