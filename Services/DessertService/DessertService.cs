using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TheTableApi.Dtos.Meal;
using TheTableApi.Interfaces;
using TheTableApi.Models;

namespace TheTableApi.Services.DessertService
{
  public class DessertService : IDessertService
  {
    private readonly IMealRepository mealRepository;
    private readonly IMapper mapper;
    private MealType mealType = MealType.Dessert;

    public DessertService(IMealRepository mealRepository, IMapper mapper)
    {
      this.mealRepository = mealRepository;
      this.mapper = mapper;
    }

    public Task<ServiceResponse<GetMealDto>> DeleteDessert(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<ServiceResponse<List<GetMealDto>>> GetAllDesserts()
    {
      var serviceResponse = new ServiceResponse<List<GetMealDto>>();
      List<Meal> dbDesserts = await mealRepository.GetAllMeals(mealType);
      serviceResponse.Data = dbDesserts.Select(dessert => mapper.Map<GetMealDto>(dessert)).ToList();
      return serviceResponse;
    }

    public Task<ServiceResponse<GetMealDto>> GetDessertById(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ServiceResponse<GetMealDto>> UpdateDessert(Meal updatedDessert)
    {
      throw new NotImplementedException();
    }
  }
}