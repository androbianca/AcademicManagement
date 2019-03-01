using System;
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

        public Registration Authenticate(string code, string password)
        {
            var user = _repository.GetByFilter<Registration>(x => x.Code == code);
            if (user == null)
                return null;

            byte[] passwordHash = System.Convert.FromBase64String(user.PasswordHash);
            byte[] passwordSalt = System.Convert.FromBase64String(user.PasswordSalt);

            if (!VerifyPasswordHash(password, passwordHash, passwordSalt))
                return null;

            return user;
        }

        public Registration Create(RegistrationDto registrationDto)
        {
            var potentialUser = _repository.GetByFilter<PotentialUser>(x => x.Code == registrationDto.Code);

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
            };

            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(registrationDto.Password, out passwordHash, out passwordSalt);

            newRegistration.PasswordHash = System.Convert.ToBase64String(passwordHash);
            newRegistration.PasswordSalt = System.Convert.ToBase64String(passwordSalt);


            _repository.Insert(newRegistration);
            _repository.Save();

            return newRegistration;

        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            }

            if (storedHash.Length != 64)
            {
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            }

            if (storedSalt.Length != 128)
            {
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
