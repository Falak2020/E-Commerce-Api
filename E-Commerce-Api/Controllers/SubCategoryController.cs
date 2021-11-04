using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Api.Data;
using E_Commerce_Api.Data.Entities;
using E_Commerce_Api.Models.SubCategoryModel;
using Newtonsoft.Json;

namespace E_Commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly SqlContext _context;

        public SubCategoryController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/SubCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoryModel>>> GetSubCategories()
        {
            return await _context.SubCategories.ToListAsync();
        }

        // GET: api/SubCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoryModel>> GetSubCategoryModel(int id)
        {
            var subCategoryModel = await _context.SubCategories.FindAsync(id);

            if (subCategoryModel == null)
            {
                return NotFound();
            }

            return subCategoryModel;
        }

        // PUT: api/SubCategory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubCategoryModel(int id, SubCategoryModel subCategoryModel)
        {
            if (id != subCategoryModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(subCategoryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoryModelExists(id))
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

        // POST: api/SubCategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubCategoryModel>> PostSubCategoryModel(CreateSubCategoryModel model)
        {
            var _subCategory = await _context.SubCategories.Where(x => x.Name == model.Name).FirstOrDefaultAsync();

            var _category = await _context.Categories.Where(x => x.Id == model.CategoryId).FirstOrDefaultAsync();

            if (_subCategory == null)
            {
                if(_category != null)
                {
                   var subCategory = new SubCategoryModel
                    {
                        Name = model.Name,
                        CategoryId = model.CategoryId
                    };
                    _context.SubCategories.Add(subCategory);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetSubCategoryModel", new { id = subCategory.Id }, subCategory);
                }
                else
                    return new BadRequestObjectResult(JsonConvert.SerializeObject(new { message = "Please enter a valid category id" }));

            }

            else
                return new ConflictObjectResult(JsonConvert.SerializeObject(new { message = "The entered sub category is already existed" }));

    }

        // DELETE: api/SubCategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategoryModel(int id)
        {
            var subCategoryModel = await _context.SubCategories.FindAsync(id);
            if (subCategoryModel == null)
            {
                return NotFound();
            }

            _context.SubCategories.Remove(subCategoryModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubCategoryModelExists(int id)
        {
            return _context.SubCategories.Any(e => e.Id == id);
        }
    }
}
