using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IGradeLogic
    {
        ICollection<GradeDto> GetGradesByStud(Guid studentId, Guid courseId);
        float ComputeLabFinalGrade(Guid courseId, Guid studentId);
        void Add(GradeDto grade);
        GradeDto GetById(Guid gradeId);
    }
}
