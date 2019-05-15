using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IGradeLogic
    {
        ICollection<GradeDto> GetGradesByStud(Guid studentId, Guid profId, Guid courseId);
        ICollection<GradeDto> GetGradesByProf(Guid studentId, Guid courseId);
        void Add(GradeDto grade);
    }
}
