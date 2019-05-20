using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
using System.Collections.Generic;

namespace BusinessLogic.Implementations
{
    public class StudCourseLogic : BaseLogic, IStudCourseLogic
    {
        public StudCourseLogic(IRepository repository)
            : base(repository)
        { }

        public IEnumerable<StudCourse> Add(IEnumerable<StudCourseDto> studCourseDtos)
        {
            var studCourses = new List<StudCourse>();
            foreach (var studCourseDto in studCourseDtos)
            {
                var studCourse = new StudCourse
                {
                    CourseId = studCourseDto.CourseId,
                    StudId = studCourseDto.StudId
                };

                _repository.Insert(studCourse);
                _repository.Save();
                studCourses.Add(studCourse);
            }
            

            return studCourses;
        }

    }
}
