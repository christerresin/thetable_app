using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTableApi.Dtos.Appetizer;
using TheTableApi.Models;

namespace TheTableApi.Services.AppetizerService
{
  public interface IAppetizerService
  {
    Task<ServiceResponse<List<GetAppetizerDto>>> GetAllAppetizers();
    Task<ServiceResponse<GetAppetizerDto>> GetAppetizerById(int id);
    Task<ServiceResponse<GetAppetizerDto>> AddNewAppetizer(AddAppetizerDto appetizer);

    Task<ServiceResponse<GetAppetizerDto>> UpdateAppetizer(UpdateAppetizerDto updatedAppetizer);
  }
}