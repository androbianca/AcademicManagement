using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using System;

namespace BusinessLogic.Implementations
{
    public class PotentialUserLogic : BaseLogic, IPotentialUserLogic
    {
        public PotentialUserLogic(IRepository repository)
          : base(repository)
        { }

        public Guid AddPotentialUser(string userCode)
        {
            var role = _repository.GetByFilter<UserRole>(x => x.Name == "Professor");
            var potentialUser = new PotentialUser
            {
                UserCode = userCode,
                Id = Guid.NewGuid(),
                UserRoleId = role.Id
            };

            _repository.Insert(potentialUser);
            _repository.Save();

            return potentialUser.Id;
        }
    }
}
