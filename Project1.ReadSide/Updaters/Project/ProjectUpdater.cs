using System.Threading.Tasks;
using Project1.Common.Enums;
using Project1.Common.Events.Project;
using Project1.ReadSide.Helpers;
using Project1.ReadSide.Interfaces;
using Project1.ReadSide.Models;
using MassTransit;

namespace Project1.ReadSide.Updaters.Project
{
    public class ProjectUpdater :
        IConsumer<IProjectAdded>,
        IConsumer<IProjectRenamed>,
        IConsumer<IProjectMarkedAsInActive>
    {
        private readonly IModelUpdater _context;

        public ProjectUpdater(IModelUpdater context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<IProjectAdded> context)
        {
            var project = new ProjectModel(context.Message.Id)
            {
                Name = context.Message.Name,
                Status = context.Message.Status
            };
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task Consume(ConsumeContext<IProjectRenamed> context)
        {
            var project = _context.Projects.FindAggregate(context.Message.Id);
            project.Name = context.Message.NewName;
            await _context.SaveChangesAsync();
        }

        public async Task Consume(ConsumeContext<IProjectMarkedAsInActive> context)
        {
            var project = _context.Projects.FindAggregate(context.Message.Id);
            project.Status = ProjectStatus.InActive;
            await _context.SaveChangesAsync();
        }
    }
}
