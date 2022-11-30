using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTableApi.Models;

namespace TheTableApi.Interfaces
{
  public interface IMealRepository
  {
    public Task<List<Meal>> GetAllMeals();
  }
}