using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Project1.Application.API.Commands.Job;
using Project1.Application.API.Models;
using Project1.Application.API.Models.Job;
using Project1.Application.API.Queries.Job;
using Project1.Common.Queries.Job;
using System;
using System.Threading.Tasks;

namespace Project1.Application.API.Controllers.Job
{
    [Route("api/[controller]")]
    public class JobController : EnhancedApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(AddJobModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.CommandId == Guid.Empty)
                model.CommandId = NewId.NextGuid();

            var command = new AddJobCommand(model);
            await Send(command);

            return Accepted(new PostResult<AddJobCommand>()
            {
                CommandId = model.JobId,
                Timestamp = command.Timestamp
            });
        }

        [HttpPost]
        [Route("{id}/makeinactive")]
        public async Task<IActionResult> MakeInactive(Guid id)
        {
            var commandId = NewId.NextGuid();

            var command = new MakeJobInActiveCommand(id, commandId);
            await Send(command);

            return Accepted(new PostResult<MakeJobInActiveCommand>()
            {
                CommandId = id,
                Timestamp = command.Timestamp
            });
        }

        [HttpPost]
        [Route("{id}/name")]
        public async Task<IActionResult> Rename(Guid id, RenameJobModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.CommandId == Guid.Empty)
                model.CommandId = NewId.NextGuid();

            var command = new RenameJobCommand(model, id);
            await Send(command);

            return Accepted(new PostResult<RenameJobCommand>()
            {
                CommandId = id,
                Timestamp = command.Timestamp
            });
        }

        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                ModelState.AddModelError(nameof(id), "Cannot be empty");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var query = new GetJob(id);
            var result = await SendRequest<IGetJob, IGetJobResult>(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllJobs();
            var result = await SendRequest<IGetAllJobs, IGetAllJobsResult>(query);
            return Ok(result);
        }


    }
}
