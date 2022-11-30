using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTableApi.Dtos.Meal;
using TheTableApi.Models;

namespace TheTableApi.Interfaces
{
  public interface IMealRepository
  {
    Task<Meal> AddNewMeal(Meal newMainCourse);
    Task<List<Meal>> GetAllMeals(MealType mealType);

    Task<Meal> GetMealById(int id);

    Task<Meal> UpdateMeal(Meal updatedMeal);
  }
}