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
    public class PersonalController : ControllerBase
    {
        private readonly MySklad_DBContext dBContext;
        public PersonalController(MySklad_DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        // GET: api/<PersonalController>
        [HttpGet]
        public IEnumerable<PersonalApi> Get()
        {
            return dBContext.Personals.Select(s => (PersonalApi)s);
        }

        // GET api/<PersonalController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalApi>> Get(int id)
        {
            var result = await dBContext.Personals.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((PersonalApi)result);
        }

        // POST api/<PersonalController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] PersonalApi value)
        {
            var personal = (Personal)value;
            await dBContext.Personals.AddAsync(personal);
            await dBContext.SaveChangesAsync();
            return Ok(personal.Id);
        }

        // PUT api/<PersonalController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PersonalApi value)
        {
            var result = await dBContext.Personals.FindAsync(id);
            if (result == null)
                return NotFound();
            var personal = (Personal)value;
            dBContext.Entry(result).CurrentValues.SetValues(personal);
            await dBContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<PersonalController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var personal = await dBContext.Personals.FindAsync(id);
            if (personal == null)
                return NotFound();
            dBContext.Remove(personal);
            await dBContext.SaveChangesAsync();
            return Ok();
        }
    }
}
