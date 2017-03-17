﻿using System;

namespace Project1.Common.Commands.User
{
    public interface IAddUser : ICommand
    {
        Guid Id { get; }

        string FirstName { get; }

        string LastName { get; }
    }
}