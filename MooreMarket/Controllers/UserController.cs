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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private MooreMarketContext _context;
        public UserController(MooreMarketContext context)
        {
            _context = context;           
        }
        public ActionResult<IEnumerable<UserModel>> Login()
        {
            return _context.Users.ToList();
        }

        public void Logout()
        {

        }
        //GET User/Products/{id}
        [HttpGet("Products/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetUserProducts(int id)
        {
            IList<Product> userProducts = _context.Products.Include(p => p.Category).Where(p => p.UserId == id).ToList();


            
            if (userProducts.Count == 0)
            {
                return NoContent();
            }

            return Ok(userProducts);
        }
        //POST users/create
        [HttpPost]
        public ActionResult<UserModel> Create(UserModel user)
        {
            var newUser = new UserModel(user.Username, user.Password);
            newUser.AccountType = user.AccountType;
            _context.Add(newUser);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Login), new { id = newUser.Id }, newUser);
        }
    }
}