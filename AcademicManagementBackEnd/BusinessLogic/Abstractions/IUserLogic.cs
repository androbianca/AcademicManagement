using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface IUserLogic
    {
        Student Authenticate(string code, string password);
        Student Create(UserDto userDto);
        UserDetailsDto GetById(string userCode);

    }
}
