using System;
using System.Collections.Generic;
using System.Text;
using TerziyskiClima.Data.Models;

namespace TerziyskiClima.Services.Interfaces
{
    public interface IUserService
    {
        User Register(string name, string surname, string address, string phone, string email, string password, string confirmPassword, string role);
        User Login(string email, string password);
    }
}
