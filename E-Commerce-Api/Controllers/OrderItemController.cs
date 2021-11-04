using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Api.Data;
using E_Commerce_Api.Data.Entities;
using E_Commerce_Api.Models.OrderItemModel;

namespace E_Commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly SqlContext _context;

        public OrderItemController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/OrderItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemModel>>> GetOrderItemModel()
        {
            return await _context.OrderItemModel.ToListAsync();
        }

        // GET: api/OrderItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemModel>> GetOrderItemModel(int id)
        {
            var orderItemModel = await _context.OrderItemModel.FindAsync(id);

            if (orderItemModel == null)
            {
                return NotFound();
            }

            return orderItemModel;
        }

        // PUT: api/OrderItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItemModel(int id, OrderItemModel orderItemModel)
        {
            if (id != orderItemModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderItemModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemModelExists(id))
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

        // POST: api/OrderItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderItemModel>> PostOrderItemModel(CreateOrderItemModel model)
        {
            var _product = await _context.Products.Where(x => x.Id == model.ProductId).FirstOrDefaultAsync();
            var orderItem = new OrderItemModel
            {
             ProductId = model.ProductId,
             OrderId = model.OrderId,
             Quantity = model.Quantity,
             UnitPrice = _product.Price
            };


            _context.OrderItemModel.Add(orderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderItemModel", new { id = orderItem.Id }, orderItem);
        }

        // DELETE: api/OrderItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItemModel(int id)
        {
            var orderItemModel = await _context.OrderItemModel.FindAsync(id);
            if (orderItemModel == null)
            {
                return NotFound();
            }

            _context.OrderItemModel.Remove(orderItemModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderItemModelExists(int id)
        {
            return _context.OrderItemModel.Any(e => e.Id == id);
        }
    }
}
