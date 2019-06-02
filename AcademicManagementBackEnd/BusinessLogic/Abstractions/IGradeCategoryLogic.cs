using Entities;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IGradeCategoryLogic
    {
         GradeCategory Add(GradeCategoryDto gradeCategoryDto);
        IEnumerable<GradeCategoryDto> GetByCourseId(Guid courseId);

    }
}
