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
    public class CrossRackController : ControllerBase
    {
        private readonly MySklad_DBContext dBContext;
        public CrossRackController(MySklad_DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        // GET: api/<CrossRackController>
        [HttpGet]
        public IEnumerable<CrossProductRackApi> Get()
        {
            return dBContext.CrossProductRacks.Select(s => (CrossProductRackApi)s);
        }

        // GET api/<CrossRackController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CrossRackController>
        [HttpPost]
        public async Task Post([FromBody] CrossProductRackApi crossProduct)
        {
            var newUnit = (CrossProductRack)crossProduct;
            await dBContext.CrossProductRacks.AddAsync(newUnit);
            await dBContext.SaveChangesAsync();
        }

        // PUT api/<CrossRackController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CrossProductRackApi crossProduct)
        {
        }

        // DELETE api/<CrossRackController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
