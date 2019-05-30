using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BusinessLogic.Implementations
{
    public class GardeCategoryLogic : BaseLogic, IGradeCategoryLogic
    {
        public GardeCategoryLogic(IRepository repository)
          : base(repository)
        {
        }

        public GradeCategory Add(GradeCategoryDto gradeCategoryDto)
        {
            var gradeCategory = new GradeCategory
            {
                Id = Guid.NewGuid(),
                Name = gradeCategoryDto.Name,
                Percentage = gradeCategoryDto.Percentage,
                CourseId = gradeCategoryDto.CourseId
            };

            _repository.Insert(gradeCategory);
            _repository.Save();

            return gradeCategory;
        }

        public IEnumerable<GradeCategoryDto> GetByCourseId(Guid courseId)
        {
            var gradeCategoryDtos = new List<GradeCategoryDto>();
            var gradeCategories = _repository.GetAllByFilter<GradeCategory>(x => x.CourseId == courseId);

            foreach(var gradeCategory in gradeCategories)
            {
                var gradeCategoryDto = new GradeCategoryDto
                {
                    Id = gradeCategory.Id,
                    Name = gradeCategory.Name,
                    Percentage = gradeCategory.Percentage,
                    CourseId = gradeCategory.CourseId
                };

                gradeCategoryDtos.Add(gradeCategoryDto);
            }

            return gradeCategoryDtos;
        }
    }
}
