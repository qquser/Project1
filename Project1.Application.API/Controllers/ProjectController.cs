using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Project1.Application.API.Commands;
using Project1.Application.API.CrossCuttingConcerns;
using Project1.Application.API.Models;
using Project1.Application.API.Models.Project;
using Project1.Common.Commands.Project;
using Project1.Common.Queries.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : EnhancedApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(AddProjectModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            if (model.CommandId == Guid.Empty)
                model.CommandId = NewId.NextGuid();

            var command = new AddProjectCommand(model);
            await Send(command);

            return Accepted(new PostResult<AddProjectCommand>()
            {
                CommandId = model.ProjectId,
                Timestamp = command.Timestamp
            });
        }

        [HttpPost]
        [Route("{id}/makeinactive")]
        public async Task<IActionResult> MakeInactive(Guid id)
        {
            var commandId = NewId.NextGuid();

            var command = new MakeProjectInActiveCommand(id, commandId);
            await Send(command);

            return Accepted(new PostResult<MakeProjectInActiveCommand>()
            {
                CommandId = id,
                Timestamp = command.Timestamp
            });
        }

        [HttpPost]
        [Route("{id}/name")]
        public async Task<IActionResult> Rename(Guid id, RenameProjectModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.CommandId == Guid.Empty)
                model.CommandId = NewId.NextGuid();

            var command = new RenameProjectCommand(model, id);
            await Send(command);

            return Accepted(new PostResult<RenameProjectCommand>()
            {
                CommandId = id,
                Timestamp = command.Timestamp
            });
        }
                     
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    if (id == Guid.Empty)
        //    {
        //        ModelState.AddModelError(nameof(id), "Cannot be empty");
        //    }
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var query = new GetProject(id);
        //    var result = await SendRequest<IGetProject, IGetProjectResult>(query);
        //    return Ok(result);
        //}
              
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllProjects();
            var result = await SendRequest<IGetAllProjects, IGetAllProjectsResult>(query);
            return Ok(result);
        }


    }

    class GetAllProjects : IGetAllProjects
    {
    }

    public class GetProject : BaseHandler, IBaseCommand<RenameProjectModel>, IGetProject
    {

        public Guid Id { get; }

        public IBaseCommand<RenameProjectModel> DecoratedHandler { get; }

        public void Handle(RenameProjectModel model)
        {
       
        }
    }

    class RenameProjectCommand : IRenameProject
    {
        private readonly RenameProjectModel _model;

        public RenameProjectCommand(RenameProjectModel model, Guid id)
        {
            _model = model;
            Timestamp = DateTime.UtcNow;
            Id = id;
        }

        public Guid Id { get; }
        public string NewName => _model.NewName;
        public DateTime Timestamp { get; }
        public Guid CommandId => _model.CommandId;
    }

    class AddProjectCommand : IAddProject
    {
        private readonly AddProjectModel _model;

        public AddProjectCommand(AddProjectModel model)
        {
            _model = model;
            Timestamp = DateTime.UtcNow;
        }

        public DateTime Timestamp { get; }
        public Guid CommandId => _model.CommandId;
        public Guid Id => _model.ProjectId;
        public string Name => _model.Name;
        public Guid CustomerId => _model.CustomerId;
    }

    class MakeProjectInActiveCommand : IMakeProjectInActive
    {
        public MakeProjectInActiveCommand(Guid id, Guid commandId)
        {
            Id = id;
            Timestamp = DateTime.UtcNow;
            CommandId = commandId;
        }

        public Guid Id { get; }
        public DateTime Timestamp { get; }
        public Guid CommandId { get; }
    }
}
