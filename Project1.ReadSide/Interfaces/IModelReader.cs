using System;
using System.Linq;
using Project1.ReadSide.Models;

namespace Project1.ReadSide.Interfaces
{
    public interface IModelReader : IDisposable
    {
        IQueryable<ProjectModel> Projects { get; }
        IQueryable<CustomerModel> Customers { get; }
        //IQueryable<UserModel> Users { get; }
    }
}