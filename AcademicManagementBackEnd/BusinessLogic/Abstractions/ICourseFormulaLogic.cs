using Entities;
using Models;
using System;

namespace BusinessLogic.Abstractions
{
    public interface ICourseFormulaLogic
    {
        CourseFormula Add(CourseFormulaDto courseFormulaDto);
        CourseFormula Edit(CourseFormulaDto courseFormulaDto);
        CourseFormulaDto GetFormulaByCourseId(Guid courseId);
    }
}
