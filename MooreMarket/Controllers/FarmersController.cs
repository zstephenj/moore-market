using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MooreMarket.Data;
using MooreMarket.Models;

namespace MooreMarket.Controllers
{
  [Route("/api/[controller]")]
  [ApiController]
  public class FarmersController : ControllerBase
  {
    private readonly MooreMarketContext _context;

    public FarmersController(MooreMarketContext context)
    {
      _context = context;
    }

    [HttpGet("farmers")]
    public ActionResult<IList<UserModel>> GetAllFarmers()
    {
      return _context.Users
        .Include(u => u.Products)
        .Where(u => u.AccountType == AccountType.Farmer)
        .ToList();
    }

    [HttpGet("farmers/{id}")]
    public ActionResult<IList<Product>> GetFarmerProducts(int id)
    {
      var farmerProducts = _context.Products.Where(u => u.ID == id).ToList();
      if(farmerProducts == null)
      {
        return NoContent();
      }

      return farmerProducts;
    }
  }
}