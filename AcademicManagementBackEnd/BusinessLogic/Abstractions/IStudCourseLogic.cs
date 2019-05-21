using Entities;
using Models;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IStudCourseLogic
    {
        IEnumerable<StudCourse> Add(IEnumerable<StudCourseDto> studCourseDto);
    }
}
