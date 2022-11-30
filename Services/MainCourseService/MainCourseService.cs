using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheTableApi.Controllers;
using TheTableApi.Dtos.Meal;
using TheTableApi.Interfaces;
using TheTableApi.Models;

namespace TheTableApi.Services.MainCourseService
{
  public class MainCourseService : IMainCourseService
  {
    private readonly IMapper mapper;
    private readonly IMealRepository mealRepository;

    public MainCourseService(IMapper mapper, IMealRepository mealRepository)
    {
      this.mapper = mapper;
      this.mealRepository = mealRepository;
    }

    public async Task<ServiceResponse<GetMealDto>> AddNewMainCourse(AddMealDto newMainCourse)
    {
      var serviceResponse = new ServiceResponse<GetMealDto>();
      Meal mainCourse = mapper.Map<Meal>(newMainCourse);
      await mealRepository.AddNewMeal(mainCourse);
      if (mainCourse.Id == 0)
      {
        serviceResponse.Data = null;
        serviceResponse.Message = "Error saving to DB";
        serviceResponse.Success = false;
        return serviceResponse;
      }
      serviceResponse.Data = mapper.Map<GetMealDto>(mainCourse);
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<Meal>>> GetAllMainCourses()
    {
      var serviceResponse = new ServiceResponse<List<Meal>>();
      var dbMainCourses = await mealRepository.GetAllMeals();
      serviceResponse.Data = dbMainCourses;
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetMealDto>> getMainCourseById(int id)
    {
      var serviceResponse = new ServiceResponse<GetMealDto>();

      try
      {
        Meal meal = await mealRepository.GetMealById(id);
        serviceResponse.Data = mapper.Map<GetMealDto>(meal);

      }
      catch (Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
      return serviceResponse;

    }

    public async Task<ServiceResponse<GetMealDto>> UpdateMainCourse(UpdateMealDto updatedMainCourse)
    {
      var serviceResponse = new ServiceResponse<GetMealDto>();

      try
      {
        Meal meal = await mealRepository.GetMealById(updatedMainCourse.Id);

        meal.Title = updatedMainCourse.Title;
        meal.Description = updatedMainCourse.Description;
        meal.ImageUrl = updatedMainCourse.ImageUrl;
        meal.VideoUrl = updatedMainCourse.VideoUrl;
        meal.LastEdited = DateTime.Now;

        await mealRepository.UpdateMeal(meal);

        serviceResponse.Data = mapper.Map<GetMealDto>(meal);

      }
      catch (Exception ex)
      {
        serviceResponse.Message = ex.Message;
        serviceResponse.Success = false;
      }

      return serviceResponse;
    }
  }
}