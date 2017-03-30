using System.Threading.Tasks;
using Project1.Common.Commands.User;
using Project1.Domain.User.Service;
using MassTransit;
using Project1.Common.Queries.Users;
using Project1.Common.DTO;
using AutoMapper;

namespace Project1.WriteSide.Handlers.User
{
    public class UserHandler :
        IConsumer<IRegisterUser>,
        IConsumer<IPromoteUser>,
        IConsumer<IDemoteUser>
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserHandler(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        public async Task Consume(ConsumeContext<IRegisterUser> context)
        {
            var userState = _service.Add(context.Message.Id, context.Message.Email, context.Message.PasswordHash);
            var respond = new AddUserResult(_mapper.Map<UserDTO>(userState));
            await context.RespondAsync(respond);
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

    class AddUserResult : IGetUserResult
    {
        public AddUserResult(UserDTO user)
        {
            User = user;
        }

        public UserDTO User { get; }
    }
}