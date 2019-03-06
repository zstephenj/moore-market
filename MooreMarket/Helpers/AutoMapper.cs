using AutoMapper;
using MooreMarket.Dtos;
using MooreMarket.Models;

namespace MooreMarket.Helpers
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile ()
    {
      CreateMap<UserDto, UserModel>();
      CreateMap<UserModel, UserDto>();
    }
  }
}