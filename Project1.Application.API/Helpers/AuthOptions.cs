using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Security.Claims;
using Project1.Common;
using System.IdentityModel.Tokens.Jwt;

namespace Project1.Application.API.Helpers
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "123"; // потребитель токена
        const string KEY = "mysupersecretkey!123";   // ключ для шифрации
        public const int LIFETIME = 1; // время жизни токена - 1 минута 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

        public static string Token(ClaimsIdentity identity)
        {
            if (identity == null)
                throw new Exception("identity cannot be empty");

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: ISSUER,
                    audience: AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(LIFETIME)),
                    signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public static ClaimsIdentity GetIdentity(string email, string password, string passwordHash, string roleName)
        {
            if (Hashing.ValidatePassword(password, passwordHash))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, roleName)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
    }
}
