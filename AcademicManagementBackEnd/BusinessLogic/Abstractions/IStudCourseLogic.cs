using BusinessLogic.Implementations;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Abstractions
{
    public interface IStudCourseLogic
    {
        IEnumerable<StudCourse> Add(IEnumerable<StudCourseDto> studCourseDto);
    }
}
