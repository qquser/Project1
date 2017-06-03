using Project1.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common.Events.Workshop
{
    public interface IWorkshopAdded : IEvent
    {
        Guid Id { get; }
        string Name { get; }
        Guid CityId { get; }
        WorkshopStatus Status { get; }
    }
}
