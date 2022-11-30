using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheTableApi.Data;
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
    public async Task<List<Meal>> GetAllMeals()
    {
      return await context.Meals.ToListAsync();
    }
  }
}