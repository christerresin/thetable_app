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

    public async Task<ServiceResponse<GetMealDto>> AddNewDessert(AddMealDto newDessert)
    {
      var serviceResponse = new ServiceResponse<GetMealDto>();
      Meal dessert = mapper.Map<Meal>(newDessert);
      await mealRepository.AddNewMeal(dessert);
      serviceResponse.Data = mapper.Map<GetMealDto>(dessert);
      return serviceResponse;
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

    public async Task<ServiceResponse<GetMealDto>> GetDessertById(int id)
    {
      var serviceResponse = new ServiceResponse<GetMealDto>();

      try
      {
        Meal foundDessert = await mealRepository.GetMealById(id);
        serviceResponse.Data = mapper.Map<GetMealDto>(foundDessert);
      }
      catch (Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }

      return serviceResponse;
    }

    public Task<ServiceResponse<GetMealDto>> UpdateDessert(UpdateMealDto updatedDessert)
    {
      throw new NotImplementedException();
    }
  }
}