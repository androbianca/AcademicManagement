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

        [HttpGet("{courseId:guid}")]
        public ActionResult<ICollection<StudentDto>> getStudents([FromRoute] Guid courseId)
        {
            var id = getCurrentUserId();

            var students = _studentLogic.getByProfId(id,courseId);

            return Ok(students);

        }

        [HttpPost]
        public ActionResult<StudentDto> AddStud([FromBody] StudentDto studentDto)
        {

            var student = _studentLogic.addStud(studentDto);

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
