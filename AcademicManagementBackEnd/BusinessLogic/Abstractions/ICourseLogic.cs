using System.Collections.Generic;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface ICourseLogic
    {
        ICollection<CourseDto> GetAll();
        ICollection<CourseDto> GetStudCourses(string id);
        ICollection<CourseDto> GetProfCourses(string id);

    }
}
