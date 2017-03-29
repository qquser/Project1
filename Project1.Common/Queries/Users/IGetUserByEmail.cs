﻿using Project1.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common.Queries.Users
{
    public interface IGetUserByEmail
    {
        string Email { get; }
    }
}
