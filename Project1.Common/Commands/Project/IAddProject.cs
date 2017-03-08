using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Common.Commands.Project
{
    public interface IAddProject : ICommand
    {
        Guid Id { get; }
        string Name { get; }
    }
}
