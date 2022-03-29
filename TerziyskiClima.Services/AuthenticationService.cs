using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace TerziyskiClima.Services
{
    public class AuthenticationService
    {
        public string GetRole(ClaimsPrincipal User)
        {
            if (User.Identity.IsAuthenticated)
            {
                return User.Claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault().Value;
            }
            else return "Anon";
        }
    }
}