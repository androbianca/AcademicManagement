using System;
using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;

namespace BusinessLogic.Implementations
{
    public class ProfLogic :BaseLogic,IProfLogic
    {
        public ProfLogic(IRepository repository) : base(repository)
        {
        }

        public Professor addProf(ProfDto profDto)
        {        
            var prof = new Professor
            {
                Id = Guid.NewGuid(),
                FirstName = profDto.FirstName,
                LastName = profDto.LastName,
                PotentialUserId = profDto.PotentialUserId

            };
            _repository.Insert(prof);
            _repository.Save();

            return prof;
        }
    }
}
