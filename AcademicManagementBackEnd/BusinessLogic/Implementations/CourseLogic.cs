using System;
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

            return filterCourses(courseDtos);
        }

        private ICollection<CourseDto> filterCourses(ICollection<CourseDto> courses)
        {
            var currentDate = DateTime.Now;
            var courseDtos = new List<CourseDto>();
            var currentYear = DateTime.Today.Year;
            var endOfFirstSemester = new DateTime(currentDate.Year,2,18);
            if (currentDate < endOfFirstSemester)
            {
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

            return courses;
        }
    }
}
