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
    public async Task<Appetizer> AddNewAppetizer(Appetizer appetizer)
    {
        return appetizer;
    }

    public async Task<List<Appetizer>> GetAllAppetizers()
    {
        return appetizers;
    }

    public async Task<Appetizer> GetAppetizerById(int id)
    {
        return appetizers.FirstOrDefault(appetizer => appetizer.Id == id);
    }
  }
}