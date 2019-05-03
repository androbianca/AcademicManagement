using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Implementations
{
    public class GradeLogic :BaseLogic, IGradeLogic
    {
        public GradeLogic(IRepository repository)
            : base(repository)
        {  }

        public ICollection<GradeDto> getGrades(Guid studentId, Guid profId, Guid courseId)
        {
            var gradeDtos = new List<GradeDto>();
            var grades = _repository.GetAllByFilter<Grade>(x => x.CourseId == courseId && x.StudentId == studentId && x.ProfId == profId);
           
            foreach (var grade in grades)
            {
                var gradeDto = new GradeDto
                {
                    Value = grade.Value
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
