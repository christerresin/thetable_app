using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTableApi.Models;

namespace TheTableApi.Services.AppetizerService
{
  public class AppetizerService : IAppetizerService
  {
            private static List<Appetizer> appetizers = new List<Appetizer>{
            new Appetizer{Id=0, Title="Bacon Strips with Honey"},
            new Appetizer{Id=1, Title="Cheese with crackers"}
        };
    public async Task<ServiceResponse<Appetizer>> AddNewAppetizer(Appetizer appetizer)
    {
        var serviceResponse = new ServiceResponse<Appetizer>{Data = appetizer};
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<Appetizer>>> GetAllAppetizers()
    {
        var serviceResponse = new ServiceResponse<List<Appetizer>>{Data = appetizers};
        return serviceResponse;
    }

    public async Task<ServiceResponse<Appetizer>> GetAppetizerById(int id)
    {
        var serviceResponse = new ServiceResponse<Appetizer>();
        var appetizer = appetizers.FirstOrDefault(appetizer => appetizer.Id == id);
        serviceResponse.Data = appetizer;
        return serviceResponse;
    }
  }
}