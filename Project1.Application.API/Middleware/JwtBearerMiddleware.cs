using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;

namespace Project1.Application.API.Middleware
{
    /// <summary>
    /// Bearer authentication middleware component which is added to an HTTP pipeline. This class is not
    /// created by application code directly, instead it is added by calling the the IAppBuilder UseJwtBearerAuthentication
    /// extension method.
    /// </summary>
    public class JwtBearerMiddleware : AuthenticationMiddleware<JwtBearerOptions>
    {
        /// <summary>
        /// Bearer authentication component which is added to an HTTP pipeline. This constructor is not
        /// called by application code directly, instead it is added by calling the the IAppBuilder UseJwtBearerAuthentication 
        /// extension method.
        /// </summary>
        public JwtBearerMiddleware(RequestDelegate next, IOptions<JwtBearerOptions> options, ILoggerFactory loggerFactory, UrlEncoder encoder) : base(next, options, loggerFactory, encoder)
        {
        }

        /// <summary>
        /// Called by the AuthenticationMiddleware base class to create a per-request handler. 
        /// </summary>
        /// <returns>A new instance of the request handler</returns>
        protected override AuthenticationHandler<JwtBearerOptions> CreateHandler()
        {
            return new JwtBearerHandler();
        }
    }

  
}
