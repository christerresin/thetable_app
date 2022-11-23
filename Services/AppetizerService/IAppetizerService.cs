using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTableApi.Models;

namespace TheTableApi.Services.AppetizerService
{
    public interface IAppetizerService
    {
        List<Appetizer> GetAllAppetizers();
        Appetizer GetAppetizerById(int id);
        Appetizer AddNewAppetizer(Appetizer appetizer);
    }
}