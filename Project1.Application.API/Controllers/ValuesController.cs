using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Project1.Application.API.Models.Project;
using Project1.Application.API.Models;
using Project1.Application.API.Commands;
using Project1.Application.API.Composition_root;
using Project1.Application.API.CrossCuttingConcerns;

namespace Project1.Application.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : EnhancedApiController
    {

        [Authorize]
        [Route("getlogin")]
        public IActionResult GetLogin()
        {
            var query =  GetCommand(new GetProject(), new RenameProjectModel());
            return Ok($"Ваш логин: {User.Identity.Name}");
        }




        [Authorize(Roles = "user")]
        [Route("getrole")]
        public IActionResult GetRole()
        {
            return Ok("Ваша роль: user");
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value"+id;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
