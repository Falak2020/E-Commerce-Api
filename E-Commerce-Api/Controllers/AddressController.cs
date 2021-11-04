using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Api.Data;
using E_Commerce_Api.Data.Entities;
using E_Commerce_Api.Models.AddressModel;

namespace E_Commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly SqlContext _context;

        public AddressController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Address
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAddressModel>>> GetAddresses()
        {
            var addresses = new List<GetAddressModel>();
            foreach(var address in await _context.Addresses.ToListAsync())
            {
                addresses.Add(new GetAddressModel
                {
                 Id= address.Id,
                 AddressLine = address.AddressLine,
                 City = address.City, 
                 ZipCode = address.ZipCode
                });
            }

            return addresses;
        }

        // GET: api/Address/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressModel>> GetAddressModel(int id)
        {
            var addressModel = await _context.Addresses.FindAsync(id);

            if (addressModel == null)
            {
                return NotFound();
            }

            return addressModel;
        }

        // PUT: api/Address/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddressModel(int id, AddressModel addressModel)
        {
            if (id != addressModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(addressModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressModelExists(id))
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

        // POST: api/Address
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddressModel>> PostAddressModel(AddressModel addressModel)
        {
            _context.Addresses.Add(addressModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddressModel", new { id = addressModel.Id }, addressModel);
        }

        // DELETE: api/Address/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressModel(int id)
        {
            var addressModel = await _context.Addresses.FindAsync(id);
            if (addressModel == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(addressModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressModelExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}
