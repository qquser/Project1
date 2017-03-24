using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Helpers
{
    public class Hashing : IHashing
    {
        public string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(5);
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }

        public bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}
