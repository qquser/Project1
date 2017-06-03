using Project1.Common.Queries.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Queries.Job
{
    public class GetJob : IGetJob
    {
        public GetJob(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
