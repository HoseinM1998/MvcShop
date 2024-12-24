using Cw17.Models.Contract;
using Cw17.Models.Entities;
using Cw17.Models.Enums;
using Cw17.Models.Repository;
using System.Collections.Generic;
using System.Linq;
using Cw17.Models.Security;

namespace Cw17.Models.Service
{
    public class UserService : IUserService
    {
        private readonly IUserReposirory _userRepository;
        private const string EncryptionKey = "hosein";

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public void Register(string fullName, string userName, string password, string email)
        {
            try
            {
                bool isSpecial = password.Any(s => (s >= 33 && s <= 47) || s == 64);

                if (password.Length < 5 || password.Length > 10 || !isSpecial)
                {
                    throw new Exception("Password > 4 Char And One Special Character");
                }

                var user1 = _userRepository.Get(userName);
                if (user1 != null)
                {
                    throw new Exception("Username Already Exists");
                }


                string encryptedPassword = password.EncryptString(EncryptionKey);

                var user = new User
                {
                    FullName = fullName,
                    UserName = userName,
                    Email = email,
                    Password = encryptedPassword,
                    Role = RoleEnum.User
                };

                _userRepository.Add(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }



        public User Login(string username, string password)
        {
            try
            {
                var user = _userRepository.Get(username);
                if (user == null)
                {
                    throw new Exception("Not Found User");
                }

                string decryptedPassword = user.Password.DecryptString(EncryptionKey);

                if (decryptedPassword != password)
                {
                    throw new Exception("Invalid Password");
                }

                if (user.UserName != username)
                {
                    throw new Exception("Invalid Username");
                }

                return user; 
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }



        public bool Logout()
        {
            return true;
        }


        public User Get(string userName)
        {
            try
            {
                return _userRepository.Get(userName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public List<User> GetAll()
        {
            try
            {
                return _userRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public void Update(int id, string fullName, string userName, string email, string password)
        {
            try
            {
                _userRepository.Update(new User
                {
                    Id = id,
                    FullName = fullName,
                    UserName = userName,
                    Email = email,
                    Password = password,
                    Role = RoleEnum.User
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _userRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public User GetById(int id)
        {
            try
            {
                return _userRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");

            }
        }
    }
}
