using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheTableApi.Models;
using TheTableApi.Dtos.Meal;

namespace TheTableApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MainCourseController : ControllerBase
  {
    private readonly IMainCourseService mainCourseService;

    public MainCourseController(IMainCourseService mainCourseService)
    {
      this.mainCourseService = mainCourseService;
    }
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Meal>>>> GetAllMainCourses()
    {
      return Ok(await mainCourseService.GetAllMainCourses());
    }

    [HttpGet("/{id}")]
    public async Task<ActionResult<ServiceResponse<GetMealDto>>> GetMainCourseById(int id)
    {

      var serviceResponse = await mainCourseService.getMainCourseById(id);
      if (serviceResponse.Data == null)
      {
        return NotFound(serviceResponse);
      }
      return Ok(serviceResponse);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetMealDto>>> AddNewMainCourse(AddMealDto newMainCourse)
    {
      var serviceResponse = await mainCourseService.AddNewMainCourse(newMainCourse);
      if (serviceResponse.Data == null)
      {
        return NotFound(serviceResponse);
      }
      return Ok(serviceResponse);
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<GetMealDto>>> UpdateMainCourse(UpdateMealDto updatedMainCourse)
    {
      return Ok(await mainCourseService.UpdateMainCourse(updatedMainCourse));
    }
  }
}