using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
using System;

namespace BusinessLogic.Implementations
{
    public class CourseFormulaLogic : BaseLogic, ICourseFormulaLogic
    {
        public CourseFormulaLogic(IRepository repository) : base(repository)
        {
        }

        public CourseFormula Add(CourseFormulaDto courseFormulaDto)
        {
            var courseFormula = new CourseFormula
            {
                Id = Guid.NewGuid(),
                CourseId = courseFormulaDto.CourseId,
                Formula = courseFormulaDto.Formula
            };

            _repository.Insert(courseFormula);
            _repository.Save();

            return courseFormula;
        }

        public CourseFormula Edit(CourseFormulaDto courseFormulaDto)
        {
            var courseFormula = _repository.GetByFilter<CourseFormula>(x => x.Id == courseFormulaDto.Id);

            courseFormula.Formula = courseFormulaDto.Formula;

            _repository.Update(courseFormula);
            _repository.Save();

            return courseFormula;
        }

        public CourseFormulaDto GetFormulaByCourseId(Guid courseId)
        {
            var courseFormula = _repository.GetByFilter<CourseFormula>(x => x.CourseId == courseId);

            if(courseFormula == null)
            {
                return null;
            }

            var courseFormulaDto = new CourseFormulaDto
            {
                Id = courseFormula.Id,
                CourseId = courseFormula.CourseId,
                Formula = courseFormula.Formula
            };

            return courseFormulaDto;

        }
    }
}
