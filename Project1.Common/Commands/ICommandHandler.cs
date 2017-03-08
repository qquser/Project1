using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Common.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
