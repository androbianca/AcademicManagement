using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Implementations
{
    public class PotentialUserLogic : BaseLogic, IPotentialUserLogic
    {
        public PotentialUserLogic(IRepository repository)
          : base(repository)
        { }

        public PotentialUser Remove(Guid id)
        {
            var potentialUser = _repository.GetByFilter<PotentialUser>(x => x.Id == id);

            _repository.Delete(potentialUser);
            _repository.Save();

            return potentialUser;
        }

        public Guid Add(string userCode)
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

        public ICollection<string> GetEmails()
        {
            var emails = new List<string>();
            //    var role = _repository.GetByFilter<UserRole>(x => x.Name == "Professor");

            //    var users = _repository.GetAllByFilter<PotentialUser>(x => x.UserRoleId == role.Id);
            //    foreach(var user in users)
            //    {
            //        emails.Add(user.Email);
            //    }

            return emails;

            //}

        }
    }
}
