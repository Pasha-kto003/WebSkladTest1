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
    public class CrossInController : ControllerBase
    {
        private readonly MySklad_DBContext dBContext;
        public CrossInController(MySklad_DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        // GET: api/<CrossInController>
        [HttpGet]
        public IEnumerable<CrossProductOrderApi> Get()
        {
            return dBContext.CrossProductOrders.Select(s => (CrossProductOrderApi)s);
        }

        // GET api/<CrossInController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CrossInController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CrossInController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CrossInController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
