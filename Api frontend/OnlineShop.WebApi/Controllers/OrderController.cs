using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.WebApi;
using OnlineShop.WebApi.Models;
using OnlineShop.WebApi.Models.Entities;

namespace OnlineShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly SqlContext _context;

        public OrderController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetOrders()
        {
            var items = new List<OrderModel>();
            foreach (var item in await _context.Orders.ToListAsync())
                items.Add(new OrderModel(item.Id, item.Created, item.LastUpdate, item.StatusTypeId, item.CustomerId));

            return items;
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> GetOrderEntity(int id)
        {
            var orderEntity = await _context.Orders.FindAsync(id);

            if (orderEntity == null)
            {
                return NotFound();
            }

            return new OrderModel(orderEntity.Id, orderEntity.Created, orderEntity.LastUpdate, orderEntity.StatusTypeId, orderEntity.CustomerId);
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderEntity(int id, OrderUpdateModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var orderEntity = await _context.Orders.FindAsync(model.Id);

            if (orderEntity == null)
                return NotFound();

            orderEntity.StatusTypeId = model.StatusTypeId;
            orderEntity.CustomerId = model.CustomerId;


            _context.Entry(orderEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderModel>> PostOrderEntity(OrderCreateModel model)
        {
            var orderEntity = new OrderEntity(model.Created, model.LastUpdate, model.StatusTypeId, model.CustomerId);
            _context.Orders.Add(orderEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderEntity", new { id = orderEntity.Id }, new OrderModel(orderEntity.Id, orderEntity.Created, orderEntity.LastUpdate, orderEntity.StatusTypeId, orderEntity.CustomerId));
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderEntity(int id)
        {
            var orderEntity = await _context.Orders.FindAsync(id);
            if (orderEntity == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orderEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderEntityExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
