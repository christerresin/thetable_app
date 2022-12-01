using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheTableApi.Dtos.Meal;
using TheTableApi.Interfaces;
using TheTableApi.Models;

namespace TheTableApi.Controllers
{
  [ApiController]
  [Route("api/[Controller]")]
  public class DessertController : ControllerBase
  {
    private readonly IDessertService dessertService;

    public DessertController(IDessertService dessertService)
    {
      this.dessertService = dessertService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetMealDto>>>> GetDesserts()
    {
      return Ok(await dessertService.GetAllDesserts());
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetMealDto>>> AddNewDessert(AddMealDto newDessert)
    {
      return Ok(await dessertService.AddNewDessert(newDessert));
    }
  }
}