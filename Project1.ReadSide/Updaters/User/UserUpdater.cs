using System.Threading.Tasks;
using Project1.Common.Enums;
using Project1.Common.Events.UserAdded;
using Project1.ReadSide.Helpers;
using Project1.ReadSide.Interfaces;
using Project1.ReadSide.Models;
using MassTransit;
using System.Linq;
using System;

namespace Project1.ReadSide.Updaters.User
{
    public class UserUpdater :
        IConsumer<IUserRegistred>,
        IConsumer<IUserPromoted>,
        IConsumer<IUserDemoted>
    {
        private readonly IModelUpdater _context;

        public UserUpdater(IModelUpdater context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<IUserRegistred> context)
        {
            var roleId = _context.Roles.Single(x => x.Name.Equals(context.Message.RoleName)).Id;
            var user = new UserModel(context.Message.Id)
            {
                Email = context.Message.Email,
                PasswordHash = context.Message.PasswordHash,
                RoleId = roleId,
                Status = UserStatus.Active,
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }


        public async Task Consume(ConsumeContext<IUserPromoted> context)
        {
            //var user = _context.Users.FindAggregate(context.Message.UserId);
            //user.Role = UserRole.Manager;
            //await _context.SaveChangesAsync();
        }

        public async Task Consume(ConsumeContext<IUserDemoted> context)
        {
            //var user = _context.Users.FindAggregate(context.Message.UserId);
            //user.Role = UserRole.Engineer;
            //await _context.SaveChangesAsync();
        }
    }
}