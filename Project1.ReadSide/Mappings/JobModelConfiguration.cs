using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project1.ReadSide.Helpers;
using Project1.ReadSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ReadSide.Mappings
{
    internal class JobModelConfiguration : BaseModelConfiguration<JobModel>
    {
        protected override void ConfigureModel(EntityTypeBuilder<JobModel> entity)
        {
            entity.HasOne(job => job.UserModel)
                  .WithMany(user => user.Jobs)
                  .HasForeignKey(job => job.UserId);
            entity.Property(p => p.UserId).IsRequired();

            entity.HasOne(job => job.WorkshopModel)
                 .WithMany(ws => ws.Jobs)
                 .HasForeignKey(job => job.WorkshopId);
            entity.Property(p => p.WorkshopId).IsRequired();
        }
    }
}
