using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheTableApi.Dtos.Appetizer;
using TheTableApi.Models;
using TheTableApi.Services.AppetizerService;

namespace TheTableApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AppetizerController : ControllerBase
  {
    private readonly IAppetizerService appetizerService;

    public AppetizerController(IAppetizerService appetizerService)
    {
      this.appetizerService = appetizerService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetAppetizerDto>>>> GetAllAppetizers()
    {

      return Ok(await appetizerService.GetAllAppetizers());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetAppetizerDto>>> GetAppetizerById(int id)
    {
      return Ok(await appetizerService.GetAppetizerById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetAppetizerDto>>> AddNewAppetizer(AddAppetizerDto newAppetizer)
    {
      return Ok(await appetizerService.AddNewAppetizer(newAppetizer));
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<GetAppetizerDto>>> UpdateAppetizer(UpdateAppetizerDto updatedAppetizer)
    {
      var serviceResponse = await appetizerService.UpdateAppetizer(updatedAppetizer);
      if (serviceResponse.Data == null)
      {
        return NotFound(serviceResponse);
      }
      return Ok(serviceResponse);
    }


  }
}