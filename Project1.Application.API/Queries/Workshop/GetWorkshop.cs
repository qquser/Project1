using Project1.Common.Queries.Workshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Queries.Workshop
{
    public class GetWorkshop : IGetWorkshop
    {
        public GetWorkshop(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
