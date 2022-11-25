using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheTableApi.Data;
using TheTableApi.Dtos.Appetizer;
using TheTableApi.Models;

namespace TheTableApi.Services.AppetizerService
{
  public class AppetizerService : IAppetizerService
  {
    private readonly IMapper mapper;
    private readonly DataContext context;

    public AppetizerService(IMapper mapper, DataContext context)
    {
      this.mapper = mapper;
      this.context = context;
    }
    private static List<Appetizer> appetizers = new List<Appetizer>{
            new Appetizer{Id=0, Title="Bacon Strips with Honey"},
            new Appetizer{Id=1, Title="Cheese with crackers"}
        };
    public async Task<ServiceResponse<GetAppetizerDto>> AddNewAppetizer(AddAppetizerDto newAppetizer)
    {
      Appetizer appetizer = mapper.Map<Appetizer>(newAppetizer);
      appetizer.Id = appetizers.Max(a => a.Id) + 1;
      appetizers.Add(appetizer);
      var serviceResponse = new ServiceResponse<GetAppetizerDto> { Data = mapper.Map<GetAppetizerDto>(newAppetizer) };
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetAppetizerDto>>> GetAllAppetizers()
    {
      var serviceResponse = new ServiceResponse<List<GetAppetizerDto>>();
      var dbAppetizers = await context.Appetizers.ToListAsync();
      serviceResponse.Data = dbAppetizers.Select(a => mapper.Map<GetAppetizerDto>(a)).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetAppetizerDto>> GetAppetizerById(int id)
    {
      var serviceResponse = new ServiceResponse<GetAppetizerDto>();
      var appetizer = appetizers.FirstOrDefault(appetizer => appetizer.Id == id);
      serviceResponse.Data = mapper.Map<GetAppetizerDto>(appetizer);
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetAppetizerDto>> UpdateAppetizer(UpdateAppetizerDto updatedAppetizer)
    {
      var serviceResponse = new ServiceResponse<GetAppetizerDto>();

      try
      {
        Appetizer appetizer = appetizers.FirstOrDefault(a => a.Id == updatedAppetizer.Id);

        appetizer.Title = updatedAppetizer.Title;
        appetizer.Description = updatedAppetizer.Description;
        appetizer.ImageUrl = updatedAppetizer.ImageUrl;
        appetizer.VideoUrl = updatedAppetizer.VideoUrl;
        appetizer.Type = updatedAppetizer.Type;
        appetizer.LastEdited = DateTime.Now;

        serviceResponse.Data = mapper.Map<GetAppetizerDto>(appetizer);

      }
      catch (Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
      return serviceResponse;

    }

    public async Task<ServiceResponse<GetAppetizerDto>> DeleteAppetizer(int id)
    {
      var serviceResponse = new ServiceResponse<GetAppetizerDto>();

      try
      {
        Appetizer appetizer = appetizers.FirstOrDefault(a => a.Id == id);
        appetizers.Remove(appetizer);

        serviceResponse.Data = mapper.Map<GetAppetizerDto>(appetizer);

      }
      catch (Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
      return serviceResponse;
    }
  }
}