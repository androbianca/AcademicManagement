using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface IUserLogic
    {
        AccountDto Authenticate(string code, string password);
        Account Create(UserDto userDto);
        UserDetailsDto GetById(string userCode);

    }
}
