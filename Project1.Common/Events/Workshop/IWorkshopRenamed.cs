using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common.Events.Workshop
{
    public interface IWorkshopRenamed : IEvent
    {
        Guid Id { get; }
        string NewName { get; }
        string OldName { get; }
    }
}
