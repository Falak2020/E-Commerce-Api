using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Api.Data;
using E_Commerce_Api.Data.Entities;
using E_Commerce_Api.Models.OrderModel;
using E_Commerce_Api.Models.UserModel;
using E_Commerce_Api.Models.OrderItemModel;

namespace E_Commerce_Api.Controllers
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
        public async Task<ActionResult<IEnumerable<GetOrderModel>>> GetOrderModel()
        {

            var orders = new List<GetOrderModel>();
            var OrderItemsCollection = new List<GetOrderItemModel>();

            foreach (var order in await _context.OrderModel.Include(x => x.User).Include(x => x.Adress).Include(x => x.DeliveryType).ToListAsync())
            {
                foreach (var item in await _context.OrderItemModel.Where(item => item.OrderId == order.Id).ToListAsync())
                { 
                  OrderItemsCollection.Add(new GetOrderItemModel
                   {
                    Id = item.Id,
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity   
                });

                }

               
                orders.Add(new GetOrderModel
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    OurReference = order.OurReference,
                    Status = order.Status,
                    DeliveryTypeName = order.DeliveryType.Name,
                    Address = new AddressModel
                    {
                        Id = order.Adress.Id,
                        AddressLine = order.Adress.AddressLine,
                        City = order.Adress.City,
                        ZipCode = order.Adress.ZipCode
                    },
                    User = new GetUserModel
                    {
                        Id = order.User.Id,
                        FirstName = order.User.FirstName,
                        LastName = order.User.LastName,
                        Email = order.User.Email,
                        AddressLine = order.User.Address.AddressLine,
                        City = order.User.Address.City,
                        ZipCode = order.User.Address.ZipCode

                    },

                    OrderItems = OrderItemsCollection

                });
            }
               

            return orders;

        }
           
      











        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetOneOrderModel>> GetOrderModel(int id)

        {
           
            
            var _order = await  _context.OrderModel.Include(x => x.User).Include(x => x.Adress).Include(x=> x.OrderItems.Where(item=>item.OrderId==id)).Include(x => x.DeliveryType).Where(x => x.Id == id).FirstOrDefaultAsync();

            if (_order == null)
            {
                return NotFound();
            }

            var orderItemsList = new List<GetOrderItemModel>();


            foreach( var item in _order.OrderItems)
            {
                orderItemsList.Add(new GetOrderItemModel
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity
                });
            }
            var order = new GetOneOrderModel
            {
                Id = _order.Id,
                OrderDate = _order.OrderDate,
                OurReference = _order.OurReference,
                Status = _order.Status,
                DeliveryTypeName = _order.DeliveryType.Name,
                Address = new AddressModel
                {
                    Id = _order.Adress.Id,
                    AddressLine = _order.Adress.AddressLine,
                    City = _order.Adress.City,
                    ZipCode = _order.Adress.ZipCode
                },
                User = new GetUserModel
                {
                    Id = _order.User.Id,
                    FirstName = _order.User.FirstName,
                    LastName = _order.User.LastName,
                    Email = _order.User.Email,
                    AddressLine = _order.User.Address.AddressLine,
                    City = _order.User.Address.City,
                    ZipCode = _order.User.Address.ZipCode

                },
                OrderItems = orderItemsList
                
          };
            return order;
        }








        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderModel(int id, OrderModel orderModel)
        {
            if (id != orderModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderModelExists(id))
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
        public async Task<ActionResult<OrderModel>> PostOrderModel(CreateOrderModel model)
        {
            var DeliveryName = await _context.DeliveryTypeModel.Where(x => x.Id == model.DeliveryTypeId).FirstOrDefaultAsync();
            var User = await _context.Users.Where(x => x.Id == model.UserId).FirstOrDefaultAsync();
            var _address = await _context.Users.Include(x=> x.Address).Where(x => x.Id == model.UserId).FirstOrDefaultAsync();


            var orderModel = new OrderModel
            {
                OrderDate = model.OrderDate,
                Status = model.Status,
                OurReference = model.OurReference,
                UserId = model.UserId,
                AdressId = model.DeliveryAddressId,
                DeliveryTypeId = model.DeliveryTypeId
            };


            _context.OrderModel.Add(orderModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderModel", new { id = orderModel.Id }, orderModel);
        }












        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderModel(int id)
        {
            var orderModel = await _context.OrderModel.FindAsync(id);
            if (orderModel == null)
            {
                return NotFound();
            }

            _context.OrderModel.Remove(orderModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderModelExists(int id)
        {
            return _context.OrderModel.Any(e => e.Id == id);
        }
    }
}
