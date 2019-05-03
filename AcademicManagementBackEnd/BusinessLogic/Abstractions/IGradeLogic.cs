using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IGradeLogic
    {
        ICollection<GradeDto> getGrades(Guid studentId, Guid profId, Guid courseId);
       void addGrade(GradeDto grade);
    }
}
