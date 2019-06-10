using System;
using BusinessLogic.Abstractions;
using BusinessLogic.HubConfig;
using DataAccess.Abstractions;
using Entities;
using Microsoft.AspNetCore.SignalR;
using Models;

namespace BusinessLogic.Implementations
{
    public class UserLogic : BaseLogic, IUserLogic
    {
        public UserLogic(IRepository repository)
            : base(repository)
        {
        }

        public AccountDto Authenticate(string code, string password)
        {
            Account user = _repository.GetByFilter<Account>(x => x.UserCode == code);
             var potentialUser = _repository.GetByFilter<PotentialUser>(x => x.UserCode == code);
            var role = _repository.GetByFilter<UserRole>(x => x.Id == potentialUser.UserRoleId);
            if (user == null)
                return null;

            byte[] passwordHash = System.Convert.FromBase64String(user.PasswordHash);
            byte[] passwordSalt = System.Convert.FromBase64String(user.PasswordSalt);

            if (!VerifyPasswordHash(password, passwordHash, passwordSalt))
                return null;

            var accountDto = new AccountDto
            {
                UserCode = user.UserCode,
                Role = role.Name,
            };

            return accountDto;
        }

        public Account Create(UserDto userDto)
        {
            var potentialUser = _repository.GetByFilter<PotentialUser>(x => x.UserCode == userDto.UserCode);

            if (potentialUser == null)
            {
                return null;
            }

            var newRegistration = new Account()
            {
                PotentialUserId = potentialUser.Id,
                UserCode = userDto.UserCode,
            };

            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(userDto.Password, out passwordHash, out passwordSalt);

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

        public UserDetailsDto GetById(string id)
        {
            var user = new BaseUser();

            var account = _repository.GetByFilter<Account>(x => x.UserCode == id);
     
            var currentPotentialUser = _repository.GetByFilter<PotentialUser>(x => x.UserCode == id);
            var role = _repository.GetByFilter<UserRole>(x => x.Id == currentPotentialUser.UserRoleId);
            if (role.Name == "Student")
            {
                user = _repository.GetByFilter<Student>(x => x.PotentialUserId == account.PotentialUserId);
            }
            if (role.Name == "Professor")
            {
                user = _repository.GetByFilter<Professor>(x => x.PotentialUserId == account.PotentialUserId);
            }
            if (role.Name == "Admin")
            {
                user = _repository.GetByFilter<Admin>(x => x.PotentialUserId == account.PotentialUserId);
            }

            var userDetails = new UserDetailsDto
            {
                Id = user.Id,
                UserCode = id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                UserRole = role.Name

            };

            return userDetails;

        }

    }
}
