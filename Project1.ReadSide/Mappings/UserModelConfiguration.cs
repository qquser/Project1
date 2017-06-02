using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project1.ReadSide.Helpers;
using Project1.ReadSide.Interfaces;
using Project1.ReadSide.Models;
using System.ComponentModel.Composition;

namespace Project1.ReadSide.Mappings
{
    internal class UserModelConfiguration : BaseModelConfiguration<UserModel>
    {
        protected override void ConfigureModel(EntityTypeBuilder<UserModel> entity)
        {
            entity.HasOne(user => user.RoleModel)
                  .WithMany(role => role.Users)
                  .HasForeignKey(user => user.RoleId);
            entity.HasIndex(b => b.Email).IsUnique();
        }
    }
}