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
    public class SupplierController : ControllerBase
    {
        private readonly MySklad_DBContext dBContext;
        public SupplierController(MySklad_DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        
        // GET: api/<SupplierController>
        [HttpGet]
        public IEnumerable<SupplierApi> Get()
        {
            return dBContext.Suppliers.ToList().Select(s => (SupplierApi)s);
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierApi>> Get(int id)
        {
            var supplier = await dBContext.Suppliers.FindAsync(id);
            if (supplier == null)
                return NotFound();
            return Ok((SupplierApi)supplier);
        }

        // POST api/<SupplierController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] SupplierApi supplier)
        {
            var newsupplier = (Supplier)supplier;
            await dBContext.Suppliers.AddAsync(newsupplier);
            await dBContext.SaveChangesAsync();
            return Ok(newsupplier.Id);
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] SupplierApi editSupplier)
        {
            var oldSup = await dBContext.Suppliers.FindAsync(id);
            if (oldSup == null)
                return NotFound();
            dBContext.Entry(oldSup).CurrentValues.SetValues(editSupplier);
            await dBContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldSup = await dBContext.Suppliers.FindAsync(id);
            if (oldSup == null)
                return NotFound();
            dBContext.Suppliers.Remove(oldSup);
            await dBContext.SaveChangesAsync();
            return Ok();
        }
    }
}
