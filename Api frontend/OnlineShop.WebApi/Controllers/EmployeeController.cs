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
    public class EmployeeController : ControllerBase
    {
        private readonly SqlContext _context;

        public EmployeeController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployees()
        {
            var items = new List<EmployeeModel>();
            foreach (var item in await _context.Employees.ToListAsync())
                items.Add(new EmployeeModel(item.Id, item.FirstName, item.LastName, item.Email));

            return items;
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployeeEntity(int id)
        {
            var employeeEntity = await _context.Employees.FindAsync(id);

            if (employeeEntity == null)
            {
                return NotFound();
            }

            return new EmployeeModel(employeeEntity.Id, employeeEntity.FirstName, employeeEntity.LastName, employeeEntity.EmploymentNumber, employeeEntity.Email);
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeEntity(int id, EmployeeUpdateModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }


            var employeeEntity = await _context.Employees.FindAsync(model.Id);

            if (employeeEntity == null)
                return NotFound();
            employeeEntity.FirstName = model.FirstName;
            employeeEntity.LastName = model.LastName;
            employeeEntity.Email = model.Email;
            employeeEntity.Password = model.Password;

            _context.Entry(employeeEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeEntityExists(id))
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

        // POST: api/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> PostEmployeeEntity(EmployeeCreateModel model)
        {

            if (await _context.Employees.AnyAsync(x => x.EmploymentNumber == model.EmploymentNumber))
                return Conflict("An employee with the employmentnumber already exist");
            var employeeEntity = new EmployeeEntity(model.FirstName, model.LastName,model.EmploymentNumber, model.Email, model.Password);

            _context.Employees.Add(employeeEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeEntity", new { id = employeeEntity.Id }, new EmployeeModel(employeeEntity.Id , employeeEntity.FirstName, employeeEntity.LastName, employeeEntity.EmploymentNumber, employeeEntity.Email, employeeEntity.Password));
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeEntity(int id)
        {
            var employeeEntity = await _context.Employees.FindAsync(id);
            if (employeeEntity == null)
            {
                return NotFound();
            }

            employeeEntity.FirstName = "";
            employeeEntity.LastName = "";
            employeeEntity.Email = "";
            employeeEntity.Password = "";

            _context.Entry(employeeEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeEntityExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
