using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheTableApi.Data;
using TheTableApi.Dtos.Appetizer;
using TheTableApi.Dtos.Meal;
using TheTableApi.Interfaces;
using TheTableApi.Models;
using TheTableApi.Repositories;

namespace TheTableApi.Services.AppetizerService
{
  public class AppetizerService : IAppetizerService
  {
    private readonly IMapper mapper;
    private readonly DataContext context;
    private readonly IAppetizerRepository appetizerRepository;
    private readonly IMealRepository mealRepository;
    private MealType mealType = MealType.Appetizer;

    public AppetizerService(IMapper mapper, DataContext context, IAppetizerRepository appetizerRepository, IMealRepository mealRepository)
    {
      this.mapper = mapper;
      this.context = context;
      this.appetizerRepository = appetizerRepository;
      this.mealRepository = mealRepository;
    }
    public async Task<ServiceResponse<GetMealDto>> AddNewAppetizer(AddMealDto newAppetizer)
    {
      var serviceResponse = new ServiceResponse<GetMealDto>();
      Meal appetizer = mapper.Map<Meal>(newAppetizer);
      await mealRepository.AddNewMeal(appetizer);

      serviceResponse.Data = mapper.Map<GetMealDto>(appetizer);
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetMealDto>>> GetAllAppetizers()
    {
      var serviceResponse = new ServiceResponse<List<GetMealDto>>();
      var dbAppetizers = await mealRepository.GetAllMeals(mealType);
      serviceResponse.Data = dbAppetizers.Select(a => mapper.Map<GetMealDto>(a)).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetMealDto>> GetAppetizerById(int id)
    {
      var serviceResponse = new ServiceResponse<GetMealDto>();
      Meal appetizer = await mealRepository.GetMealById(id);
      serviceResponse.Data = mapper.Map<GetMealDto>(appetizer);
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetMealDto>> UpdateAppetizer(UpdateMealDto updatedAppetizer)
    {
      var serviceResponse = new ServiceResponse<GetMealDto>();

      try
      {
        // REFACTOR THIS LOGIC
        Meal appetizer = await mealRepository.UpdateMeal(mapper.Map<Meal>(updatedAppetizer));

        appetizer.Title = updatedAppetizer.Title;
        appetizer.Description = updatedAppetizer.Description;
        appetizer.ImageUrl = updatedAppetizer.ImageUrl;
        appetizer.VideoUrl = updatedAppetizer.VideoUrl;
        appetizer.Type = updatedAppetizer.Type;
        appetizer.LastEdited = DateTime.Now;


        serviceResponse.Data = mapper.Map<GetMealDto>(appetizer);

      }
      catch (Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
      return serviceResponse;

    }

    public async Task<ServiceResponse<GetMealDto>> DeleteAppetizer(int id)
    {
      var serviceResponse = new ServiceResponse<GetMealDto>();

      try
      {
        Meal appetizerToDelete = new Meal() { Id = id };
        await mealRepository.DeleteMeal(appetizerToDelete);
        // Appetizer appetizer = await context.Appetizers.FirstAsync(a => a.Id == id);
        // context.Appetizers.Remove(appetizer);
        // await context.SaveChangesAsync();

        serviceResponse.Data = mapper.Map<GetMealDto>(appetizerToDelete);

      }
      catch (Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
      return serviceResponse;
    }
  }
}