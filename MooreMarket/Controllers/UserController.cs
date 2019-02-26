using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MooreMarket.Data;
using MooreMarket.Models;

namespace MooreMarket.Controllers
{
    [Route("[controller]/[action]")]
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