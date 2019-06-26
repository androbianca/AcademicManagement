using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Implementations
{
    public class StudCourseLogic : BaseLogic, IStudCourseLogic
    {
        private IFinalGradeLogic _finalGradeLogic;
        public StudCourseLogic(IRepository repository, IFinalGradeLogic finalGradeLogic)
            : base(repository)
        {
            _finalGradeLogic = finalGradeLogic;
        }

        public IEnumerable<StudCourse> Add(IEnumerable<StudCourseDto> studCourseDtos)
        {
            var studCourses = new List<StudCourse>();
            foreach (var studCourseDto in studCourseDtos)
            {
                var studCourse = new StudCourse
                {   Id = Guid.NewGuid(),
                    CourseId = studCourseDto.CourseId,
                    StudId = studCourseDto.StudId
                };
                _finalGradeLogic.AddFinalGradeToOptionalCourses(studCourseDto.StudId, studCourseDto.CourseId);

                _repository.Insert(studCourse);
                _repository.Save();
                studCourses.Add(studCourse);
            }

            return studCourses;
        }

        public IEnumerable<StudCourseDto> GetByStudentId(Guid studId)
        {
            var studCourses = _repository.GetAllByFilter<StudCourse>(X => X.StudId == studId);
            var studCourseDtos = new List<StudCourseDto>();

            foreach (var studCourse in studCourses)
            {
                var studCourseDto = new StudCourseDto
                {
                    CourseId = studCourse.CourseId,
                    StudId = studCourse.StudId,
                    Id = studCourse.Id
                };

                studCourseDtos.Add(studCourseDto);
            }

            return studCourseDtos;
        }

        public StudCourse Delete(Guid studCourseId)
        {
            var studCourse = _repository.GetByFilter<StudCourse>(X => X.Id == studCourseId);
            _repository.Delete(studCourse);
            _repository.Save();

            return studCourse;
        }

    }
}
