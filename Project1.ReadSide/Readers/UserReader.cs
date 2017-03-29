using AutoMapper;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Project1.Common.DTO;
using Project1.Common.Queries.Users;
using Project1.ReadSide.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ReadSide.Readers
{
    public class UserReader :
        IConsumer<IGetAllUsers>,
        IConsumer<IGetUser>,
        IConsumer<IGetUserByEmail>
    {
        private readonly IModelReader _reader;
        private readonly IMapper _mapper;

        public UserReader(IModelReader reader, IMapper mapper)
        {
            _reader = reader;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<IGetAllUsers> context)
        {
            var users = _reader.Users
               .Include(x => x.RoleModel)
               .Select(_mapper.Map<UserDTO>)
               .ToList();
            var respond = new GetAllUsersResult(users);
            await context.RespondAsync(respond);
        }

        public async Task Consume(ConsumeContext<IGetUser> context)
        {
            var project = _mapper.Map<UserDTO>(_reader.Users
                 .Include(x => x.RoleModel)
                 .FirstOrDefault(x => x.AggregateId == context.Message.Id));
                        var respond = new GetUserResult(project);
            await context.RespondAsync(respond);
        }

        public async Task Consume(ConsumeContext<IGetUserByEmail> context)
        {
            var project = _mapper.Map<UserDTO>(_reader.Users
                 .Include(x => x.RoleModel)
                 .FirstOrDefault(x => x.Email == context.Message.Email));
            var respond = new GetUserResult(project);
            await context.RespondAsync(respond);
        }
    }

    class GetAllUsersResult : IGetAllUsersResult
    {
        public GetAllUsersResult(List<UserDTO> users)
        {
            Users = users;
        }

        public List<UserDTO> Users { get; }
    }

    class GetUserResult : IGetUserResult
    {
        public GetUserResult(UserDTO user)
        {
            User = user;
        }

        public UserDTO User { get; }
    }
}
