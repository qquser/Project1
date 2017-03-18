using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project1.Common.DTO;
using Project1.Common.Queries.Customer;
using Project1.ReadSide.Interfaces;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Project1.ReadSide.Readers
{
    public class CustomerReader :
        IConsumer<IGetAllCustomers>,
        IConsumer<IGetCustomer>
    {
        private readonly IModelReader _reader;
        private readonly IMapper _mapper;

        public CustomerReader(IModelReader reader, IMapper mapper)
        {
            _reader = reader;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<IGetAllCustomers> context)
        {
            var customers = _reader.Customers
                .Include(x=>x.Projects)
                .Select(_mapper.Map<CustomerDTO>)
                .ToList();
            var respond = new GetAllCustomerResult(customers);
            await context.RespondAsync(respond);
        }

        public async Task Consume(ConsumeContext<IGetCustomer> context)
        {
            var customer = _mapper.Map<CustomerDTO>(_reader.Customers
                .Include(x => x.Projects)
                .FirstOrDefault(x => x.AggregateId == context.Message.Id));
            var respond = new GetCustomerResult(customer);
            await context.RespondAsync(respond);
        }

        class GetAllCustomerResult : IGetAllCustomersResult
        {
            public GetAllCustomerResult(List<CustomerDTO> customers)
            {
                Customers = customers;
            }

            public List<CustomerDTO> Customers { get; }
        }

        class GetCustomerResult : IGetCustomerResult
        {
            public GetCustomerResult(CustomerDTO customer)
            {
                Customer = customer;
            }

            public CustomerDTO Customer { get; }
        }
    }
}