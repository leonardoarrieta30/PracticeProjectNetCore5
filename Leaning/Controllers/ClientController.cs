using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Domain;

namespace Leaning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClienteDomian _clienteDomian;

        public ClientController(IClienteDomian clienteDomian)
        {
            _clienteDomian = clienteDomian;
        }
        
        // GET: api/Client
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Client/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Client
        [HttpPost(Name = "AddPost")]
        public async Task<IActionResult> Post([FromBody] string value)
        {
             await _clienteDomian.add(value);
             return Ok();
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
