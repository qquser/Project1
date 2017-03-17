using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project1.ReadSide.Helpers;
using Project1.ReadSide.Models;

namespace Project1.ReadSide.Mappings
{
    internal class UserModelConfiguration : BaseModelConfiguration<UserModel>
    {
        protected override void ConfigureModel(EntityTypeBuilder<UserModel> entity)
        {

        }
    }
}