using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerziyskiClima.Data;
using TerziyskiClima.Data.Models;
using TerziyskiClima.Services.Interfaces;
using TerziyskiClima.Services.Repositories;

namespace TerziyskiClima.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository userRepository;
        public UserService(TerziyskiClimaDbContext context)
        {
            userRepository = new UserRepository(context);
        }
        public User Register(string name, string surname, string address, string phone, string email, string password)
        {
            string role = userRepository.GetUsers().Count == 0 ? "Admin" : "User";
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            User user = new User(name, surname, address, phone, email, hashedPassword, role);
            userRepository.Add(user);
            return user;
        }

        public User Login(string email, string password)
        {
            User user = userRepository.GetByEmail(email);
            if (user == null)
                return null;
            if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public List<User> GetUsers()
        {
            return userRepository.GetUsers();
        }

        public User GetUserById(int id)
        {
            return userRepository.GetUsers().Where(x => x.Id == id).FirstOrDefault();
        }

        public bool EmailIsUsed(string email)
        {
            return userRepository.GetByEmail(email) != null;
        }

        public bool PhoneIsUsed(string phone)
        {
            return userRepository.GetByPhone(phone) != null;
        }
    }
}