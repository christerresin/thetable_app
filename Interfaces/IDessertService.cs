using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTableApi.Dtos.Meal;
using TheTableApi.Models;

namespace TheTableApi.Interfaces
{
  public interface IDessertService
  {
    Task<ServiceResponse<List<GetMealDto>>> GetAllDesserts();
    Task<ServiceResponse<GetMealDto>> GetDessertById(int id);
    Task<ServiceResponse<GetMealDto>> UpdateDessert(Meal updatedDessert);
    Task<ServiceResponse<GetMealDto>> DeleteDessert(int id);
  }
}