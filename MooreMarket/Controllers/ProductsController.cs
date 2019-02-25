using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MooreMarket.Data;
using MooreMarket.Models;

namespace MooreMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private MooreMarketContext _context;
        public ProductsController(MooreMarketContext context)
        {
            _context = context;

        }
        
        //GET Products/
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public IActionResult GetAllProducts()
        {
            IList<Product> allProducts = _context.Products.Include(p => p.Category).ToList();


            
            if (allProducts.Count == 0)
            {
                return NoContent();
            }

            return Ok(allProducts);
        }

        //GET Products/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetProduct(int id)
        {
            Product product = _context.Products.SingleOrDefault(p => p.ID == id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        //POST Products/Add
        [HttpPost("Add")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Add(Product product)
        {
            ProductCategory ProductCategory = _context.Categories.SingleOrDefault(c => c.ID == product.CategoryID);
            product.Category = ProductCategory;              

            if (product.Name == null)
            {
                return NotFound();
            }

            if (product.Name == "")
            {
                return BadRequest(product);
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProduct), new { id = product.ID }, product);
        }

        //PUT Products/Edit/{id}
        [HttpPut("Edit/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Edit(int id, Product product)
        {
            product.ID = id;

            if (product.Name == "")
            {
                return BadRequest(product);
            }

            _context.Products.Update(product);

            _context.SaveChanges();

            return Ok(product);
        }

        //DELETE Products/Remove/{id}
        [HttpDelete("Remove/{id}")]
        public IActionResult Remove(int id)
        {
            Product product = _context.Products.SingleOrDefault(p => p.ID == id);

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}