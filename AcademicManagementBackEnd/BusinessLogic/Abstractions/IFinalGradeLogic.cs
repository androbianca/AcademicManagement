using Entities;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IFinalGradeLogic
    {
        void Add(Guid studentId, Guid courseId);
        void AddAll();
        void Update(FinalGrade grade);
        IEnumerable<FinalGradeDto> GetAllByCourseId(Guid courseId);
    }
}
