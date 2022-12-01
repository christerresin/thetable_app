using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTableApi.Models;

namespace TheTableApi.Dtos.Meal
{
  public class UpdateMealDto
  {
    public int Id { get; set; }
    public string? Title { get; set; }
    public string Description { get; set; } = "No description added for this meal";
    public string? VideoUrl { get; set; } = null;
    public string? ImageUrl { get; set; } = null;
    public MealType Type { get; set; } = MealType.Appetizer;
  }
}