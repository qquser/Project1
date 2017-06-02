using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project1.ReadSide.Helpers;
using Project1.ReadSide.Interfaces;
using Project1.ReadSide.Models;
using System.ComponentModel.Composition;

namespace Project1.ReadSide.Mappings
{
    internal class CustomerModelConfiguration : BaseModelConfiguration<CustomerModel>
    {
        protected override void ConfigureModel(EntityTypeBuilder<CustomerModel> entity)
        {

        }
    }

}