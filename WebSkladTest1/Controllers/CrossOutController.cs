using Microsoft.AspNetCore.Mvc;
using ModelApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSkladTest1.db;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebSkladTest1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrossOutController : ControllerBase
    {
        private readonly MySklad_DBContext dBContext;
        public CrossOutController(MySklad_DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        // GET: api/<CrossOutController>
        [HttpGet]
        public IEnumerable<CrossOrderOutApi> Get()
        {
            return dBContext.CrossOrderOuts.Select(s => (CrossOrderOutApi)s);
        }

        // GET api/<CrossOutController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CrossOutController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CrossOutController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CrossOutController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
