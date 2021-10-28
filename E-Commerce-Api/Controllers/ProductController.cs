using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Api.Data;
using E_Commerce_Api.Data.Entities;
using E_Commerce_Api.Models.ProductModel;

namespace E_Commerce_Api.Controllers
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
        public async Task<ActionResult<IEnumerable<GetProductsModel>>> GetProducts()
        {
            var products = new List<GetProductsModel>();

        
            foreach (var product in await _context.Products.Include(x => x.SubCategory).ToListAsync())
                products.Add(new GetProductsModel
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    ImageURL = product.ImageURL,
                    InStock = product.InStock,
                    SubCategoryName = product.SubCategory.Name
                });

            return products;
        }






        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductsModel>> GetProductModel(int id)
        {
            
            var product = await _context.Products.Include(x => x.SubCategory).Where(x => x.Id == id).FirstOrDefaultAsync(); 


            if (product == null)
            {
                return NotFound();
            }

            return new GetProductsModel
            {
                Name = product.Name,
                Description = product.Description,
                Price= product.Price,
                ImageURL = product.ImageURL,
                InStock = product.InStock,
                SubCategoryName = product.SubCategory.Name
            };
        }








        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductModel(int id, ProductModel productModel)
        {
            if (id != productModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(productModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(id))
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
        public async Task<ActionResult<ProductModel>> PostProductModel(CreateProductModel model)
        {


            var subcategory = await _context.SubCategories.Where(x => x.Id == model.SubCategoryId).FirstOrDefaultAsync();

            if (subcategory != null)
            {
                var product = new ProductModel
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    ImageURL = model.ImageURL,
                    InStock = model.InStock,
                    SubCategoryId = model.SubCategoryId
                };


                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProductModel", new { id = product.Id }, product);

            }
            else
                return new BadRequestResult();
        
        }







        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductModel(int id)
        {
            var productModel = await _context.Products.FindAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }

            _context.Products.Remove(productModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductModelExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
