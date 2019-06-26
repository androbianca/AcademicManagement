using Entities;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IStudCourseLogic
    {
        IEnumerable<StudCourse> Add(IEnumerable<StudCourseDto> studCourseDto);
        StudCourse Delete(Guid studCourseId);
        IEnumerable<StudCourseDto> GetByStudentId(Guid studId);

    }
}
