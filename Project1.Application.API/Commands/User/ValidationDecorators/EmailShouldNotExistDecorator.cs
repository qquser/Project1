using Project1.Application.API.Bus;
using Project1.Application.API.Controllers;
using Project1.Application.API.Models.User;
using Project1.Common.Commands.User;
using Project1.Common.Enums;
using Project1.Common.Queries.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands.User.ValidationDecorators
{
    public class EmailShouldNotExistDecorator: Decorator<RegisterUserModel>
    {
        public EmailShouldNotExistDecorator(RegisterUserModel model) : base(model)
        {
        }

        protected override void Validate(RegisterUserModel model)
        {
            var query = new GetUserByEmail(model.Email);
            var result = BusControl.SendRequest<IGetUserByEmail, IGetUserResult>(query).Result;
            if (result.User!=null)
                throw new Exception(ExceptionInfo.EmailAlreadyExists.Message);
        }

    }
}
