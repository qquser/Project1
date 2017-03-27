using System.Threading.Tasks;
using Project1.Common.Commands.User;
using Project1.Domain.User.Service;
using MassTransit;

namespace Project1.WriteSide.Handlers.User
{
    public class UserHandler :
        IConsumer<IRegisterUser>,
        IConsumer<IPromoteUser>,
        IConsumer<IDemoteUser>
    {
        private readonly IUserService _service;

        public UserHandler(IUserService service)
        {
            _service = service;
        }


        public async Task Consume(ConsumeContext<IRegisterUser> context)
        {
            await Task.Run(() => _service.Add(context.Message.Id, context.Message.Email, context.Message.PasswordHash));
        }

    

        public async Task Consume(ConsumeContext<IPromoteUser> context)
        {
            await Task.Run(() => _service.Promote(context.Message.UserId));
        }

        public async Task Consume(ConsumeContext<IDemoteUser> context)
        {
            await Task.Run(() => _service.Demote(context.Message.UserId));
        }
    }
}