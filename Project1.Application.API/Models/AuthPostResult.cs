using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Models
{
    public class AuthPostResult<T>
    {
        public string CommandName => nameof(T);
        public Guid CommandId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Token { get; set; }
    }
}
