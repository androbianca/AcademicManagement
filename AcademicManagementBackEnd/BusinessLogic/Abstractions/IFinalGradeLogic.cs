using Entities;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IFinalGradeLogic
    {
        void AddFinalGradeToMandatoryCourses(Guid studentId);
        void AddFinalGradeToOptionalCourses(Guid studentId, Guid courseId);
        void AddAll();
        FinalGrade Update(FinalGradeDto finalGradeDto);
        IEnumerable<FinalGradeDto> GetAllByCourseId(Guid courseId);
    }
}
