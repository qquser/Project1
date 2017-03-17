using Project1.Common.DTO;
using System;

namespace Project1.Common.Queries.Customer
{
    public interface IGetCustomer
    {
        Guid Id { get; }
    }

    public interface IGetCustomerResult
    {
        CustomerDTO Customer { get; }
    }
}