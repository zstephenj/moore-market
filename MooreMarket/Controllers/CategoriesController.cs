using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MooreMarket.Data;
using MooreMarket.Models;

namespace MooreMarket.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private MooreMarketContext _context;
        public CategoriesController(MooreMarketContext context)
        {
            _context = context;

        }
        
        //GET Categories/
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public IActionResult GetAllCategories()
        {
            IList<ProductCategory> allCategories = _context.Categories.ToList();

            if (allCategories.Count == 0)
            {
                return NoContent();
            }

            return Ok(allCategories);
        }

        //GET Categories/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetCategory(int id)
        {
            ProductCategory category = _context.Categories.Single(c => c.ID == id);

            if(category.Name == "")
            {
                return NotFound();
            }

            return Ok(category);
        }

        //POST Categories/Add
        [HttpPost("Add")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Add(ProductCategory category)
        {
            ProductCategory newCategory = new ProductCategory(category.Name);

            if (newCategory.Name == "")
            {
                return BadRequest(newCategory);
            }

            _context.Categories.Add(newCategory);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCategory), new { id = newCategory.ID }, newCategory);
        }

        //PUT Categories/{id}/Edit
        [HttpPut("{id}/Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Edit(int id, ProductCategory category)
        {
            ProductCategory newCategory = category;
            ProductCategory oldCategory = _context.Categories.SingleOrDefault(c => c.ID == id);

            if (oldCategory == null)
            {
                return NotFound();

            }
            
            if (newCategory.Name == "")
            {
                return BadRequest(newCategory);
            }

            
            oldCategory.Name = newCategory.Name;

            _context.SaveChanges();

            return RedirectToAction(nameof(GetCategory), new { id = id});
        }

        //DELETE Categories/{id}/Remove
        [HttpDelete("{id}/Remove")]
        public IActionResult Remove(int id)
        {
            ProductCategory category = _context.Categories.SingleOrDefault(c => c.ID == id);
            _context.Categories.Remove(category);

            _context.SaveChanges();

            return Ok();
        }
    }
}