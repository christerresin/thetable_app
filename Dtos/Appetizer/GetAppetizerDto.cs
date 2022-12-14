using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTableApi.Models;

namespace TheTableApi.Dtos.Appetizer
{
  public class GetAppetizerDto
  {
    public int Id { get; set; }
    public string? Title { get; set; }
    public string Description { get; set; } = "No description added for this meal";
    public string? VideoUrl { get; set; } = null;
    public string? ImageUrl { get; set; } = null;
    public MealType Type { get; set; } = MealType.Appetizer;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime LastEdited { get; set; } = DateTime.Now;
  }
}