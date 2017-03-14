using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Project1.ReadSide.Models;

namespace Project1.ReadSide.Interfaces
{
    public interface IModelUpdater : IDisposable
    {
        DbSet<ProjectModel> Projects { get; }
        Task<int> SaveChangesAsync();
    }
}