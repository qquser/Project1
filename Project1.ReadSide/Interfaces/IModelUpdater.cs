using System;
using System.Threading.Tasks;
using Project1.ReadSide.Models;
using Microsoft.EntityFrameworkCore;

namespace Project1.ReadSide.Interfaces
{
    public interface IModelUpdater : IDisposable
    {
        DbSet<ProjectModel> Projects { get; }
        Task<int> SaveChangesAsync();
    }
}