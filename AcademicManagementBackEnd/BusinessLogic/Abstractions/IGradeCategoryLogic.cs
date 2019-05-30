using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Abstractions
{
   public interface IGradeCategoryLogic
    {
         GradeCategory Add(GradeCategoryDto gradeCategoryDto);
        IEnumerable<GradeCategoryDto> GetByCourseId(Guid courseId);

    }
}
