using System;
using System.Collections.Generic;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface IStudentLogic
    {
        ICollection<StudentDto> getByProfId(string userCode, Guid courseId);
    }
}
