using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MooreMarket.Data;
using MooreMarket.Models;

namespace MooreMarket.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MarketsController : ControllerBase
    {
        private MooreMarketContext _context;
        public MarketsController(MooreMarketContext context)
        {
            _context = context;

        }
        
        //GET api/Markets/
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public IActionResult GetAllMarkets()
        {
            IList<Market> allMarkets = _context.Markets.ToList();

            if (allMarkets.Count == 0)
            {
                return NoContent();
            }

            return Ok(allMarkets);
        }

        //GET api/Markets/{id}
        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetMarket(int id)
        {
            Market market = _context.Markets.Single(m => m.Id == id);

            if(market.Name == "")
            {
                return NotFound();
            }

            return Ok(market);
        }

        //POST api/Markets/Add
        [HttpPost("Add")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Add(Market market)
        {
            //Validate category data
            if (market.Name == "")
            {
                return BadRequest(market);
            }

            _context.Markets.Add(market);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMarket), new { id = market.Id }, market);
        }

        //PUT api/Markets/Edit/{id}
        [HttpPut("Edit/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Edit(int id, Market market)
        {
            Market oldMarket = _context.Markets.SingleOrDefault(m => m.Id == id);

            if (oldMarket == null)
            {
                return NotFound();

            }

            if (market.Name == "")
            {
                return BadRequest(market);
            }

            
            oldMarket.Name = market.Name;

            _context.SaveChanges();

            return Ok(market);
        }

        //DELETE api/Markets/Remove/{id}
        [HttpDelete("Remove/{id}")]
        public IActionResult Remove(int id)
        {
            Market market = _context.Markets.SingleOrDefault(m => m.Id == id);
            _context.Markets.Remove(market);

            _context.SaveChanges();

            return Ok();
        }

        //POST api/Markets/{marketId}/Vendors
        [HttpPost("{marketId}/Vendors")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult AddVendor(int marketId, int vendorId)
        {
            IList<VendorMarket> existingItems = _context.VendorMarkets
              .Where(cm => cm.MarketId == marketId)
              .Where(cm => cm.VendorId == vendorId)
              .ToList();
            if (existingItems.Count == 0)
            {
                Market market = _context.Markets.SingleOrDefault(m => m.Id == marketId);
                UserModel vendor = _context.Users.SingleOrDefault(u => u.Id == vendorId);
                VendorMarket vendorMarket = new VendorMarket {
                    MarketId = marketId,
                    Market = market,
                    VendorId = vendorId,
                    Vendor = vendor
                };
                
                
                _context.VendorMarkets.Add(vendorMarket);
                _context.SaveChanges();

                return Ok(vendorMarket);
            }
            return BadRequest();
        }

        //DELETE api/Markets/{marketId}/Vendors
        [HttpDelete("{marketId}/Vendors")]
        public IActionResult RemoveVendor(int marketId, int vendorId)
        {
            Market market = _context.Markets.SingleOrDefault(m => m.Id == marketId);
            UserModel vendor = _context.Users.SingleOrDefault(u => u.Id == vendorId);
            VendorMarket vendorMarket = new VendorMarket {
                MarketId = marketId,
                Market = market,
                VendorId = vendorId,
                Vendor = vendor
            };
            
            market.VendorMarkets.Remove(vendorMarket);
            _context.SaveChanges();

            return Ok();
        }
    }
}