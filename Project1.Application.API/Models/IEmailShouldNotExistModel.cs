﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Models
{
    internal interface IEmailShouldNotExistModel : IModel
    {
        string Email { get; set; }
    }
}
