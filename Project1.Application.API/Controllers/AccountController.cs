using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using Project1.Application.API.Bus;
using Project1.Application.API.Commands.User;
using Project1.Application.API.Helpers;
using Project1.Application.API.Models;
using Project1.Application.API.Models.User;
using Project1.Application.API.Queries.User;
using Project1.Common;
using Project1.Common.Commands.User;
using Project1.Common.DTO;
using Project1.Common.Queries.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project1.Application.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : EnhancedApiController
    {
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUserModel model)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (model.CommandId == Guid.Empty)
                    model.CommandId = NewId.NextGuid();

                var command = new RegisterUserCommand(model);
                var result = await BusControl.SendCommandWithRespond<IRegisterUser, IGetUserResult>(command);

                var identity = AuthOptions.GetIdentity(command.Email, model.NewPassword, result.User.PasswordHash, result.User.RoleName);
                if (identity == null)
                {
                    return BadRequest("Invalid username or password.");
                }
                var token = AuthOptions.Token(identity);

                return Accepted(new AuthPostResult<RegisterUserCommand>()
                {
                    CommandId = result.User.Id,
                    Timestamp = command.Timestamp,
                    Token = token,

                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        [Route("token")]
        public async Task Token(TokenUserModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("username or password cannot be empty");
                return;
            }

            var email = model.UserName;//Request.Form["username"];
            var password = model.Password;//Request.Form["password"];

            var query = new GetUserByEmail(email);
            var result = BusControl.SendRequest<IGetUserByEmail, IGetUserResult>(query).Result;

            var identity = AuthOptions.GetIdentity(email, password, result.User.PasswordHash, result.User.RoleName);
            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
                return;
                //return BadRequest("Invalid username or password.");
            }
            var encodedJwt = AuthOptions.Token(identity);

            var response = new
            {
                accesstoken = encodedJwt,
                username = identity.Name
            };
            // сериализация ответа
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));

        }

    }




}
