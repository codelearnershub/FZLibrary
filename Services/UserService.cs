using System;
using System.Security.Cryptography;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace LibaryManagementSystem2.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleService _userRoleService;

        public UserService(IUserRepository userRepository, IUserRoleService userRoleService)
        {
            _userRepository = userRepository;
            _userRoleService = userRoleService;
        }


        public void RegisterUser(int userId, string password, string lastName, string firstName, string email, string phoneNumber, string address, int roleId)
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string saltString = Convert.ToBase64String(salt);

            string hashedPassword = HashPassword(password, saltString);

            User user = new User
            {
                CreatedBy = _userRepository.FindById(userId).Email,
                CreatedAt = DateTime.Now,
                LastName = lastName,
                FirstName = firstName,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address,
                HashSalt = saltString,
                PasswordHash = hashedPassword,
            };

            _userRepository.Add(user);

            _userRoleService.Add(user.Id, roleId);
        }

        private string HashPassword(string password, string salt)
        {
            byte[] saltByte = Convert.FromBase64String(salt);
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltByte,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public User LoginUser(string email, string password)
        {
            User user = _userRepository.FindByEmail(email);

            if (user == null)
            {

                return null;
            }

            string hashedPassword = HashPassword(password, user.HashSalt);

            if (user.PasswordHash.Equals(hashedPassword))
            {

                return user;
            }

            return null;
        }

        public User FindById(int Id)
        {
            return _userRepository.FindById(Id);
        }

        public User Update(int id, string password, string lastName, string firstName, string email, string phoneNumber, string address)
        {
            User user = _userRepository.FindById(id);

            if (user == null)
            {
                return null;
            }

            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string saltString = Convert.ToBase64String(salt);

            string hashedPassword = HashPassword(password, saltString);

            user.LastName = lastName;
            user.FirstName = firstName;
            user.Email = email;
            user.PhoneNumber = phoneNumber;
            user.Address = address;
            user.HashSalt = saltString;
            user.PasswordHash = hashedPassword;
            user.UpdatedAt = DateTime.Now;

            return _userRepository.Update(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

    }
}