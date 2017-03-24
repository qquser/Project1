using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Application.API.Models;

namespace Project1.Application.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : EnhancedApiController
    {
        public CustomUserManager PCustomUserManager { get; private set; }

        public AccountController() : this(new CustomUserManager())
        {

        }

        public AccountController(CustomUserManager customUserManager)
        {
            PCustomUserManager = customUserManager;
        }
    }
}