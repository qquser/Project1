using Project1.Application.API.Bus;
using Project1.Application.API.Queries.User;
using Project1.Common.Queries.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.CrossCuttingConcerns
{
    internal static class UserExtensions
    {
        public static IGetUserResult GetUser(string email)
        {
            var query = new GetUserByEmail(email);
            return BusControl.SendRequest<IGetUserByEmail, IGetUserResult>(query).Result;
        }
    }
}
