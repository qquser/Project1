using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project1.Application.API.Models.Workshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Controllers
{
    [Route("api/[workshop]")]
    public class WorkshopController : EnhancedApiController
    {
        //[HttpPost]
        //[Route("create")]
        //[Authorize(Roles = "admin")]
        //public async Task<IActionResult> Create(AddWorkshopModel model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //            return BadRequest(ModelState);

        //        if (model.CommandId == Guid.Empty)
        //            model.CommandId = NewId.NextGuid();

        //        var command = new AddProjectCommand(model);
        //        await Send(command);

        //        return Accepted(new PostResult<AddProjectCommand>()
        //        {
        //            CommandId = model.ProjectId,
        //            Timestamp = command.Timestamp
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
