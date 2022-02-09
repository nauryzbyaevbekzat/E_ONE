using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventum.One2
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // token publisher
        public const string AUDIENCE = "MyAuthClient"; // token consumer
        const string KEY = "mysupersecret_secretkey!1234";   // encryption key
        public const int LIFETIME = 3; // token lifetime - 3 minute
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
