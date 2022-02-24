using System;
using System.Collections.Generic;
using System.Text;

namespace TerziyskiClima.Data.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public int Id { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }

        public User(string name, string surname, string address, string  phone, string email, string passwordHash, string role)
        {
            Name = name;
            Surname = surname;
            Address = address;
            Phone = phone;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
        }
    }
}
