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
    public class WriteOffRegisterController : ControllerBase
    {
        private readonly MySklad_DBContext dBContext;
        public WriteOffRegisterController(MySklad_DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        // GET: api/<WriteOffRegisterController>
        [HttpGet]
        public IEnumerable<WriteOffRegisterApi> Get()
        {
            return dBContext.WriteOffRegisters.Select(s => (WriteOffRegisterApi)s);
        }

        // GET api/<WriteOffRegisterController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WriteOffRegisterApi>> Get(int id)
        {
            var result = await dBContext.WriteOffRegisters.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((WriteOffRegisterApi)result);
        }

        // POST api/<WriteOffRegisterController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] WriteOffRegisterApi value)
        {           
            var type = (WriteOffRegister)value;
            var prod = dBContext.Products.FirstOrDefault(s => s.Id == type.ProductId);
            await dBContext.WriteOffRegisters.AddAsync(type);
            if (type.ProductId != 0)
            {
                prod.Status = "Удален";
            }
            await dBContext.SaveChangesAsync();
            return Ok(type.Id);
        }

        // PUT api/<WriteOffRegisterController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] WriteOffRegisterApi value)
        {
            var result = await dBContext.WriteOffRegisters.FindAsync(id);
            if (result == null)
                return NotFound();
            var register = (WriteOffRegister)value;
            dBContext.Entry(result).CurrentValues.SetValues(register);
            await dBContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<WriteOffRegisterController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var register = await dBContext.WriteOffRegisters.FindAsync(id);
            if (register == null)
                return NotFound();
            dBContext.Remove(register);
            await dBContext.SaveChangesAsync();
            return Ok();
        }
    }
}
