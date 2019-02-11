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
        [HttpGet("")]
        [HttpGet("/")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public IActionResult GetAllProducts()
        {
            IList<Product> allProducts = _context.Products.Include(p => p.Category).ToList();
            /* Test API Products
            if (_context.Products.Count() == 0)
            {
                ProductCategory TestCat1 = new ProductCategory("TestCategory1");
                TestCat1.ID = 1;
                ProductCategory TestCat2 = new ProductCategory("TestCategory2");
                TestCat2.ID = 2;
                _context.Categories.Add(TestCat1);
                _context.Categories.Add(TestCat2);
                _context.SaveChanges();
                Product TestProduct1 = new Product("TestProduct1N", "TestProduct1D", 1, 8, 88, 0, 0, "", 0, "", 0, "", "img1data");
                TestProduct1.CategoryID = 1;
                TestProduct1.Category = TestCat1;
                Product TestProduct2 = new Product("TestProduct2N", "TestProduct2D", 2, 6, 66, 1, 1, "11", 1, "11", 1, "11", "img2data");
                TestProduct2.CategoryID = 2;
                TestProduct2.Category = TestCat2;
                _context.Products.Add(TestProduct1);
                _context.Products.Add(TestProduct2);
                _context.SaveChanges();
            }
            */
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
            Product product = _context.Products.Single(p => p.ID == id);

            if(product.Name == "")
            {
                return NotFound();
            }

            return Ok(product);
        }
        //POST Products/Add
        
        [HttpPost("Add")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Add(Product product)
        {
            Product newProduct = new Product(product.Name, product.Description, product.CategoryID, product.Quantity, product.Price, product.IsPerishable, product.KeepRoom, product.ShelfLifeRoom, product.KeepFridge, product.ShelfLifeFridge, product.KeepFreezer, product.ShelfLifeFreezer, product.Image);
            ProductCategory newProductCategory = _context.Categories.Single(c => c.ID == newProduct.CategoryID);
            newProduct.Category = newProductCategory;   

            if (newProduct.Name == "")
            {
                return BadRequest(newProduct);
            }

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.ID }, newProduct);
        }

        //PUT Products/{id}/Edit
        [HttpPut("{id}/Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Edit(int id, Product product)
        {
            Product newProduct = product;
            newProduct.ID = id;

            if (newProduct.ID == null)
            {
                return BadRequest();
            }

            _context.Products.Update(newProduct);

            _context.SaveChanges();

            return RedirectToAction(nameof(GetProduct), new { id = id});
        }
        
        //DELETE Products/{id}/Remove
        [HttpDelete("{id}/Remove")]
        public IActionResult Remove(int id)
        {
            Product product = _context.Products.Single(p => p.ID == id);

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok();
        }
    }
}