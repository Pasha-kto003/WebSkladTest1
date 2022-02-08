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
        private SupplierApi CreateSupplierInApi(Supplier supplier, List<ProductApi> products)
        {
            var result = (SupplierApi)supplier;
            result.Products = products;
            return result;
        }
        // GET: api/<SupplierController>
        [HttpGet]
        public IEnumerable<SupplierApi> Get()
        {
            return dBContext.Suppliers.ToList().Select(s =>
            {
                var products = dBContext.ProductSuppliers.Where(t => t.SupplierId == s.Id).Select(t => (ProductApi)t.Product).ToList();
                return CreateSupplierInApi(s, products);
            });
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierApi>> Get(int id)
        {
            var supplier = await dBContext.Suppliers.FindAsync(id);
            var product = dBContext.ProductSuppliers.Where(t => t.SupplierId == id).Select(t => (ProductApi)t.Product).ToList();
            return CreateSupplierInApi(supplier, product);
        }

        // POST api/<SupplierController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] SupplierApi newsupplier)
        {
            foreach (var products in newsupplier.Products)
                if (products.Id == 0)
                    return BadRequest($"{products.Title} не существует");
            var supplier = (Supplier)newsupplier;
            await dBContext.Suppliers.AddAsync(supplier);
            await dBContext.SaveChangesAsync();
            await dBContext.ProductSuppliers.AddRangeAsync(newsupplier.Products.Select(s => new ProductSupplier
            {
                SupplierId = supplier.Id,
                ProductId = s.Id
            }));
            await dBContext.SaveChangesAsync();
            return Ok(supplier.Id);
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] SupplierApi editSupplier)
        {
            foreach (var products in editSupplier.Products)
                if (products.Id == 0)
                    return BadRequest($"Продукт {products.Title} не существует");
            var supplier = (Supplier)editSupplier;
            var oldsupplier = await dBContext.Suppliers.FindAsync(id);
            if (oldsupplier == null)
                return NotFound();
            dBContext.Entry(oldsupplier).CurrentValues.SetValues(supplier);
            var productRemove = dBContext.ProductSuppliers.Where(s => s.SupplierId == id).ToList();
            dBContext.ProductSuppliers.RemoveRange(productRemove);
            await dBContext.ProductSuppliers.AddRangeAsync(editSupplier.Products.Select(s => new ProductSupplier
            {
                SupplierId = supplier.Id,
                ProductId = s.Id
            }));
            await dBContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldSupplier = await dBContext.Suppliers.FindAsync(id);
            if (oldSupplier == null)
            {
                return NotFound();
            }
            var products = dBContext.ProductSuppliers.Where(s => s.SupplierId == id).ToList();
            dBContext.ProductSuppliers.RemoveRange(products);
            dBContext.Suppliers.Remove(oldSupplier);
            await dBContext.SaveChangesAsync();
            return Ok();
        }
    }
}
