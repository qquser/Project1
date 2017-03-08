using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Common.Commands
{
    public interface ICommand
    {
        DateTime Timestamp { get; }
        Guid CommandId { get; }
    }
}
