using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface IAuthLogic
    {
        Registration Authenticate(string code, string password);
        Registration Create(RegistrationDto registrationDto);

   }
}
