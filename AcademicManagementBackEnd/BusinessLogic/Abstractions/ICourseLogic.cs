using System.Collections.Generic;
using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface ICourseLogic
    {
        ICollection<CourseDto> GetAll();
        Course AddCourse(CourseDto course);
        ICollection<CourseDto> GetStudCourses(string id);
        ICollection<CourseDto> GetProfCourses(string id);

    }
}
