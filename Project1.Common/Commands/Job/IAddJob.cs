using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common.Commands.Job
{

    public interface IAddJob : ICommand
    {
        Guid Id { get; }
        string Name { get; }
        Guid WorkshopId { get; }
        Guid UserId { get; }
    }
}
