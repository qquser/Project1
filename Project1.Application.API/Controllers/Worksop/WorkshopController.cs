using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project1.Application.API.Commands.Workshop;
using Project1.Application.API.Models;
using Project1.Application.API.Models.Workshop;
using Project1.Application.API.Queries.Workshop;
using Project1.Common.Queries.Workshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Controllers.Worksop
{

    [Route("api/[controller]")]
    [Authorize(Roles = "admin")]
    public class WorkshopController : EnhancedApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(AddWorkshopModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.CommandId == Guid.Empty)
                model.CommandId = NewId.NextGuid();

            var command = new AddWorkshopCommand(model);
            await Send(command);

            return Accepted(new PostResult<AddWorkshopCommand>()
            {
                CommandId = model.Id,
                Timestamp = command.Timestamp
            });
        }


        [HttpPost]
        [Route("{id}/makeinactive")]
        public async Task<IActionResult> MakeInactive(Guid id)
        {
            var commandId = NewId.NextGuid();

            var command = new MakeWorkshopInActiveCommand(id, commandId);
            await Send(command);

            return Accepted(new PostResult<MakeWorkshopInActiveCommand>()
            {
                CommandId = id,
                Timestamp = command.Timestamp
            });
        }

        [HttpPost]
        [Route("{id}/name")]
        public async Task<IActionResult> Rename(Guid id, RenameWorkshopModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.CommandId == Guid.Empty)
                model.CommandId = NewId.NextGuid();

            var command = new RenameWorkshopCommand(model, id);
            await Send(command);

            return Accepted(new PostResult<RenameWorkshopCommand>()
            {
                CommandId = id,
                Timestamp = command.Timestamp
            });
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                ModelState.AddModelError(nameof(id), "Cannot be empty");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var query = new GetWorkshop(id);
            var result = await SendRequest<IGetWorkshop, IGetWorkshopResult>(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllWorkshops();
            var result = await SendRequest<IGetAllWorkshops, IGetAllWorkshopsResult>(query);
            return Ok(result);
        }
    }





    

  


}
