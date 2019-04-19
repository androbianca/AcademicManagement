using System;
using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;

namespace BusinessLogic.Implementations
{
    public class UserLogic : BaseLogic, IUserLogic
    {

        public UserLogic(IRepository repository)
            : base(repository)
        {
        }

        public Account Authenticate(string code, string password)
        {
            Account user = _repository.GetByFilter<Account>(x => x.UserCode == code);

            if (user == null)
                return null;

            byte[] passwordHash = System.Convert.FromBase64String(user.PasswordHash);
            byte[] passwordSalt = System.Convert.FromBase64String(user.PasswordSalt);

            if (!VerifyPasswordHash(password, passwordHash, passwordSalt))
                return null;

            return user;
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

            if (currentPotentialUser.isStudent)
            {
                user = _repository.GetByFilter<Student>(x => x.PotentialUserId == account.PotentialUserId);
            }
            else
            {
                user = _repository.GetByFilter<Professor>(x => x.PotentialUserId == account.PotentialUserId);

            }

            var userDetails = new UserDetailsDto
            {
                UserCode = id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                isStudent = currentPotentialUser.isStudent

            };

            return userDetails;

        }

    }
}
