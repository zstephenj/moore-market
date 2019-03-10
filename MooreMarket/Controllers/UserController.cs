using System;
using Microsoft.AspNetCore.Mvc;
using MooreMarket.Models;
using AutoMapper;
using MooreMarket.Helpers;
using MooreMarket.Services;
using Microsoft.Extensions.Options;
using MooreMarket.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using MooreMarket.Data;
using System.Linq;
using System.Collections.Generic;

namespace MooreMarket.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private MooreMarketContext _context;
        public UserController(IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings, MooreMarketContext context)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody]UserDto userDto)
        {
          var user = _userService.Authenticate(userDto.Username, userDto.Password);

          if(user == null)
          {
            return BadRequest( new { message = "Username or password is incorrect" });
          }

          var tokenHandler = new JwtSecurityTokenHandler();
          var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
          var tokenDescriptor = new SecurityTokenDescriptor
          {
            Subject = new ClaimsIdentity(new Claim[] 
            {
              new Claim(ClaimTypes.Name, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
          };

          var token = tokenHandler.CreateToken(tokenDescriptor);
          var tokenString = tokenHandler.WriteToken(token);

          return Ok(new {
            Id = user.Id,
            Username = user.Username,
            AccountType = user.AccountType,
            Token = tokenString
          });
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody]UserDto userDto)
        {
          var user = _mapper.Map<UserModel>(userDto);

          try
          {
            _userService.Create(user, userDto.Password);
            return Ok(user);
          }
          catch(AppException ex)
          {
            return BadRequest(new { message = ex.Message });
          }
        }

        //POST api/User/Location/{id}
        [HttpPost("Location")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult SetUserLocation(int id, UserModel userLocation)
        {
            UserModel user = _context.Users.SingleOrDefault(u => u.Id == userLocation.Id);
            user.Lat = userLocation.Lat;
            user.Lng = userLocation.Lng;
            

            _context.SaveChanges();

            return Ok(userLocation);
        }
        
        //POST api/User/Favorites/Market/{userId}
        [HttpPost("Favorites/Market/{userId}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult AddFavoriteMarket(int userId, int marketId)
        {
            IList<UserMarket> existingItems = _context.UserMarkets
              .Where(cm => cm.UserId == userId)
              .Where(cm => cm.MarketId == marketId)
              .ToList();
            if (existingItems.Count == 0)
            {
              UserModel user = _context.Users.SingleOrDefault(u => u.Id == userId);
              Market market = _context.Markets.SingleOrDefault(m => m.Id == marketId);
              UserMarket userMarket = new UserMarket {
                MarketId = marketId,
                Market = market,
                UserId = userId,
                User = user
              };
              _context.UserMarkets.Add(userMarket);
              _context.SaveChanges();
              return Ok(userMarket);
            }

            return BadRequest();
            
        }

        //DELETE api/User/Favorites/Market/{userId}
        [HttpDelete("Favorites/Market/{userId}")]
        public IActionResult RemoveFavoriteMarket(int userId, int marketId)
        {
            UserModel user = _context.Users.SingleOrDefault(u => u.Id == userId);
            Market market = _context.Markets.SingleOrDefault(m => m.Id == marketId);
            UserMarket userMarket = new UserMarket {
              MarketId = marketId,
              Market = market,
              UserId = userId,
              User = user
            };

            user.UserMarkets.Remove(userMarket);
            _context.SaveChanges();

            return Ok();
        }
    }
}