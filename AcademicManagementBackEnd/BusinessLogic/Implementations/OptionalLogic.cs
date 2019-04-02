using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Abstractions;
using BusinessLogic.Implementations;
using DataAccess.Abstractions;
using Entities;
using Models;

namespace BusinessLogic.Implementations
{
    public class OptionalLogic : BaseLogic, IOptionalLogic
    {
        public OptionalLogic(IRepository repository)
            : base(repository)
        {
        }

        public ICollection<OptionalDto> GetAll()
        {
            var optionals = _repository.GetAll<Optional>();
            var optionalDtos = new List<OptionalDto>();
            foreach (var course in optionals)
            {
                var optionalDto = new OptionalDto
                {
                    Name = course.Name,
                    Year = course.Year,
                    Semester = course.Semester
                };

                optionalDtos.Add(optionalDto);
            }

            return optionalDtos;
        }

        public ICollection<OptionalDto> GetByYear(int year)
        {
            var optionals = _repository.GetAllByFilter<Optional>(x => x.Year <= year);
            var optionalDtos = new List<OptionalDto>();
            foreach (var optional in optionals)
            {
                var optionalDto = new OptionalDto
                {
                    Name = optional.Name,
                    Year = optional.Year,
                    Semester = optional.Semester     
                };

                optionalDtos.Add(optionalDto);
            }

            return optionalDtos;
        }
    }
}
