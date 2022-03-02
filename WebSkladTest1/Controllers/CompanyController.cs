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
    public class CompanyController : ControllerBase
    {
        private readonly MySklad_DBContext dBContext;
        public CompanyController(MySklad_DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        // GET: api/<CompanyController>
        [HttpGet]
        public IEnumerable<CompanyApi> Get()
        {
            return dBContext.Companies.ToList().Select(s => (CompanyApi)s);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyApi>> Get(int id)
        {
            var company = await dBContext.Companies.FindAsync(id);
            if (company == null)
                return NotFound();
            return Ok((CompanyApi)company);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CompanyApi company)
        {
            var newCompany = (Company)company;
            await dBContext.Companies.AddAsync(newCompany);
            await dBContext.SaveChangesAsync();
            return Ok(newCompany.Id);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CompanyApi editCompany)
        {
            var oldCompany = await dBContext.Companies.FindAsync(id);
            if (oldCompany == null)
                return NotFound();
            dBContext.Entry(oldCompany).CurrentValues.SetValues(editCompany);
            await dBContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldCompany = await dBContext.Companies.FindAsync(id);
            if (oldCompany == null)
                return NotFound();
            dBContext.Companies.Remove(oldCompany);
            await dBContext.SaveChangesAsync();
            return Ok();
        }
    }
}
