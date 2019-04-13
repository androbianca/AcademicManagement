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

            return mapCourses(courses);

        }

        public ICollection<CourseDto> GetStudCourses(String id)
        {
            var userCourses = new List<Course>();

            var studentId = _repository.GetByFilter<Student>(x => x.UserCode == id)?.PotentialUserId;
            var currentpotentialUser = _repository.GetByFilter<PotentialUser>(x => x.Id == studentId);

            var mandatoryCourses = getMandatoryCourses(currentpotentialUser.Year.Value);
            var optionalCourses = getCoursesByUserId(currentpotentialUser.Id);
          
            userCourses.AddRange(mandatoryCourses);
            userCourses.AddRange(optionalCourses);

            return filterCourses(mapCourses(userCourses), currentpotentialUser.Year.Value);
        }

        public ICollection<CourseDto> GetProfCourses(String id)
        {
          
            var professorId = _repository.GetByFilter<Professor>(x => x.UserCode == id)?.PotentialUserId;
            var currentUser = _repository.GetByFilter<PotentialUser>(x => x.Id == professorId);
            var courses = getCoursesByUserId(currentUser.Id);

            return mapCourses(courses);
        }

        private ICollection<CourseDto> filterCourses(ICollection<CourseDto> courses, int year)
        {
            var endOfFirstSemester = new DateTime(DateTime.Today.Year, 2, 18);
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

        private ICollection<Course> getCoursesByUserId(Guid id)
        {
            var optionalCourses = new List<Course>();
            var potentialUserCourses = _repository.GetAllByFilter<PotentialUserCourse>(x => x.PotentialUserId == id);
            foreach (var course in potentialUserCourses)
            {
                var optionalCourse = _repository.GetByFilter<Course>(x => x.Id == course.CourseId);
                optionalCourses.Add(optionalCourse);
            }

            return optionalCourses;
        }

        private ICollection<Course> getMandatoryCourses(int year)
        {
            var mandatoryCourses = _repository.GetAllByFilter<Course>(x => x.Package == null && x.Year <= year);
            return mandatoryCourses;
        }

        private ICollection<CourseDto> mapCourses(ICollection<Course> courses)
        {
            var courseDtos = new List<CourseDto>();

            foreach (var course in courses)
            {
                var courseDto = new CourseDto
                {
                    Id = 
                    Name = course.Name,
                    Year = course.Year,
                    Semester = course.Semester,
                    Package = course.Package
                };

                courseDtos.Add(courseDto);
            }

            return courseDtos;
        }
    }
}
