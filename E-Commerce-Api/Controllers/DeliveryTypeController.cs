using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Api.Data;
using E_Commerce_Api.Data.Entities;
using E_Commerce_Api.Models.DeliveryTypeModel;

namespace E_Commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryTypeController : ControllerBase
    {
        private readonly SqlContext _context;

        public DeliveryTypeController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryTypeModel>>> GetDeliveryTypeModel()
        {
            return await _context.DeliveryTypeModel.ToListAsync();
        }

        // GET: api/DeliveryType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryTypeModel>> GetDeliveryTypeModel(int id)
        {
            var deliveryTypeModel = await _context.DeliveryTypeModel.FindAsync(id);

            if (deliveryTypeModel == null)
            {
                return NotFound();
            }

            return deliveryTypeModel;
        }

        // PUT: api/DeliveryType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryTypeModel(int id, DeliveryTypeModel deliveryTypeModel)
        {
            if (id != deliveryTypeModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(deliveryTypeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryTypeModelExists(id))
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




        // POST: api/DeliveryType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeliveryTypeModel>> PostDeliveryTypeModel(CreateDeliveryTypeModel model)
        {
            var deliveryType = new DeliveryTypeModel
            {
                Name = model.Name
            };
            _context.DeliveryTypeModel.Add(deliveryType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliveryTypeModel", new { id = deliveryType.Id }, deliveryType);
        }






        // DELETE: api/DeliveryType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryTypeModel(int id)
        {
            var deliveryTypeModel = await _context.DeliveryTypeModel.FindAsync(id);
            if (deliveryTypeModel == null)
            {
                return NotFound();
            }

            _context.DeliveryTypeModel.Remove(deliveryTypeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryTypeModelExists(int id)
        {
            return _context.DeliveryTypeModel.Any(e => e.Id == id);
        }
    }
}
