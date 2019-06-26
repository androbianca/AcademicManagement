using Entities;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IGradeLogic
    {
        ICollection<GradeDto> GetGradesByStud(Guid studentId, Guid courseId);
        double ComputeFinalGrade(Guid courseId, Guid studentId);
        Grade Add(GradeDto grade);
        GradeDto GetById(Guid gradeId);
        Grade Update(GradeDto gradeDto);
    }
}
