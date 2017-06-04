using CommonDomain.Persistence;
using Project1.Domain.Job.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Domain.Job.Service
{
    public class JobService : IJobService
    {
        private readonly IRepository _repository;

        public JobService(IRepository repository)
        {
            _repository = repository;
        }

        public void AddJob(Guid JobId, string name, Guid userId, Guid workshopId)
        {
            var Job = JobAggregate.Add(JobId, name, userId, workshopId);
            _repository.Save(Job, Guid.NewGuid(), null);
        }

        public void Rename(Guid jobId, string newName)
        {
            var job = _repository.GetById<JobAggregate>(jobId);
            job.Rename(new JobName(newName));
            _repository.Save(job, Guid.NewGuid(), null);
        }

        public void MakeInActive(Guid jobId)
        {
            var job = _repository.GetById<JobAggregate>(jobId);
            job.MakeInActive();
            _repository.Save(job, Guid.NewGuid(), null);
        }
    }
}
