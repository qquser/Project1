using Project1.Common.DTO;
using System.Collections.Generic;

namespace Project1.Common.Queries.Customer
{
    public interface IGetAllCustomers
    {
    }

    public interface IGetAllCustomersResult
    {
        List<CustomerDTO> Customers { get; }
    }
}