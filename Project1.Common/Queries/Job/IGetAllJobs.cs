using Project1.Common.DTO;
using System.Collections.Generic;

namespace Project1.Common.Queries.Job
{
    public interface IGetAllJobs
    {
    }

    public interface IGetAllJobsResult
    {
        List<JobDTO> Jobs { get; }
    }
}