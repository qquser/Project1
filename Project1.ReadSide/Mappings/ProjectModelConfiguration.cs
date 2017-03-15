using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project1.ReadSide.Helpers;
using Project1.ReadSide.Interfaces;
using Project1.ReadSide.Models;

namespace Project1.ReadSide.Mappings
{
    internal class ProjectModelConfiguration : BaseModelConfiguration<ProjectModel>
    {
        protected override void ConfigureModel(EntityTypeBuilder<ProjectModel> entity)
        {
           
        }
    }
}