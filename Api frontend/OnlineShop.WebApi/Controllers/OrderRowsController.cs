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
    public class OrderRowsController : ControllerBase
    {
        private readonly SqlContext _context;

        public OrderRowsController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/OrderRows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderRowModel>>> GetOrderRows()
        {
            var items = new List<OrderRowModel>();
            foreach (var item in await _context.OrderRows.ToListAsync())
                items.Add(new OrderRowModel(item.Id, item.RowAdded, item.OrderId, item.ProductId, item.Ammount, item.Price ));

            return items;
        }

        // GET: api/OrderRows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderRowModel>> GetOrderRowsEntity(int id)
        {
            var orderRowsEntity = await _context.OrderRows.FindAsync(id);

            if (orderRowsEntity == null)
            {
                return NotFound();
            }

            return new OrderRowModel( orderRowsEntity.Id, orderRowsEntity.RowAdded, orderRowsEntity.OrderId, orderRowsEntity.ProductId, orderRowsEntity.Ammount, orderRowsEntity.Price);
        }

        // PUT: api/OrderRows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderRowsEntity(int id, OrderRowUppdateModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }


            var orderRowsEntity = await _context.OrderRows.FindAsync(model.Id);
            if (orderRowsEntity == null)
                return NotFound();

            orderRowsEntity.Ammount = model.Ammount;
            orderRowsEntity.Price = model.Price;

            _context.Entry(orderRowsEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (orderRowsEntity == null)
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

        // POST: api/OrderRows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderRowModel>> PostOrderRowsEntity(OrderRowCreateModel model)
        {
            var orderRowsEntity = new OrderRowsEntity(model.OrderId, model.ProductId, model.Ammount, model.Price);

            _context.OrderRows.Add(orderRowsEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderRowsEntity", new { id = orderRowsEntity.Id }, new OrderRowModel(orderRowsEntity.RowAdded, orderRowsEntity.OrderId,  orderRowsEntity.ProductId, orderRowsEntity.Ammount,  orderRowsEntity.Price));
        }

        // DELETE: api/OrderRows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderRowsEntity(int id)
        {
            var orderRowsEntity = await _context.OrderRows.FindAsync(id);
            if (orderRowsEntity == null)
            {
                return NotFound();
            }

            _context.OrderRows.Remove(orderRowsEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderRowsEntityExists(int id)
        {
            return _context.OrderRows.Any(e => e.Id == id);
        }
    }
}
