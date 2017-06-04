using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Domain.Job.Service
{
    public interface IJobService : IDomainService
    {
        void AddJob(Guid jobId, string name, Guid userId, Guid workshopId);
        void MakeInActive(Guid jobId);
        void Rename(Guid jobId, string newName);
    }
}
