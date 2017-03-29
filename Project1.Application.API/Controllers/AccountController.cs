using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Project1.Application.API.Commands.User;
using Project1.Application.API.Helpers;
using Project1.Application.API.Models;
using Project1.Application.API.Models.User;
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
                await Send(command);

                return Accepted(new PostResult<RegisterUserCommand>()
                {
                    CommandId = command.Id,
                    Timestamp = command.Timestamp
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

            var identity = GetIdentity(email, password);
            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
                return;
                //return BadRequest("Invalid username or password.");
            }
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
            // сериализация ответа
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));

        }

        private ClaimsIdentity GetIdentity(string email, string password)
        {
            var query = new GetUserByEmail(email);
            var result = SendRequest<IGetUserByEmail, IGetUserResult>(query).Result;

            if (result.User == null || result.User == null)
                return null;

            if (Hashing.ValidatePassword(password, result.User.PasswordHash))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, result.User.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, result.User.RoleName)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }

    }

    public class GetAllUsers : IGetAllUsers
    {
    }

    public class GetUserByEmail : IGetUserByEmail
    {
        public GetUserByEmail(string email)
        {
            Email = email;
        }

        public string Email { get; }
    }

}
