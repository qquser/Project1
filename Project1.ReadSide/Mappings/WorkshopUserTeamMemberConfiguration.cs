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
    internal class WorkshopUserTeamMemberConfiguration : BaseModelConfiguration<WorkshopUserTeamMember>
    {
        protected override void ConfigureModel(EntityTypeBuilder<WorkshopUserTeamMember> entity)
        {
            entity.HasOne(member => member.UserModel)
                  .WithMany(user => user.UserWorkshopsRoles)
                  .HasForeignKey(member => member.UserId);

            entity.HasOne(member => member.WorkshopModel)
                   .WithMany(user => user.WorkshopUsersRoles)
                   .HasForeignKey(member => member.WorkshopId);

            entity.HasOne(member => member.RoleModel)
                   .WithMany(user => user.RoleWorkshopsUsers)
                   .HasForeignKey(member => member.RoleId);

            entity.HasIndex(member => new { member.UserId, member.WorkshopId }).IsUnique(); 
        }
    }
}
