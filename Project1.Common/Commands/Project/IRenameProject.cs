using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Common.Commands.Project
{
    public interface IRenameProject : ICommand
    {
        Guid Id { get; }

        string NewName { get; }
    }
}
