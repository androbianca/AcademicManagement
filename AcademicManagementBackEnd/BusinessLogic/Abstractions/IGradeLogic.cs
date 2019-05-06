using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IGradeLogic
    {
        ICollection<GradeDto> getGrades(Guid studentId, Guid profId, Guid courseId);
        ICollection<GradeDto> getGrades2(Guid studentId, Guid courseId);
        void addGrade(GradeDto grade);
    }
}
