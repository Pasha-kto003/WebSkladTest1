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
    public class ProductController : ControllerBase
    {
        private readonly MySklad_DBContext dBContext;
        public ProductController(MySklad_DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductApi> Get()
        {
            return dBContext.Products.Select(s => (ProductApi)s);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductApi>> Get(int id)
        {
            var result = await dBContext.Products.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((ProductApi)result);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ProductApi value)
        {
            var type = (Product)value;
            await dBContext.Products.AddAsync(type);
            await dBContext.SaveChangesAsync();
            return Ok(type.Id);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductApi value)
        {
            var result = await dBContext.Products.FindAsync(id);
            if (result == null)
                return NotFound();
            var product = (Product)value;
            dBContext.Entry(result).CurrentValues.SetValues(product);
            await dBContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await dBContext.Products.FindAsync(id);
            if (product == null)
                return NotFound();
            dBContext.Remove(product);
            await dBContext.SaveChangesAsync();
            return Ok();
            
        }
    }
}
