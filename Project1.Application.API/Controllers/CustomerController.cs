using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Project1.Application.API.Models;
using Project1.Application.API.Models.Customer;
using Project1.Common.Commands.Customer;
using Project1.Common.Queries.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Project1.Application.API.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : EnhancedApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(AddCustomerModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.CommandId == Guid.Empty)
                model.CommandId = NewId.NextGuid();

            var command = new AddCustomerCommand(model);
            await Send(command);

            return Accepted(new PostResult<AddCustomerCommand>()
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

            var command = new MakeCustomerInActiveCommand(id, commandId);
            await Send(command);

            return Accepted(new PostResult<MakeCustomerInActiveCommand>()
            {
                CommandId = id,
                Timestamp = command.Timestamp
            });
        }

        [HttpPost]
        [Route("{id}/name")]
        public async Task<IActionResult> Rename(Guid id, RenameCustomerModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.CommandId == Guid.Empty)
                model.CommandId = NewId.NextGuid();

            var command = new RenameCustomerCommand(model, id);
            await Send(command);

            return Accepted(new PostResult<RenameCustomerCommand>()
            {
                CommandId = id,
                Timestamp = command.Timestamp
            });
        }

        //[HttpGet]
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    if (id == Guid.Empty)
        //    {
        //        ModelState.AddModelError(nameof(id), "Cannot be empty");
        //    }
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var query = new GetCustomer(id);
        //    var result = await SendRequest<IGetCustomer, IGetCustomerResult>(query);
        //    return Ok(result);
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCustomers();
            var result = await SendRequest<IGetAllCustomers, IGetAllCustomersResult>(query);
            return Ok(result);
        }
    }

    class GetAllCustomers : IGetAllCustomers
    {
    }

    class GetCustomer : IGetCustomer
    {
        public GetCustomer(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    class RenameCustomerCommand : IRenameCustomer
    {
        private readonly RenameCustomerModel _model;

        public RenameCustomerCommand(RenameCustomerModel model, Guid id)
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

    class MakeCustomerInActiveCommand : IMakeCustomerInActive
    {
        public MakeCustomerInActiveCommand(Guid id, Guid commandId)
        {
            Id = id;
            Timestamp = DateTime.UtcNow;
            CommandId = commandId;
        }

        public Guid Id { get; }
        public DateTime Timestamp { get; }
        public Guid CommandId { get; }
    }

    class AddCustomerCommand : IAddCustomer
    {
        private readonly AddCustomerModel _model;

        public AddCustomerCommand(AddCustomerModel model)
        {
            _model = model;
            Timestamp = DateTime.UtcNow;
        }

        public Guid Id => _model.Id;
        public string Name => _model.Name;
        public DateTime Timestamp { get; }
        public Guid CommandId => _model.CommandId;
    }

}
