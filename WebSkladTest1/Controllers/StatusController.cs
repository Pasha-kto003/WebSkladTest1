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
    public class StatusController : ControllerBase
    {
        private readonly MySklad_DBContext dBContext;
        public StatusController(MySklad_DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        // GET: api/<StatusController>
        [HttpGet]
        public IEnumerable<StatusApi> Get()
        {
            return dBContext.Statuses.ToList().Select(s => (StatusApi)s);
        }

        // GET api/<StatusController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusApi>> Get(int id)
        {
            var status = await dBContext.Statuses.FindAsync(id);
            if (status == null)
                return NotFound();
            //return Ok(CreateUnitApi(unit, products));
            return Ok((StatusApi)status);
        }

        // POST api/<StatusController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] StatusApi status)
        {
            var newstatus = (Status)status;
            await dBContext.Statuses.AddAsync(newstatus);
            await dBContext.SaveChangesAsync();
            return Ok(newstatus.Id);
        }

        // PUT api/<StatusController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] StatusApi editStatus)
        {
            var oldStatus = await dBContext.Statuses.FindAsync(id);
            if (oldStatus == null)
                return NotFound();
            dBContext.Entry(oldStatus).CurrentValues.SetValues(editStatus);
            await dBContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<StatusController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldStatus = await dBContext.Statuses.FindAsync(id);
            if (oldStatus == null)
                return NotFound();
            dBContext.Statuses.Remove(oldStatus);
            await dBContext.SaveChangesAsync();
            return Ok();
        }
    }
}
