using Project1.Application.API.Models.User;
using Project1.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands.User.ValidationDecorators
{
    public class ConfirmPasswordCheckDecorator : Decorator<RegisterUserModel>
    {
        public ConfirmPasswordCheckDecorator(RegisterUserModel model) : base(model)
        {
        }
        protected override void Validate(RegisterUserModel model)
        {
            if (model.NewPassword != model.ConfirmPassword)
                throw new Exception(ExceptionInfo.WrongPasswordConfirmation.Message);
        }
    }
}
