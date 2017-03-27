using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common.Commands.User
{
    public interface IRegisterUser : ICommand
    {
        Guid Id { get; }

        string Email { get; }

        string PasswordHash { get; }
    }
}
