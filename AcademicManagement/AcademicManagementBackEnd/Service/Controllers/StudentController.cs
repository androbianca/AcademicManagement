﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using BusinessLogic.Abstractions;
using Entities;
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
        public ActionResult<StudentDto> GetByUserCode([FromRoute] string usercode)
        {
            if (usercode == null)
            {
                return null;
            }
            var student = _studentLogic.GetByUserCode(usercode);

            return Ok(student);
        }


        [HttpGet("{id:guid}")]
        public ActionResult<StudentDto> GetById([FromRoute] Guid id)
        {
            if(id == null)
            {
                return null;
            }
            var student = _studentLogic.GetById(id);

            return Ok(student);
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


        [HttpPost("edit")]
        public ActionResult<Student> Edit([FromBody] StudentDto studentDto)
        {

            var student = _studentLogic.Update(studentDto);

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
