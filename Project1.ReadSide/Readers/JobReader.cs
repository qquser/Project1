//using AutoMapper;
//using MassTransit;
//using Microsoft.EntityFrameworkCore;
//using Project1.ReadSide.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Project1.ReadSide.Readers
//{
//    public class JobReader :
//        IConsumer<IGetAllJobs>,
//        IConsumer<IGetJob>
//    {
//        private readonly IModelReader _reader;
//        private readonly IMapper _mapper;

//        public JobReader(IModelReader reader, IMapper mapper)
//        {
//            _reader = reader;
//            _mapper = mapper;
//        }

//        public async Task Consume(ConsumeContext<IGetAllJobs> context)
//        {
//            var jobs = _reader.Jobs
//                .Include(x => x.UserModel)
//                .Include(x => x.WorkshopModel)
//                .Include(x => x.CityModel)
//                .Select(_mapper.Map<JobDTO>)
//                .ToList();
//            var respond = new GetAllJobsResult(jobs);
//            await context.RespondAsync(respond);
//        }

//        public async Task Consume(ConsumeContext<IGetJob> context)
//        {
//            var job = _mapper.Map<JobDTO>(_reader.Jobs
//                .Include(x => x.UserModel)
//                .Include(x => x.WorkshopModel)
//                .Include(x => x.CityModel)
//                .FirstOrDefault(x => x.AggregateId == context.Message.Id));
//            var respond = new GetJobResult(job);
//            await context.RespondAsync(respond);
//        }

//        class GetAllJobsResult : IGetAllJobsResult
//        {
//            public GetAllJobsResult(List<JobDTO> jobs)
//            {
//                Jobs = jobs;
//            }

//            public List<JobDTO> Jobs { get; }
//        }

//        class GetJobResult : IGetJobResult
//        {
//            public GetJobResult(JobDTO job)
//            {
//                Job = job;
//            }

//            public JobDTO Job { get; }
//        }
//    }
//}
