using System;
using System.Threading.Tasks;
using Project1.ReadSide.Models;
using Microsoft.EntityFrameworkCore;

namespace Project1.ReadSide.Interfaces
{
    public interface IModelUpdater : IDisposable
    {
        DbSet<ProjectModel> Projects { get; }
        DbSet<UserModel> Users { get; }
        DbSet<CustomerModel> Customers { get; }
        DbSet<RoleModel> Roles { get; }
        DbSet<CityModel> Cities { get; }
        Task<int> SaveChangesAsync();
    }
}