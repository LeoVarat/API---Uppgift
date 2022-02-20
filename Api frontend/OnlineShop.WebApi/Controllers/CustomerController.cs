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
    public class CustomerController : ControllerBase
    {
        private readonly SqlContext _context;

        public CustomerController(SqlContext context)
        {
            _context = context;
        }



        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomers()
        {
            var items = new List<CustomerModel>();
            foreach (var item in await _context.Customers.ToListAsync())
                items.Add(new CustomerModel(item.Id, item.FirstName, item.LastName, item.Email));

            return items;
        }



        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>> GetCustomerEntity(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);

            if (customerEntity == null)
            {
                return NotFound();
            }

            return new CustomerModel(customerEntity.Id, customerEntity.FirstName, customerEntity.LastName, customerEntity.Email, customerEntity.AdressId);
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerEntity(int id, CustomerUpdateModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var customerEntity = await _context.Customers.FindAsync(model.Id);

            if (customerEntity == null)
                return NotFound();

            customerEntity.FirstName = model.FirstName;
            customerEntity.LastName = model.LastName;
            customerEntity.Email = model.Email;
            customerEntity.AdressId = model.AdressId;



            _context.Entry(customerEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (customerEntity == null)
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




        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerModel>> PostCustomerEntity(CustomerCreateModel model)
        {
            if (await _context.Customers.AnyAsync(x => x.Email == model.Email))
                return Conflict("The email adress you are trying to use already exist");

            var customerEntity = new CustomerEntity(model.FirstName, model.LastName, model.Email, model.AdressId);

            _context.Customers.Add(customerEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerEntity", new { id = customerEntity.Id }, new CustomerModel(customerEntity.Id, customerEntity.FirstName, customerEntity.LastName, customerEntity.Email, customerEntity.AdressId));
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerEntity(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity == null)
            {
                return NotFound();
            }

            customerEntity.FirstName = "";
            customerEntity.LastName = "";
            customerEntity.Email = "";
            customerEntity.AdressId = 0;

            _context.Entry(customerEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
