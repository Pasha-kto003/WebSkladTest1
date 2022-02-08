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
    public class ProductTypeController : ControllerBase
    {
        private readonly MySklad_DBContext dBContext;
        public ProductTypeController(MySklad_DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        // GET: api/<ProductTypeController>
        [HttpGet]
        public IEnumerable<ProductTypeApi> Get()
        {
            return dBContext.ProductTypes.ToList().Select(s => (ProductTypeApi)s);
        }

        // GET api/<ProductTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTypeApi>> Get(int id)
        {
            var productType = await dBContext.ProductTypes.FindAsync(id);
            if (productType == null)
                return NotFound();
            //return Ok(CreateUnitApi(unit, products));
            return Ok((ProductTypeApi)productType);
        }

        // POST api/<ProductTypeController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ProductTypeApi productType)
        {
            var newType = (ProductType)productType;
            await dBContext.ProductTypes.AddAsync(newType);
            await dBContext.SaveChangesAsync();
            return Ok(newType.Id);
        }

        // PUT api/<ProductTypeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductTypeApi editType)
        {
            var oldType = await dBContext.ProductTypes.FindAsync(id);
            if (oldType == null)
                return NotFound();
            dBContext.Entry(oldType).CurrentValues.SetValues(editType);
            await dBContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<ProductTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldType = await dBContext.ProductTypes.FindAsync(id);
            if (oldType == null)
                return NotFound();
            dBContext.ProductTypes.Remove(oldType);
            await dBContext.SaveChangesAsync();
            return Ok();
        }
    }
}
