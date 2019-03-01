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

    [HttpGet]
    public ActionResult<IList<UserModel>> GetAllFarmers()
    {
      return _context.Users
        .Where(u => u.AccountType == AccountType.Farmer)
        .ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<UserModel> GetFarmerProducts(int id)
    {
      var farmerProducts = _context.Users
        .Include(u => u.Products)
        .ThenInclude(p => p.Category)
        .SingleOrDefault(u => u.Id == id);

      if(farmerProducts == null)
      {
        return NotFound();
      }

      return farmerProducts;
    }
  }
}