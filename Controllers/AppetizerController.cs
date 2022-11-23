using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheTableApi.Models;

namespace TheTableApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppetizerController : ControllerBase
    {
        private static List<Appetizer> appetizers = new List<Appetizer>{
            new Appetizer{Id=0, Title="Bacon Strips with Honey"},
            new Appetizer{Id=1, Title="Cheese with crackers"}
        };

        [HttpGet]
        public ActionResult<List<Appetizer>> GetAllAppetizers()
        {
            return appetizers;
        }


    }
}