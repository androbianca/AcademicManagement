using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
using System;

namespace BusinessLogic.Implementations
{
    public class UserRoleLogic : BaseLogic, IUserRoleLogic
    {
        public UserRoleLogic(IRepository repository)
           : base(repository)
        { }

        public UserRoleDto getProfRoleId()
        {
            var role = _repository.GetByFilter<UserRole>(X => X.Name == "Professor");

            if(role == null)
            {
                return null;
            }

            var roleDto = new UserRoleDto
            {
                Id = role.Id,
                Name = role.Name
            };

            return roleDto;
        }

        public UserRoleDto getStudentRoleId()
        {
            var role = _repository.GetByFilter<UserRole>(X => X.Name == "Student");

            if (role == null)
            {
                return null;
            }

            var roleDto = new UserRoleDto
            {
                Id = role.Id,
                Name = role.Name
            };

            return roleDto;
        }


        public UserRoleDto getById(Guid Id)
        { 
            var role = _repository.GetByFilter<UserRole>(X => X.Id == Id);

            if (role == null)
            {
                return null;
            }

            var roleDto = new UserRoleDto
            {
                Id = role.Id,
                Name = role.Name
            };

            return roleDto;
        }
    }
}
