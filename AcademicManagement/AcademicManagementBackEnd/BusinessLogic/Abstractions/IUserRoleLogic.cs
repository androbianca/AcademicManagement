using Models;
using System;

namespace BusinessLogic.Abstractions
{
    public interface IUserRoleLogic
    {
        UserRoleDto getStudentRoleId();
        UserRoleDto getProfRoleId();
        UserRoleDto getById(Guid Id);
    }
}
