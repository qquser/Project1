using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common.Commands.Job
{
    public interface IRenameJob : ICommand
    {
        Guid Id { get; }

        string NewName { get; }
    }
}
