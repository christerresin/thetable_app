using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheTableApi.Data;
using TheTableApi.Dtos.Meal;
using TheTableApi.Interfaces;
using TheTableApi.Models;

namespace TheTableApi.Repositories
{
  public class MealRepository : IMealRepository
  {
    private readonly DataContext context;

    public MealRepository(DataContext context)
    {
      this.context = context;
    }

    public async Task<Meal> AddNewMeal(Meal newMainCourse)
    {
      context.Meals.Add(newMainCourse);
      await context.SaveChangesAsync();
      return newMainCourse;
    }

    public async Task<Meal> DeleteMeal(Meal deleteMeal)
    {
      context.Remove(deleteMeal);
      await context.SaveChangesAsync();
      return deleteMeal;
    }

    public async Task<List<Meal>> GetAllMeals(MealType mealType)
    {
      return await context.Meals.Where(meal => meal.Type == mealType).ToListAsync();
    }

    public async Task<Meal> GetMealById(int id)
    {
      return await context.Meals.FirstAsync(m => m.Id == id);
    }

    public async Task<Meal> UpdateMeal(Meal updatedMeal)
    {
      context.Update(updatedMeal);
      await context.SaveChangesAsync();
      return updatedMeal;
    }
  }
}