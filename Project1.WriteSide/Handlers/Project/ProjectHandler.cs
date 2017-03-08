using System.Threading.Tasks;
using Project1.Common.Commands.Project;
using Project1.Domain.Project.Service;
using MassTransit;

namespace Project1.WriteSide.Handlers.Project
{
    internal class ProjectHandler :
        IConsumer<IAddProject>,
        IConsumer<IMakeProjectInActive>,
        IConsumer<IRenameProject>
    {
        private readonly IProjectService _service;

        public ProjectHandler(IProjectService service)
        {
            _service = service;
        }

        public async Task Consume(ConsumeContext<IAddProject> context)
        {
            await Task.Run(() => _service.AddProject(
                context.Message.Id,
                context.Message.Name));
        }

        public async Task Consume(ConsumeContext<IMakeProjectInActive> context)
        {
            await Task.Run(() => _service.MakeInActive(context.Message.Id));
        }

        public async Task Consume(ConsumeContext<IRenameProject> context)
        {
            await Task.Run(() => _service.Rename(context.Message.Id, context.Message.NewName));
        }
    }
}