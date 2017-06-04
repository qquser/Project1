using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project1.Application.API.Commands.City;
using Project1.Application.API.Models;
using Project1.Application.API.Models.City;
using Project1.Application.API.Queries.City;
using Project1.Common.Commands.City;
using Project1.Common.Queries.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Controllers.City
{

    [Route("api/[controller]")]
    [Authorize(Roles = "user")]
    public class CityController : EnhancedApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(AddCityModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.CommandId == Guid.Empty)
                model.CommandId = NewId.NextGuid();

            var command = new AddCityCommand(model);
            await Send(command);

            return Accepted(new PostResult<AddCityCommand>()
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

            var command = new MakeCityInActiveCommand(id, commandId);
            await Send(command);

            return Accepted(new PostResult<MakeCityInActiveCommand>()
            {
                CommandId = id,
                Timestamp = command.Timestamp
            });
        }

        [HttpPost]
        [Route("{id}/name")]
        public async Task<IActionResult> Rename(Guid id, RenameCityModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.CommandId == Guid.Empty)
                model.CommandId = NewId.NextGuid();

            var command = new RenameCityCommand(model, id);
            await Send(command);

            return Accepted(new PostResult<RenameCityCommand>()
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

            var query = new GetCity(id);
            var result = await SendRequest<IGetCity, IGetCityResult>(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCities();
            var result = await SendRequest<IGetAllCities, IGetAllCitiesResult>(query);
            return Ok(result);
        }
    }

}
