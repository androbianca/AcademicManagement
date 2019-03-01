using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;

namespace BusinessLogic.Implementations
{
    public class AuthLogic : BaseLogic, IAuthLogic
    {
        public AuthLogic(IRepository repository)
            : base(repository)
        {
        }

        public Registration Create(RegistrationDto registrationDto)
        {
            var potentialUser = _repository.GetByFilter<Registration>(x => x.Code == registrationDto.Code);

            if (potentialUser == null)
            {
                return null;
            }

            var newRegistration = new Registration
            {
                Code = registrationDto.Code,
                Email = registrationDto.Email,
                LastName = registrationDto.LastName,
                FirstName = registrationDto.FirstName,
                Password = registrationDto.Password
            };

            _repository.Insert(newRegistration);
            _repository.Save();

            return newRegistration;

        }
    }
}
