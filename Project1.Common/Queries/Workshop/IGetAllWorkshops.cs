using Project1.Common.DTO;
using System.Collections.Generic;

namespace Project1.Common.Queries.Workshop
{
    public interface IGetAllWorkshops
    {
    }

    public interface IGetAllWorkshopsResult
    {
        List<WorkshopDTO> Workshops { get; }
    }
}