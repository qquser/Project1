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
    internal class WorkshopModelConfiguration : BaseModelConfiguration<WorkshopModel>
    {
        protected override void ConfigureModel(EntityTypeBuilder<WorkshopModel> entity)
        {
            entity.HasOne(workshop => workshop.CityModel)
                  .WithMany(city => city.Workshops)
                  .HasForeignKey(workshop => workshop.CityId);
            entity.HasIndex(ws => ws.Name).IsUnique();
        }
    }
}
