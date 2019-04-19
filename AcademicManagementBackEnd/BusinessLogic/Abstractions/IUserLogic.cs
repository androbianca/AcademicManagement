using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface IUserLogic
    {
        Account Authenticate(string code, string password);
        Account Create(UserDto userDto);
        UserDetailsDto GetById(string userCode);

    }
}
