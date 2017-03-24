using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Helpers
{
    interface IHashing
    {
        string GetRandomSalt();
        string HashPassword(string password);
        bool ValidatePassword(string password, string correctHash);
    }
}
