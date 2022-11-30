using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TheTableApi.Dtos.Appetizer;
using TheTableApi.Dtos.Meal;
using TheTableApi.Models;

namespace TheTableApi
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Appetizer, GetAppetizerDto>();
      CreateMap<AddAppetizerDto, Appetizer>();
      CreateMap<AddAppetizerDto, GetAppetizerDto>();
      CreateMap<Meal, GetMealDto>();
      CreateMap<AddMealDto, Meal>();
    }
  }
}