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
    internal class CityModelConfiguration : BaseModelConfiguration<CityModel>
    {
        protected override void ConfigureModel(EntityTypeBuilder<CityModel> entity)
        {

        }
    }
}
