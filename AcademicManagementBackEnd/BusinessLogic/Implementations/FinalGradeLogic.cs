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

        public void Add(Guid studentId, Guid courseId)
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

        

        public void AddAll()
        {
            var students = _repository.GetAll<Student>();
            var courses = _repository.GetAllByFilter<Course>(x => x.Package == null);

            foreach(var student in students){
                foreach(var course in courses)
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

        public void Update(FinalGrade grade)
        {


            _repository.Update(grade);
            _repository.Save();

        }

        public IEnumerable<FinalGradeDto> GetAllByCourseId(Guid courseId)
        {
            var gradeDtos = new List<FinalGradeDto>();
            var grades = _repository.GetAllByFilter<FinalGrade>(x => x.CourseId == courseId);

            foreach(var grade in grades)
            {
                var finalGrade = new FinalGradeDto
                {
                    Value = grade.Value
                };

                gradeDtos.Add(finalGrade);

            }

            return gradeDtos;
        }
    }
}
