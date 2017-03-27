using System;
using Project1.Common;

namespace Project1.Domain.User.ValueObjects
{
    public class UserName
    {
        public ValueObject<string> Email { get; }
        public ValueObject<string> PasswordHash { get; }


        public UserName(string email, string hash)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(email);
            }
            if (string.IsNullOrEmpty(hash))
            {
                throw new ArgumentNullException(hash);
            }
            Email = email;
            PasswordHash = hash;
        }
    }
}