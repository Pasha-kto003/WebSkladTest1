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
    public class OrderOutController : ControllerBase
    {
        private readonly MySklad_DBContext dBContext;
        public OrderOutController(MySklad_DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        private OrderOutApi CreateOrderOutApi(OrderOut order, List<ProductApi> products)
        {
            var result = (OrderOutApi)order;
            result.Products = products;
            return result;
        }
        // GET: api/<OrderOutController>
        [HttpGet]
        public IEnumerable<OrderOutApi> Get()
        {
            return dBContext.OrderOuts.ToList().Select(s =>
            {
                var products = dBContext.CrossOrderOuts.Where(t => t.OrderOutId == s.Id).Select(t => (ProductApi)t.Product).ToList();
                return CreateOrderOutApi(s, products);
            });
        }

        // GET api/<OrderOutController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderOutApi>> Get(int id)
        {
            var order = await dBContext.OrderOuts.FindAsync(id);
            var product = dBContext.CrossOrderOuts.Where(t => t.OrderOutId == id).Select(t => (ProductApi)t.Product).ToList();
            return CreateOrderOutApi(order, product);
        }

        // POST api/<OrderOutController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] OrderOutApi newOrder)
        {
            foreach (var products in newOrder.Products)
                if (products.Id == 0)
                    return BadRequest($"{products.Title} не существует");
            var order = (OrderOut)newOrder;
            await dBContext.OrderOuts.AddAsync(order);
            await dBContext.SaveChangesAsync();
            await dBContext.CrossOrderOuts.AddRangeAsync(newOrder.Products.Select(s => new CrossOrderOut
            {
                OrderOutId = order.Id,
                ProductId = s.Id,
                CountOutOrder = s.CountProductsOut
            }));
            await dBContext.SaveChangesAsync();
            return Ok(order.Id);
        }

        // PUT api/<OrderOutController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] OrderOutApi editOrder)
        {
            foreach (var products in editOrder.Products)
                if (products.Id == 0)
                    return BadRequest($"Продукт {products.Title} не существует");
            var order = (OrderOut)editOrder;
            var oldOrder = await dBContext.OrderOuts.FindAsync(id);
            if (oldOrder == null)
                return NotFound();
            dBContext.Entry(oldOrder).CurrentValues.SetValues(order);
            var productRemove = dBContext.CrossOrderOuts.Where(s => s.OrderOutId == id).ToList();
            dBContext.CrossOrderOuts.RemoveRange(productRemove);
            await dBContext.CrossOrderOuts.AddRangeAsync(editOrder.Products.Select(s => new CrossOrderOut
            {
                OrderOutId = order.Id,
                ProductId = s.Id,
                CountOutOrder = s.CountProductsOut
            }));
            await dBContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<OrderOutController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldOrder = await dBContext.OrderOuts.FindAsync(id);
            if (oldOrder == null)
            {
                return NotFound();
            }
            var products = dBContext.CrossOrderOuts.Where(s => s.OrderOutId == id).ToList();
            dBContext.CrossOrderOuts.RemoveRange(products);
            dBContext.OrderOuts.Remove(oldOrder);
            await dBContext.SaveChangesAsync();
            return Ok();
        }
    }
}
