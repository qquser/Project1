using Project1.Application.API.Models;
using Project1.Application.API.Models.User;
using Project1.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands.User.ValidationDecorators
{
    internal class ConfirmPasswordCheckDecorator<TModel> : BaseCommand<TModel> where TModel : IConfirmPasswordCheckModel
    {
        public ConfirmPasswordCheckDecorator(BaseCommand<TModel> decoratedCommand, TModel model)
        {
        }
        public override void Validate(TModel model)
        {
            if (model.NewPassword != model.ConfirmPassword)
                throw new Exception(ExceptionInfo.WrongPasswordConfirmation.Message);
        }
    }
}
