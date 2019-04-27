using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Implementations
{
    public class GradeLogic :BaseLogic, IGradeLogic
    {
        public GradeLogic(IRepository repository)
            : base(repository)
        {  }

        public ICollection<GradeDto> getGrades(Guid courseId,Guid studentId, Guid profId)
        {
            var gradeDtos = new List<GradeDto>();
            var grades = _repository.GetAllByFilter<Grade>(x => x.CourseId == courseId && x.StudentId == studentId && x.ProfId == profId);
           
            foreach (var grade in grades)
            {
                var gradeDto = new GradeDto
                {
                    Value = grade.Value,
                    Category = grade.Category,
                    StudentId = grade.StudentId,
                    ProfId = grade.ProfId,
                    CourseId = grade.CourseId
                  
                };

                gradeDtos.Add(gradeDto);
            }

            return gradeDtos;
        }

        public ICollection<GradeDto> getGrades2(Guid courseId, Guid studentId)
        {
            var gradeDtos = new List<GradeDto>();
            var grades = _repository.GetAllByFilter<Grade>(x => x.CourseId == courseId && x.StudentId == studentId);

            foreach (var grade in grades)
            {
                var gradeDto = new GradeDto
                {
                    Value = grade.Value,
                    Category = grade.Category,
                    StudentId = grade.StudentId,
                    ProfId = grade.ProfId,
                    CourseId = grade.CourseId

                };

                gradeDtos.Add(gradeDto);
            }

            return gradeDtos;
        }
        public void addGrade(GradeDto gradeDto)
        {
            var grade = new Grade()
            {
                StudentId = gradeDto.StudentId,
                ProfId = gradeDto.ProfId,
                CourseId = gradeDto.CourseId,
                Value = gradeDto.Value,
                Category = gradeDto.Category
            };
            _repository.Insert(grade);
            _repository.Save();
        }
    }
}
