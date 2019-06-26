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

        public IEnumerable<ProfStudDto> GetByProfId(Guid profId)
        {
            var profStuds = _repository.GetAllByFilter<ProfStuds>(x => x.ProfId == profId);
            var profStudDtos = new List<ProfStudDto>();

            foreach (var profStud in profStuds)
            {
                var profStudDto = new ProfStudDto
                {
                    Id = profStud.Id,
                    CourseId = profStud.CourseId,
                    ProfId = profStud.ProfId,
                    GroupId = profStud.GroupId
                };


                profStudDtos.Add(profStudDto);
            }

            return profStudDtos;

        }


        public void Delete(Guid profStudDtoId)
        {

                var profStud =_repository.GetByFilter<ProfStuds>(x =>x.Id == profStudDtoId);   
                _repository.Delete(profStud);
                _repository.Save();         

        }
    }
}
