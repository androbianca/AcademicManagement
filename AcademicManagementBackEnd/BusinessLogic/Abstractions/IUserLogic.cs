using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface IUserLogic
    {
        BaseUser Authenticate(string code, string password);
        BaseUser Create(UserDto userDto);
        UserDetailsDto GetById(string userCode);

    }
}
