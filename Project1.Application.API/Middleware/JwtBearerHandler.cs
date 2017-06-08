using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Project1.Application.API.Bus;
using Project1.Application.API.CrossCuttingConcerns;
using Project1.Application.API.Queries.User;
using Project1.Common.DTO;
using Project1.Common.Enums;
using Project1.Common.Queries.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project1.Application.API.Middleware
{
    //TODO необходим процесс изменения внутренней структуры класса, не затрагивающий её внешнего поведения и имеющий целью облегчить понимание её работы. Иными словами -  исправить говнокод, но не сегодня
    internal class JwtBearerHandler : AuthenticationHandler<JwtBearerOptions>
    {
        private OpenIdConnectConfiguration _configuration;
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string token = null;
            AuthenticateResult result = null;
            try
            { 
                // Give application opportunity to find from a different location, adjust, or reject token
                var messageReceivedContext = new MessageReceivedContext(Context, Options);

                // event can set the token
                await Options.Events.MessageReceived(messageReceivedContext);
                if (messageReceivedContext.CheckEventResult(out result))
                {
                    return result;
                }

                // If application retrieved token from somewhere else, use that.
                token = messageReceivedContext.Token;

                if (string.IsNullOrEmpty(token))
                {
                    string authorization = Request.Headers["Authorization"];

                    // If no authorization header found, nothing to process further
                    if (string.IsNullOrEmpty(authorization))
                    {
                        return AuthenticateResult.Skip();
                    }

                    if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    {
                        token = authorization.Substring("Bearer ".Length).Trim();
                    }

                    // If no token found, no further work possible
                    if (string.IsNullOrEmpty(token))
                    {
                        return AuthenticateResult.Skip();
                    }
                }

                var validationParameters = await Param();

                List<Exception> validationFailures = null;
                SecurityToken validatedToken;
                foreach (var validator in Options.SecurityTokenValidators)
                {
                    if (validator.CanReadToken(token))
                    {
                        ClaimsPrincipal principal;
                        try
                        {
                            principal = validator.ValidateToken(token, validationParameters, out validatedToken);
                        }
                        catch (Exception ex)
                        {


                            // Refresh the configuration for exceptions that may be caused by key rollovers. The user can also request a refresh in the event.
                            if (Options.RefreshOnIssuerKeyNotFound && Options.ConfigurationManager != null
                                && ex is SecurityTokenSignatureKeyNotFoundException)
                            {
                                Options.ConfigurationManager.RequestRefresh();
                            }

                            if (validationFailures == null)
                            {
                                validationFailures = new List<Exception>(1);
                            }
                            validationFailures.Add(ex);
                            continue;
                        }


                        var ticket = new AuthenticationTicket(principal, new AuthenticationProperties(), Options.AuthenticationScheme);
                        var tokenValidatedContext = new TokenValidatedContext(Context, Options)
                        {
                            Ticket = ticket,
                            SecurityToken = validatedToken,
                        };

                        await Options.Events.TokenValidated(tokenValidatedContext);
                        if (tokenValidatedContext.CheckEventResult(out result))
                        {
                            return result;
                        }
                        ticket = tokenValidatedContext.Ticket;

                        
                        string email = ticket.Principal.Identity.Name;
                        var user = UserExtensions.GetUser(ticket.Principal.Identity.Name);
                        if(user.User.Status != UserStatus.Active)
                            return AuthenticateResult.Skip();

                        if (Options.SaveToken)
                        {
                            ticket.Properties.StoreTokens(new[]
                            {
                                new AuthenticationToken { Name = "access_token", Value = token }
                            });
                        }

                        return AuthenticateResult.Success(ticket);
                    }
                }
                if (validationFailures != null)
                {
                    var authenticationFailedContext = new AuthenticationFailedContext(Context, Options)
                    {
                        Exception = (validationFailures.Count == 1) ? validationFailures[0] : new AggregateException(validationFailures)
                    };

                    await Options.Events.AuthenticationFailed(authenticationFailedContext);
                    if (authenticationFailedContext.CheckEventResult(out result))
                    {
                        return result;
                    }

                    return AuthenticateResult.Fail(authenticationFailedContext.Exception);
                }

                return AuthenticateResult.Fail("No SecurityTokenValidator available for token: " + token ?? "[null]");
            }
            catch (Exception ex)
            {

                var authenticationFailedContext = new AuthenticationFailedContext(Context, Options)
                {
                    Exception = ex
                };

                await Options.Events.AuthenticationFailed(authenticationFailedContext);
                if (authenticationFailedContext.CheckEventResult(out result))
                {
                    return result;
                }

                throw;
            }
        }


        private async Task<TokenValidationParameters> Param()
        {
            if (_configuration == null && Options.ConfigurationManager != null)
            {
                _configuration = await Options.ConfigurationManager.GetConfigurationAsync(Context.RequestAborted);
            }

            var validationParameters = Options.TokenValidationParameters.Clone();
            if (_configuration != null)
            {
                if (validationParameters.ValidIssuer == null && !string.IsNullOrEmpty(_configuration.Issuer))
                {
                    validationParameters.ValidIssuer = _configuration.Issuer;
                }
                else
                {
                    var issuers = new[] { _configuration.Issuer };
                    validationParameters.ValidIssuers = (validationParameters.ValidIssuers == null ? issuers : validationParameters.ValidIssuers.Concat(issuers));
                }

                validationParameters.IssuerSigningKeys = (validationParameters.IssuerSigningKeys == null ? _configuration.SigningKeys : validationParameters.IssuerSigningKeys.Concat(_configuration.SigningKeys));
            }

            return validationParameters;
        }

        private async Task<AuthenticateResult> ReadAuthorizationHeader()
        {
            string token = null;
            AuthenticateResult result = null;

            // Give application opportunity to find from a different location, adjust, or reject token
            var messageReceivedContext = new MessageReceivedContext(Context, Options);

            // event can set the token
            await Options.Events.MessageReceived(messageReceivedContext);
            if (messageReceivedContext.CheckEventResult(out result))
            {
                return result;
            }

            // If application retrieved token from somewhere else, use that.
            token = messageReceivedContext.Token;

            if (string.IsNullOrEmpty(token))
            {
                string authorization = Request.Headers["Authorization"];

                // If no authorization header found, nothing to process further
                if (string.IsNullOrEmpty(authorization))
                {
                    return AuthenticateResult.Skip();
                }

                if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    token = authorization.Substring("Bearer ".Length).Trim();
                }

                // If no token found, no further work possible
                if (string.IsNullOrEmpty(token))
                {
                    return AuthenticateResult.Skip();
                }
            }

            return null;
        }
    }
}
