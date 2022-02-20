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
    public class StatusTypeController : ControllerBase
    {
        private readonly SqlContext _context;

        public StatusTypeController(SqlContext context)
        {
            _context = context;
        }




        // GET: api/StatusType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusTypeModel>>> GetStatusTypes()
        {
            var items = new List<StatusTypeModel>();
            foreach (var item in await _context.StatusTypes.ToListAsync())
                items.Add(new StatusTypeModel(item.Id, item.Name));

            return items;
        }

        // GET: api/StatusType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusTypeModel>> GetStatusTypeEntity(int id)
        {
            var statusTypeEntity = await _context.StatusTypes.FindAsync(id);

            if (statusTypeEntity == null)
            {
                return NotFound();
            }

            return new StatusTypeModel(statusTypeEntity.Id, statusTypeEntity.Name);
        }

        // PUT: api/StatusType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusTypeEntity(int id, StatusTypeUpdateModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var statusTypeEntity = await _context.StatusTypes.FindAsync(model.Id);

            if (statusTypeEntity == null)
                return NotFound();

            statusTypeEntity.Name = model.Name;

            _context.Entry(statusTypeEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (statusTypeEntity == null)
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

        // POST: api/StatusType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusTypeModel>> PostStatusTypeEntity(StatusTypeCreateModel model)
        {
            if (await _context.StatusTypes.AnyAsync(x => x.Name == model.Name))
                return Conflict("The status type you are trying to create already exist");

            var statusTypeEntity = new StatusTypeEntity(model.Name);

            _context.StatusTypes.Add(statusTypeEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusTypeEntity", new { id = statusTypeEntity.Id }, new StatusTypeModel(statusTypeEntity.Name));
        }







        // DELETE: api/StatusType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusTypeEntity(int id)
        {
            var statusTypeEntity = await _context.StatusTypes.FindAsync(id);
            if (statusTypeEntity == null)
            {
                return NotFound();
            }
            statusTypeEntity.Name = "";

            _context.Entry(statusTypeEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
