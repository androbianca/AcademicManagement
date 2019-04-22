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
    }
}
