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
    public class ProductController : ControllerBase
    {
        private readonly SqlContext _context;

        public ProductController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProduct()
        { 
            var items = new List<ProductModel>();
            foreach (var item in await _context.Product.ToListAsync())
                items.Add(new ProductModel(item.Id, item.ProductNumber, item.Name, item.Description, item.Price, item.CategoryId));

            return items;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProductEntity(int id)
        {
            var productEntity = await _context.Product.FindAsync(id);

            if (productEntity == null)
            {
                return NotFound();
            }

            return new ProductModel(productEntity.Id, productEntity.ProductNumber, productEntity.Name, productEntity.Description, productEntity.Price, productEntity.CategoryId);
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductEntity(int id, ProductModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var productEntity = await _context.Product.FindAsync(model.Id);

            if(productEntity == null)
                return NotFound();
            productEntity.Name = model.Name;
            productEntity.Description = model.Description;
            productEntity.Price = model.Price;
            productEntity.CategoryId = model.CategoryId;

            _context.Entry(productEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductEntityExists(id))
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

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductEntity>> PostProductEntity(ProductCreateModel model)
        {
            if (await _context.Product.AnyAsync(x => x.ProductNumber == model.ProductNumber))
                return Conflict("A product with the same ProductNumber already exist");

            var productEntity = new ProductEntity(model.ProductNumber, model.Name, model.Description, model.Price, model.CategoryId);

            _context.Product.Add(productEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductEntity", new { id = productEntity.Id }, new ProductModel(productEntity.ProductNumber, productEntity.Name, productEntity.Description, productEntity.Price, productEntity.CategoryId));
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductEntity(int id)
        {
            var productEntity = await _context.Product.FindAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }

            _context.Product.Remove(productEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductEntityExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
