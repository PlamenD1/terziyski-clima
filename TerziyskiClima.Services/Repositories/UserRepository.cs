using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerziyskiClima.Data;
using TerziyskiClima.Data.Models;

namespace TerziyskiClima.Services.Repositories
{
    public class UserRepository
    {
        private readonly TerziyskiClimaDbContext Context;
        public UserRepository(TerziyskiClimaDbContext context)
        {
            Context = context;
        }
        public void Add(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }

        public List<User> GetUsers()
        {
            return Context.Users.Include("Purchases").Include("Purchases.Product").ToList();
        }

        public User GetByEmail(string email)
        {
            User user = Context.Users.FirstOrDefault(x => x.Email == email);
            return user;
        }

        public User GetByPhone(string phone)
        {
            User user = Context.Users.FirstOrDefault(x => x.Phone == phone);
            return user;
        }
    }
}