using System;
using System.Collections.Generic;
using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface ICourseLogic
    {
        ICollection<Course> getOptionalCourses();
        ICollection<CourseDto> GetAll();
        Course Add(CourseDto course);
        ICollection<CourseDto> GetStudCourses(string id);
        ICollection<CourseDto> GetProfCourses(Guid id);
        Course Remove(Guid courseId);

    }
}
