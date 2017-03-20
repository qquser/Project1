using System.Threading.Tasks;
using Project1.Common.Enums;
using Project1.Common.Events.Customer;
using Project1.ReadSide.Helpers;
using Project1.ReadSide.Interfaces;
using Project1.ReadSide.Models;
using MassTransit;
using Project1.Common.Messages;

namespace Project1.ReadSide.Updaters.Customer
{
    public class CustomerUpdater : 
        IConsumer<ICustomerAdded>,
        IConsumer<ICustomerRenamed>,
        IConsumer<ICustomerMarkedAsInActive>
    {
        private readonly IModelUpdater _context;
        private readonly IMessagePublisher _messagePublisher;

        public CustomerUpdater(IModelUpdater context, IMessagePublisher messagePublisher) 
        {
            _messagePublisher = messagePublisher;
            _context = context;
        }

        public async Task Consume(ConsumeContext<ICustomerAdded> context)
        {
            var customer = new CustomerModel(context.Message.Id)
            {
                Name = context.Message.Name,
                Status = context.Message.Status
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            _context.Dispose();

            await _messagePublisher.PublishMessageAsync(context.Message);
        }

        public async Task Consume(ConsumeContext<ICustomerRenamed> context)
        {
            var customer = _context.Customers.FindAggregate(context.Message.Id);
            customer.Name = context.Message.NewName;
            await _context.SaveChangesAsync();
        }

        public async Task Consume(ConsumeContext<ICustomerMarkedAsInActive> context)
        {
            var customer = _context.Customers.FindAggregate(context.Message.Id);
            customer.Status = CustomerStatus.InActive;
            await _context.SaveChangesAsync();
        }
    }
}