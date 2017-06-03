using Project1.Common.DTO;
using System;

namespace Project1.Common.Queries.Workshop
{
    public interface IGetWorkshop
    {
        Guid Id { get; }
    }

    public interface IGetWorkshopResult
    {
        WorkshopDTO Workshop { get; }
    }
}