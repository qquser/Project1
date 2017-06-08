using Project1.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.CrossCuttingConcerns
{
    public abstract class BaseHandler : IBaseHandler
    {
        public UserDTO User { get; set; }
    }
}
