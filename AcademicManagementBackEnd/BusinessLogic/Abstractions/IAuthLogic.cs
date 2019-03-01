using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface IAuthLogic
   {
       Registration Create(RegistrationDto registrationDto);

   }
}
