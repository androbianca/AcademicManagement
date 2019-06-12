using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
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

        public PotentialUserDto GetByUserCode(string id)
        {
            var potentialUser = _repository.GetByFilter<PotentialUser>(x => x.UserCode == id);

            var potentialUserDto = new PotentialUserDto
            {
                FirstName = potentialUser.FirstName,
                LastName = potentialUser.LastName,
                RoleId = potentialUser.UserRoleId
            };

            return potentialUserDto;
        }

        public PotentialUser Add(PotentialUserDto potentialUserDto)
        {
            var potentialUser = new PotentialUser
            {
                Id = Guid.NewGuid(),
                UserCode = potentialUserDto.UserCode,
                FirstName = potentialUserDto.FirstName,
                LastName = potentialUserDto.LastName,
                UserRoleId = potentialUserDto.RoleId
            };

            _repository.Insert(potentialUser);
            _repository.Save();

            return potentialUser;
        }

        public ICollection<string> GetEmails()
        {
            var emails = new List<string>();
              var role = _repository.GetByFilter<UserRole>(x => x.Name == "Professor");

              var users = _repository.GetAllByFilter<PotentialUser>(x => x.UserRoleId == role.Id);
              foreach(var user in users)
              {
                  emails.Add(user.Email);
              }

            return emails;

           }

        }
    }
