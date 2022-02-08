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
    public class ShopController : ControllerBase
    {
        private readonly MySklad_DBContext dBContext;
        public ShopController(MySklad_DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        // GET: api/<ShopController>
        [HttpGet]
        public IEnumerable<ShopApi> Get()
        {
            return dBContext.Shops.ToList().Select(s => (ShopApi)s);
        }

        // GET api/<ShopController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopApi>> Get(int id)
        {
            var shop = await dBContext.Shops.FindAsync(id);
            if (shop == null)
                return NotFound();
            return Ok((ShopApi)shop);
        }

        // POST api/<ShopController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ShopApi shop)
        {
            var newshop = (Shop)shop;
            await dBContext.Shops.AddAsync(newshop);
            await dBContext.SaveChangesAsync();
            return Ok(newshop.Id);
            
        }

        // PUT api/<ShopController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ShopApi editShop)
        {
            var oldShop = await dBContext.Shops.FindAsync(id);
            if (oldShop == null)
                return NotFound();
            dBContext.Entry(oldShop).CurrentValues.SetValues(editShop);
            await dBContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<ShopController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldShop = await dBContext.Shops.FindAsync(id);
            if (oldShop == null)
                return NotFound();
            dBContext.Shops.Remove(oldShop);
            await dBContext.SaveChangesAsync();
            return Ok();
        }
    }
}
