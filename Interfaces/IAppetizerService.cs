using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTableApi.Dtos.Appetizer;
using TheTableApi.Dtos.Meal;
using TheTableApi.Models;

namespace TheTableApi.Services.AppetizerService
{
  public interface IAppetizerService
  {
    Task<ServiceResponse<List<GetMealDto>>> GetAllAppetizers();
    Task<ServiceResponse<GetMealDto>> GetAppetizerById(int id);
    Task<ServiceResponse<GetMealDto>> AddNewAppetizer(AddMealDto appetizer);
    Task<ServiceResponse<GetMealDto>> UpdateAppetizer(UpdateMealDto updatedAppetizer);
    Task<ServiceResponse<GetMealDto>> DeleteAppetizer(int id);
  }
}