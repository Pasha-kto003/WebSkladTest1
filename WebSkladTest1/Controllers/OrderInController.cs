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
    public class OrderInController : ControllerBase
    {
        private readonly MySklad_DBContext dBContext;
        public OrderInController(MySklad_DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        private OrderInApi CreateOrderInApi(OrderIn orderIn, List<ProductApi> products)
        {
            var result = (OrderInApi)orderIn;
            result.Products = products;
            return result;
        }
        // GET: api/<OrderInController>
        [HttpGet]
        public IEnumerable<OrderInApi> Get()
        {
            return dBContext.OrderIns.ToList().Select(s =>
            {
                var products = dBContext.CrossProductOrders.Where(t => t.OrderInId == s.Id).Select(t => (ProductApi)t.Product).ToList();
                return CreateOrderInApi(s, products);
            });
        }

        // GET api/<OrderInController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderInApi>> Get(int id)
        {
            var order = await dBContext.OrderIns.FindAsync(id);
            var product = dBContext.CrossProductOrders.Where(t => t.OrderInId == id).Select(t => (ProductApi)t.Product).ToList();
            return CreateOrderInApi(order, product);
        }

        // POST api/<OrderInController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] OrderInApi newOrder)
        {
            foreach (var products in newOrder.Products)
                if (products.Id == 0)
                    return BadRequest($"{products.Title} не существует");
            var order = (OrderIn)newOrder;
            await dBContext.OrderIns.AddAsync(order);
            await dBContext.SaveChangesAsync();
            await dBContext.CrossProductOrders.AddRangeAsync(newOrder.Products.Select(s => new CrossProductOrder
            {
                OrderInId = order.Id,
                ProductId = s.Id
            }));
            await dBContext.SaveChangesAsync();
            return Ok(order.Id);
        }

        // PUT api/<OrderInController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] OrderInApi editOrder)
        {
            foreach (var products in editOrder.Products)
                if (products.Id == 0)
                    return BadRequest($"Продукт {products.Title} не существует");
            var order = (OrderIn)editOrder;
            var oldOrder = await dBContext.OrderIns.FindAsync(id);
            if (oldOrder == null)
                return NotFound();
            dBContext.Entry(oldOrder).CurrentValues.SetValues(order);
            var productRemove = dBContext.CrossProductOrders.Where(s => s.OrderInId == id).ToList();
            dBContext.CrossProductOrders.RemoveRange(productRemove);
            await dBContext.CrossProductOrders.AddRangeAsync(editOrder.Products.Select(s => new CrossProductOrder
            {
                OrderInId = order.Id,
                ProductId = s.Id
            }));
            await dBContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<OrderInController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldOrder = await dBContext.OrderIns.FindAsync(id);
            if (oldOrder == null)
            {
                return NotFound();
            }
            var products = dBContext.CrossProductOrders.Where(s => s.OrderInId == id).ToList();
            dBContext.CrossProductOrders.RemoveRange(products);
            dBContext.OrderIns.Remove(oldOrder);
            await dBContext.SaveChangesAsync();
            return Ok();
        }
    }
}
