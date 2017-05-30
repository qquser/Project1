using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using System.IO;
using Project1.ReadSide.Models;
using Project1.ReadSide.Interfaces;

namespace Project1.ReadSide.SeedDb
{
    public static class DbContextExtension
    {
        //TODO при запуске проверяет наличие миграций. Пока в топку
        //public static bool AllMigrationsApplied(this DbContext context)
        //{
        //    var applied = context.GetService<IHistoryRepository>()
        //        .GetAppliedMigrations()
        //        .Select(m => m.MigrationId);

        //    var total = context.GetService<IMigrationsAssembly>()
        //        .Migrations
        //        .Select(m => m.Key);

        //    return !total.Except(applied).Any();
        //}

        // Импровезированный Seed как в EF6
        public static void EnsureSeeded(this IModelUpdater context)
        {
            //Ensure we have some Roles
            if (!context.Roles.Any())
            {
                var roles = new List<RoleModel>()
                {
                     new RoleModel(Guid.NewGuid()){Name = "user", RolePermission = ";user;" },
                     new RoleModel(Guid.NewGuid()){Name = "admin", RolePermission = ";admin;" },
                };

                context.Roles.AddRange(roles);
                context.SaveChangesAsync();
            }
    
        }
    }
}
