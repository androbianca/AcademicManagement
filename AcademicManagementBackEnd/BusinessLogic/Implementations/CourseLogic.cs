using System;
using System.Collections.Generic;
using System.Linq;
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

        public ICollection<CourseDto> GetByYear(String id)
        {

            var currentUser = _repository.GetByFilter<Student>(x => x.StudentCode == id);
            var currentpotentialUser = _repository.GetByFilter<PotentialUser>(x => x.Id == currentUser.PotentialUserId);

            var mandatoryCourses = getMandatoryCourses(currentpotentialUser.Year);
            var optionalCourses = getOptionalCourses(currentpotentialUser.Id);

            var courseDtos = new List<CourseDto>();
            var userCourses = new List<Course>();
            userCourses.AddRange(mandatoryCourses);
            userCourses.AddRange(optionalCourses);

            foreach (var userCourse in userCourses)
            {
                var userCourseDto = new CourseDto
                {
                    Name = userCourse.Name,
                    Year = userCourse.Year,
                    Semester = userCourse.Semester,
                    Pachage = userCourse.Package
                };

                courseDtos.Add(userCourseDto);
            }

            return filterCourses(courseDtos, currentpotentialUser.Year);
        }



        private ICollection<CourseDto> filterCourses(ICollection<CourseDto> courses,int year)
        {
            var endOfFirstSemester = new DateTime(DateTime.Today.Year, 7, 18);
            List<CourseDto> ongoingCourses = new List<CourseDto>();

            if (DateTime.Now < endOfFirstSemester)
            {
                foreach (var course in courses)
                {
                    if (course.Year != year || (course.Year == year && course.Semester == 1))
                    {
                        ongoingCourses.Add(course);
                    }                
                }

                return ongoingCourses;
            }

            return courses;
        }

        private ICollection<Course> getOptionalCourses(Guid id)
        {   var optionalCourses = new List<Course>();
            var pUserOptionalCourses = _repository.GetAllByFilter<PUserOptionalCourse>(x => x.PotentialUserId == id);
            foreach (var optional in pUserOptionalCourses)
            {
                var optionalCourse =_repository.GetByFilter<Course>(x => x.Id == optional.OptionalCourseId);    
                optionalCourses.Add(optionalCourse);
            }

            return optionalCourses;
        }

        private ICollection<Course> getMandatoryCourses(int year)
        {
            var mandatoryCourses = _repository.GetAllByFilter<Course>(x => x.Package == null && x.Year <= year);

            return mandatoryCourses;
        }
    }
}
