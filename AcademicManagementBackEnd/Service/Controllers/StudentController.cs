using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Service.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _studentLogic;

        public StudentController(IStudentLogic studentLogic)
        {
            _studentLogic = studentLogic;
        }

        [HttpGet("course/{courseId:guid}")]
        public ActionResult<ICollection<StudentDto>> GetStudentsByProfId([FromRoute] Guid courseId)
        {
            var id = getCurrentUserId();

            var students = _studentLogic.GetByProfId(id,courseId);

            return Ok(students);

        }

        [HttpGet]
        public ActionResult<ICollection<StudentDto>> GetAll()
        {
            var students = _studentLogic.GetAll();

            return Ok(students);
        }

        [HttpGet("{usercode}")]
        public ActionResult<StudentDto> GetById([FromRoute] string usercode)
        {
            var students = _studentLogic.GetById(usercode);

            return Ok(students);
        }

        [HttpDelete("{studentId:guid}")]
        public IActionResult Remove([FromRoute] Guid studentId)
        {
            var student = _studentLogic.Remove(studentId);

            return Ok(student);
        }

        [HttpPost]
        public ActionResult<StudentDto> Add([FromBody] StudentDto studentDto)
        {

            var student = _studentLogic.Add(studentDto);

            return Ok(student);
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
