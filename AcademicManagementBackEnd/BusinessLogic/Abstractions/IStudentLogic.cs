using System;
using System.Collections.Generic;
using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface IStudentLogic
    {
        ICollection<StudentDto> GetByProfId(string userCode, Guid courseId);
        ICollection<StudentDto> GetAll();
        Student Add(StudentDto studentDto);
        Student Remove(Guid studentId);
        StudentDto GetByUserCode(string userCode);
        StudentDto GetById(Guid id);
        Student Update(StudentDto studentDto);

    }
}
