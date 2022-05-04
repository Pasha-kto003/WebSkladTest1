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
    public class RackController : ControllerBase
    {
        private readonly MySklad_DBContext dBContext;
        public RackController(MySklad_DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        private RackApi CreateRackApi(Rack rack, List<ProductApi> products)
        {
            var result = (RackApi)rack;
            result.Products = products;
            return result;
        }
        // GET: api/<RackController>
        [HttpGet]
        public IEnumerable<RackApi> Get()
        {
            return dBContext.Racks.ToList().Select(s =>
            {
                var products = dBContext.CrossProductRacks.Where(t => t.RackId == s.Id).Select(t => (ProductApi)t.Product).ToList();
                return CreateRackApi(s, products);
            });
        }

        // GET api/<RackController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RackApi>> Get(int id)
        {
            var rack = await dBContext.Racks.FindAsync(id);
            var product = dBContext.CrossProductRacks.Where(t => t.RackId == id).Select(t => (ProductApi)t.Product).ToList();
            return CreateRackApi(rack, product);
        }

        // POST api/<RackController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] RackApi newRack)
        {
            foreach (var products in newRack.Products)
                if (products.Id == 0)
                    return BadRequest($"{products.Title} не существует");
            var rack = (Rack)newRack;
            await dBContext.Racks.AddAsync(rack);
            await dBContext.SaveChangesAsync();
            await dBContext.CrossProductRacks.AddRangeAsync(newRack.Products.Select(s => new CrossProductRack
            {
                RackId = rack.Id,
                ProductId = s.Id,
                DateProductPlacement = DateTime.Now
            }));
            await dBContext.SaveChangesAsync();
            return Ok(rack.Id);
        }

        // PUT api/<RackController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RackApi editRack)
        {
            foreach (var products in editRack.Products)
                if (products.Id == 0)
                    return BadRequest($"Продукт {products.Title} не существует");
            var rack = (Rack)editRack;
            var oldRack = await dBContext.Racks.FindAsync(id);
            if (oldRack == null)
                return NotFound();
            dBContext.Entry(oldRack).CurrentValues.SetValues(rack);
            var productRemove = dBContext.CrossProductRacks.Where(s => s.RackId == id).ToList();
            dBContext.CrossProductRacks.RemoveRange(productRemove);
            await dBContext.CrossProductRacks.AddRangeAsync(editRack.Products.Select(s => new CrossProductRack
            {
                RackId = rack.Id,
                ProductId = s.Id,
                DateProductPlacement = DateTime.Now
            }));
            await dBContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<RackController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldRack = await dBContext.Racks.FindAsync(id);
            if (oldRack == null)
            {
                return NotFound();
            }
            var products = dBContext.CrossProductRacks.Where(s => s.RackId == id).ToList();
            dBContext.CrossProductRacks.RemoveRange(products);
            dBContext.Racks.Remove(oldRack);
            await dBContext.SaveChangesAsync();
            return Ok();
        }
    }
}
