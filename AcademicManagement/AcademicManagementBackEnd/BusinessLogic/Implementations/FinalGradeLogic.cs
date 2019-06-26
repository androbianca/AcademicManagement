using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Implementations
{
    public class FinalGradeLogic : BaseLogic, IFinalGradeLogic
    {
        public FinalGradeLogic(IRepository repository)
            : base(repository)
        {
        }



        public FinalGrade Update(FinalGradeDto finalGradeDto)
        {
            var finalGrade = _repository.GetByFilter<FinalGrade>(x => x.StudentId == finalGradeDto.StudentId && x.CourseId == finalGradeDto.CourseId);

            if (finalGrade == null)
            {
                return null;
            }

            finalGrade.Value = finalGradeDto.Value;
            _repository.Update(finalGrade);
            _repository.Save();

            return finalGrade;
        }


        public void AddFinalGradeToMandatoryCourses(Guid studentId)
        {
            var stud = _repository.GetByFilter<Student>(x => x.Id == studentId);
            var group = _repository.GetByFilter<Group>(x => x.Id == stud.GroupId);
            var courses = _repository.GetAllByFilter<Course>(x => x.Package == null && x.Year == group.Year);

            foreach (var course in courses)
            {
                var finalGrade = new FinalGrade
                {
                    CourseId = course.Id,
                    StudentId = studentId,
                    Value = 0
                };

                _repository.Insert(finalGrade);
                _repository.Save();
            }

        }

        public void AddFinalGradeToOptionalCourses(Guid studentId, Guid courseId)
        {
            {
                var finalGrade = new FinalGrade
                {
                    CourseId = courseId,
                    StudentId = studentId,
                    Value = 0
                };

                _repository.Insert(finalGrade);
                _repository.Save();
            }

        }


        public void AddAll()
        {
            var students = _repository.GetAll<Student>();
            var courses = _repository.GetAllByFilter<Course>(x => x.Package == null);

            foreach (var student in students)
            {
                var optionals = _repository.GetAllByFilter<StudCourse>(x => x.StudId == student.Id);

                foreach (var optional in optionals)
                {
                    var finalGrade = new FinalGrade
                    {
                        CourseId = optional.CourseId,
                        StudentId = student.Id,
                        Value = 0
                    };

                    _repository.Insert(finalGrade);
                    _repository.Save();
                }

                foreach (var course in courses)
                {
                    var finalGrade = new FinalGrade
                    {
                        CourseId = course.Id,
                        StudentId = student.Id,
                        Value = 0
                    };

                    _repository.Insert(finalGrade);
                    _repository.Save();
                }

            }
        }


        public IEnumerable<FinalGradeDto> GetAllByCourseId(Guid courseId)
        {
            var gradeDtos = new List<FinalGradeDto>();
            var grades = _repository.GetAllByFilter<FinalGrade>(x => x.CourseId == courseId);

            foreach (var grade in grades)
            {
                var finalGrade = new FinalGradeDto
                {
                    Value = grade.Value
                };

                if (finalGrade.Value > 0)
                {
                    gradeDtos.Add(finalGrade);
                }

            }

            return gradeDtos;
        }
    }
}
