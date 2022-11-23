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
        public ActionResult<List<Appetizer>> GetAllAppetizers()
        {
            return Ok(appetizerService.GetAllAppetizers());
        }

        [HttpGet("{id}")]
        public ActionResult<Appetizer> GetAppetizerById(int id)
        {
            return Ok(appetizerService.GetAppetizerById(id));
        }

        [HttpPost]
        public ActionResult<Appetizer> AddNewAppetizer(Appetizer appetizer)
        {
          return Ok(appetizerService.AddNewAppetizer(appetizer));
        }


    }
}