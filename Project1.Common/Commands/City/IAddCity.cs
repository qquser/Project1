using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common.Commands.City
{
    public interface IAddCity : ICommand
    {
        Guid Id { get; }

        string Name { get; }
    }
}
