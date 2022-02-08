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
    public class UnitController : ControllerBase
    {
        private readonly MySklad_DBContext dBContext;
        public UnitController(MySklad_DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        // GET: api/<UnitController>
        [HttpGet]
        public IEnumerable<UnitApi> Get()
        {
            return dBContext.Units.ToList().Select(s => (UnitApi)s);
        }

        // GET api/<UnitController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitApi>> Get(int id)
        {
            var unit = await dBContext.Units.FindAsync(id);
            if (unit == null)
                return NotFound();
            //return Ok(CreateUnitApi(unit, products));
            return Ok((UnitApi)unit);
        }

        // POST api/<UnitController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] UnitApi unitApi)
        {
            var newUnit = (Unit)unitApi;
            await dBContext.Units.AddAsync(newUnit);
            await dBContext.SaveChangesAsync();
            return Ok(newUnit.Id);
        }

        // PUT api/<UnitController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UnitApi editUnit)
        {
            var oldUnit = await dBContext.Units.FindAsync(id);
            if (oldUnit == null)
                return NotFound();
            dBContext.Entry(oldUnit).CurrentValues.SetValues(editUnit);
            await dBContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<UnitController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldunit = await dBContext.Units.FindAsync(id);
            if (oldunit == null)
                return NotFound();
            dBContext.Units.Remove(oldunit);
            await dBContext.SaveChangesAsync();
            return Ok();
        }
    }
}
