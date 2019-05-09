using System;
using System.Collections.Generic;
using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface IStudentLogic
    {
        ICollection<StudentDto> getByProfId(string userCode, Guid courseId);
        Student addStud(StudentDto studentDto);
    }
}
