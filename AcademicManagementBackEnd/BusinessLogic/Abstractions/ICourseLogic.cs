using System.Collections.Generic;
using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface ICourseLogic
    {
        ICollection<CourseDto> GetAll();
        ICollection<CourseDto> GetByYear(string id);
    
    }
}
