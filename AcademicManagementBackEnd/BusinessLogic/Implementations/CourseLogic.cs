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

        public Course Add(CourseDto courseDto)
        {
            var course = new Course
            {
                Id = Guid.NewGuid(),
                IsDeleted = false,
                Name = courseDto.Name,
                Package = courseDto.Package,
                Year = courseDto.Year,
                Semester = courseDto.Semester

            };
            _repository.Insert(course);
            _repository.Save();
            return course;
        }

        public CourseDto GetById(Guid courseId)
        {
            var course = _repository.GetByFilter<Course>(x => x.Id == courseId);

            var courseDto = new CourseDto
            {
                Id = Guid.NewGuid(),
                IsDeleted = false,
                Name = course.Name,
                Package = course.Package,
                Year = course.Year,
                Semester = course.Semester

            };

            return courseDto;
        }


        public Course Remove(Guid courseId)
        {
            var course = _repository.GetByFilter<Course>(x => x.Id == courseId);
            course.IsDeleted = true;

            _repository.Update(course);
            _repository.Save();

            return course;

        }

        public ICollection<CourseDto> GetStudCourses(String id)
        {
            var optionalCourses = new List<Course>();
            var userCourses = new List<Course>();

            var account = _repository.GetByFilter<Account>(x => x.UserCode == id);
            var currentUser = _repository.GetByFilter<Student>(x => x.PotentialUserId == account.PotentialUserId);
            var group = _repository.GetByFilter<Group>(x => x.Id == currentUser.GroupId);

            var studCourses = _repository.GetAllByFilter<StudCourse>(x => x.StudId == currentUser.Id);
            if (studCourses == null)
            {
                return null;
            }

            foreach (var studCourse in studCourses)
            {
                var course = _repository.GetByFilter<Course>(x => x.Id == studCourse.CourseId);
                optionalCourses.Add(course);
            }

            var mandatoryCourses = getMandatoryCourses(group.Year);

            userCourses.AddRange(mandatoryCourses);
            userCourses.AddRange(optionalCourses);

            return filterCourses(mapCourses(userCourses), group.Year);
        }

        public ICollection<CourseDto> GetProfCourses(Guid id)
        {
            var courses = new List<Course>();
            var currentUser = _repository.GetByFilter<Professor>(x => x.Id == id);
            var profCourses = _repository.GetAllByFilter<ProfStuds>(x => x.ProfId == currentUser.Id);

            if (profCourses == null)
            {
                return null;
            }

            foreach (var profCourse in profCourses)
            {
                var course = _repository.GetByFilter<Course>(x => x.Id == profCourse.CourseId);

                var addCourse = courses.Find(X => X.Id == course.Id);

                if (addCourse == null)
                {
                    courses.Add(course);
                }
            }

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

        private ICollection<Course> getMandatoryCourses(int year)
        {
            var mandatoryCourses = _repository.GetAllByFilter<Course>(x => x.Package == null && x.Year <= year);
            return mandatoryCourses;
        }

        public ICollection<Course> getOptionalCourses()
        {
            var optionalCourses = _repository.GetAllByFilter<Course>(x => x.Package != null);
            return optionalCourses;
        }

        private ICollection<CourseDto> mapCourses(ICollection<Course> courses)
        {
            var courseDtos = new List<CourseDto>();

            foreach (var course in courses)
            {
                var courseDto = new CourseDto
                {
                    Id = course.Id,
                    IsDeleted = course.IsDeleted,
                    Name = course.Name,
                    Year = course.Year,
                    Semester = course.Semester,
                    Package = course.Package
                };

                courseDtos.Add(courseDto);
            }

            return courseDtos;
        }

        public Course Update(CourseDto courseDto)
        {
            var course = _repository.GetByFilter<Course>(X => X.Id == courseDto.Id);

            course.Name = courseDto.Name;
            course.Year = courseDto.Year;
            course.Semester = courseDto.Semester;
            course.Package = courseDto.Package;

            _repository.Update(course);
            _repository.Save();

            return course;
        }
    }
}