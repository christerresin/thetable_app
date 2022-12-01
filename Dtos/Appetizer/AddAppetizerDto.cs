using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTableApi.Models;

namespace TheTableApi.Dtos.Appetizer
{
  public class AddAppetizerDto
  {
    public string? Title { get; set; }
    public string Description { get; set; } = "No description added for this meal";
    public string? VideoUrl { get; set; } = null;
    public string? ImageUrl { get; set; } = null;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime LastEdited { get; set; } = DateTime.Now;
  }
}