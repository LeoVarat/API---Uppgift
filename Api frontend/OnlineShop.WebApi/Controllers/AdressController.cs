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
    public class AdressController : ControllerBase
    {
        private readonly SqlContext _context;

        public AdressController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Adress
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdressModel>>> GetAdresses()
        {
            var items = new List<AdressModel>();
            foreach (var item in await _context.Adresses.ToListAsync())
                items.Add(new AdressModel(item.Id, item.Adress, item.PostalNumber, item.City));

            return items;
        }

        // GET: api/Adress/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdressEntity>> GetAdressEntity(int id)
        {
            var adressEntity = await _context.Adresses.FindAsync(id);

            if (adressEntity == null)
            {
                return NotFound();
            }

            return adressEntity;
        }

        // PUT: Has been removed. Due to same Adress ID can be used on multiple customers. Use Post instead of Put. /PLV



        // POST: api/Adress
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdressModel>> PostAdressEntity(AdressCreateModel model)
        {
            if(await _context.Adresses.AnyAsync(x => x.Adress == model.Adress))
                return Conflict();


            var adressEntity = new AdressEntity(model.Adress, model.PostalNumber, model.City);
            _context.Adresses.Add(adressEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdressEntity", new { id = adressEntity.Id }, new AdressModel(adressEntity.Id, adressEntity.Adress, adressEntity.PostalNumber, adressEntity.City));
        }

        // DELETE: api/Adress/5   
        // Have to be careful here, since an adress could be on several customers. If an adress needs to be removed (e.g. adress no longer exsist or no custumer uses the current adress)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdressEntity(int id)
        {
            var adressEntity = await _context.Adresses.FindAsync(id);
            if (adressEntity == null)
            {
                return NotFound();
            }

            _context.Adresses.Remove(adressEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdressEntityExists(int id)
        {
            return _context.Adresses.Any(e => e.Id == id);
        }
    }
}
