using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace LibaryManagementSystem2.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public UserService(IUserRepository userRepository, IUserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }


        public void RegisterUser(User user)
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string saltString = Convert.ToBase64String(salt);

            string hashedPassword = HashPassword(user.Password, saltString);

            User users = new User
            {
               
                CreatedAt = DateTime.Now,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                HashSalt = saltString,
                PasswordHash = hashedPassword,
                
            };

            _userRepository.Add(user);
            UserRole userRole = new UserRole
            {
                CreatedAt = DateTime.Now,
                UserId = user.Id,
                RoleId = user.RoleId,
            };
            _userRoleRepository.Add(userRole);
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

        public User LoginUser(User user)
        {
            User users = _userRepository.FindByEmail(user.Email);

            if (users == null)
            {

                return null;
            }

            string hashedPassword = HashPassword(user.Password, user.HashSalt);

            if (user.PasswordHash.Equals(hashedPassword))
            {

                return user;
            }

            return null;
        }
          public IEnumerable<User> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        public User FindById(int Id)
        {
            return _userRepository.FindById(Id);
        }

     public User Update(User user)
        {
            User users = _userRepository.FindById(user.Id);

            if (users == null)
            {
                return null;
            }

            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string saltString = Convert.ToBase64String(salt);

            string hashedPassword = HashPassword(user.Password, saltString);

            user.LastName = user.LastName;
            user.FirstName = user.FirstName;
            user.Email = user.Email;
            user.PhoneNumber = user.PhoneNumber;
            user.Address = user.Address;
            user.HashSalt = saltString;
            user.PasswordHash = hashedPassword;
            user.UpdatedAt = DateTime.Now;

            return _userRepository.Update(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public void RegisterUser(string email, User user)
        {
            throw new NotImplementedException();
        }
    }
}