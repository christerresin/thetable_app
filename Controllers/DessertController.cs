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

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetMealDto>>> GetDessertById(int id)
    {
      var serviceResponse = await dessertService.GetDessertById(id);

      if (serviceResponse.Data == null)
      {
        return NotFound(serviceResponse);
      }

      return Ok(serviceResponse);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetMealDto>>> AddNewDessert(AddMealDto newDessert)
    {
      return Ok(await dessertService.AddNewDessert(newDessert));
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<GetMealDto>>> UpdateDessert(UpdateMealDto updatedDessert)
    {
      var serviceResponse = await dessertService.UpdateDessert(updatedDessert);

      if (serviceResponse.Data == null)
      {
        return NotFound(serviceResponse);
      }

      return Ok(serviceResponse);
    }

    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<GetMealDto>>> DeleteDessert(int id)
    {
      var serviceResponse = await dessertService.DeleteDessert(id);

      if (serviceResponse.Data == null)
      {
        return NotFound(serviceResponse);
      }
      return Ok(serviceResponse);
    }
  }
}