using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface IStudentLogic
    {
        ICollection<StudentDto> getByProfId(string id);
    }
}
