using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTableApi.Controllers;
using TheTableApi.Interfaces;
using TheTableApi.Models;

namespace TheTableApi.Services.MainCourseService
{
  public class MainCourseService : IMainCourseService
  {
    private readonly IMealRepository mealRepository;

    public MainCourseService(IMealRepository mealRepository)
    {
      this.mealRepository = mealRepository;
    }
    public async Task<ServiceResponse<List<Meal>>> GetAllMainCourses()
    {
      var serviceResponse = new ServiceResponse<List<Meal>>();
      var dbMainCourses = await mealRepository.GetAllMeals();
      serviceResponse.Data = dbMainCourses;
      return serviceResponse;
    }

  }
}