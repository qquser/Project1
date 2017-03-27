using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project1.Common.DTO;
using Project1.Common.Queries.Project;
using Project1.ReadSide.Interfaces;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Project1.ReadSide.Readers
{
    public class ProjectReader :
        IConsumer<IGetAllProjects>,
        IConsumer<IGetProject>
    {
        private readonly IModelReader _reader;
        private readonly IMapper _mapper;

        public ProjectReader(IModelReader reader, IMapper mapper)
        {
            _reader = reader;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<IGetAllProjects> context)
        {
            var projects = _reader.Projects
                //.Include(x => x.AssignedUsers)
                .Include(x => x.CustomerModel)
                .Select(_mapper.Map<ProjectDTO>)
                .ToList();
            var respond = new GetAllProjectsResult(projects);
            await context.RespondAsync(respond);
        }

        public async Task Consume(ConsumeContext<IGetProject> context)
        {
            var project = _mapper.Map<ProjectDTO>(_reader.Projects
                //.Include(x => x.AssignedUsers)
                .Include(x => x.CustomerModel)
                .FirstOrDefault(x => x.AggregateId == context.Message.Id));
            var respond = new GetProjectResult(project);
            await context.RespondAsync(respond);
        }

        class GetAllProjectsResult : IGetAllProjectsResult
        {
            public GetAllProjectsResult(List<ProjectDTO> projects)
            {
                Projects = projects;
            }

            public List<ProjectDTO> Projects { get; }
        }

        class GetProjectResult : IGetProjectResult
        {
            public GetProjectResult(ProjectDTO project)
            {
                Project = project;
            }

            public ProjectDTO Project { get; }
        }
    }
}