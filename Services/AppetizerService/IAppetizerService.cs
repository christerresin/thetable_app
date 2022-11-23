using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTableApi.Models;

namespace TheTableApi.Services.AppetizerService
{
    public interface IAppetizerService
    {
        Task<ServiceResponse<List<Appetizer>>> GetAllAppetizers();
        Task<ServiceResponse<Appetizer>> GetAppetizerById(int id);
        Task<ServiceResponse<Appetizer>> AddNewAppetizer(Appetizer appetizer);
    }
}