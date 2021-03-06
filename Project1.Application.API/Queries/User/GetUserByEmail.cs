﻿using Project1.Common.Queries.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Queries.User
{
    public class GetUserByEmail : IGetUserByEmail
    {
        public GetUserByEmail(string email)
        {
            Email = email;
        }

        public string Email { get; }
    }
}
