using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<ServiceResponse<List<Appetizer>>>> GetAllAppetizers()
        {

            return Ok(await appetizerService.GetAllAppetizers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Appetizer>>> GetAppetizerById(int id)
        {
            return Ok(await appetizerService.GetAppetizerById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Appetizer>>> AddNewAppetizer(Appetizer appetizer)
        {
          return Ok(await appetizerService.AddNewAppetizer(appetizer));
        }


    }
}