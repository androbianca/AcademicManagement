using System.Collections.Generic;
using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;

namespace BusinessLogic.Implementations
{
    public class CourseLogic : BaseLogic, ICourseLogic
    {
        public CourseLogic(IRepository repository)
            : base(repository)
        {
        }
        public ICollection<CourseDto> GetAll()
        {
            var courses = _repository.GetAll<Course>();
            var courseDtos = new List<CourseDto>();
            foreach (var course in courses)
            {
                var courseDto = new CourseDto
                {
                    Name = course.Name,
                    Year = course.Year,
                    Semester = course.Semester
                };

                courseDtos.Add(courseDto);
            }
            return courseDtos;
        }

        public ICollection<CourseDto> GetByYear(int year)
        {
            var courses = _repository.GetAllByFilter<Course>(x => x.Year <= year);
            var courseDtos = new List<CourseDto>();
            foreach (var course in courses)
            {
                var courseDto = new CourseDto
                {
                    Name = course.Name,
                    Year = course.Year,
                    Semester = course.Semester
                };

                courseDtos.Add(courseDto);
            }
            return courseDtos;
        }
    }
}
