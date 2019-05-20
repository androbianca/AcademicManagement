using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Implementations
{
    public class ProfStudLogic : BaseLogic, IProfStudLogic

    {

        public ProfStudLogic(IRepository repository)
          : base(repository)
        { }

        public IEnumerable<ProfStuds> Add(IEnumerable<ProfStudDto> profStudDtos)
        {
            var profStuds = new List<ProfStuds>();

            foreach( var profStudDto in profStudDtos)
            {
                var profStud = new ProfStuds
                {  Id = Guid.NewGuid(),
                    CourseId = profStudDto.CourseId,
                    ProfId = profStudDto.ProfId,
                    GroupId = profStudDto.GroupId
                };

                _repository.Insert(profStud);
                _repository.Save();

                profStuds.Add(profStud);
            }

            return profStuds;
            
        }
    }
}
