using System;
using System.Collections.Generic;
using System.Text;
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
            var id = Guid.NewGuid();
            var role = _repository.GetByFilter<UserRole>(x => x.Name == "Professor");
            var potentialUser = new PotentialUser
            {
                UserCode = profDto.UserCode,
                Id = id,
                UserRoleId = role.Id
            };

            _repository.Insert(potentialUser);

            var prof = new Professor
            {
                Id = Guid.NewGuid(),
                FirstName = profDto.FirstName,
                LastName = profDto.LastName,
                PotentialUserId = id

            };
            _repository.Insert<Professor>(prof);
            _repository.Save();

            return prof;
        }
    }
}
