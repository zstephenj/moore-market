using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MooreMarket.Data;
using MooreMarket.Models;

namespace MooreMarket.Controllers
{
    [Route("[controller]")]
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

            if(product.Name == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        //POST Products/Add
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Add(Product product)
        {
            Product newProduct = new Product(product.Name, product.Description, product.CategoryID, product.Quantity, product.Price, product.IsPerishable, product.KeepRoom, product.ShelfLifeRoom, product.KeepFridge, product.ShelfLifeFridge, product.KeepFreezer, product.ShelfLifeFreezer, product.Image);
            ProductCategory newProductCategory = _context.Categories.SingleOrDefault(c => c.ID == newProduct.CategoryID);
            newProduct.Category = newProductCategory;  

            if (newProduct.Name == null)
            {
                return NotFound();
            }

            if (newProduct.Name == "")
            {
                return BadRequest(newProduct);
            }

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.ID }, newProduct);
        }

        //PUT Products/{id}/Edit
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

            return RedirectToAction(nameof(GetProduct), new { id = id});
        }

        //DELETE Products/{id}/Remove
        [HttpDelete("Remove/{id}")]
        public IActionResult Remove(int id)
        {
            Product product = _context.Products.SingleOrDefault(p => p.ID == id);

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok();
        }
    }
}