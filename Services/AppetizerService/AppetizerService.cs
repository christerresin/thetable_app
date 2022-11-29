using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheTableApi.Data;
using TheTableApi.Dtos.Appetizer;
using TheTableApi.Interfaces;
using TheTableApi.Models;
using TheTableApi.Repositories;

namespace TheTableApi.Services.AppetizerService
{
  public class AppetizerService : IAppetizerService
  {
    private readonly IMapper mapper;
    private readonly DataContext context;
    private readonly IAppetizerRepository appetizerRepository;

    public AppetizerService(IMapper mapper, DataContext context, IAppetizerRepository appetizerRepository)
    {
      this.mapper = mapper;
      this.context = context;
      this.appetizerRepository = appetizerRepository;
    }
    public async Task<ServiceResponse<GetAppetizerDto>> AddNewAppetizer(AddAppetizerDto newAppetizer)
    {
      var serviceResponse = new ServiceResponse<GetAppetizerDto>();
      Appetizer appetizer = mapper.Map<Appetizer>(newAppetizer);
      // context.Appetizers.Add(appetizer);
      // await context.SaveChangesAsync();
      await appetizerRepository.AddNewAppetizer(appetizer);

      serviceResponse.Data = mapper.Map<GetAppetizerDto>(appetizer);
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
      var appetizer = await context.Appetizers.FirstOrDefaultAsync(appetizer => appetizer.Id == id);
      serviceResponse.Data = mapper.Map<GetAppetizerDto>(appetizer);
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetAppetizerDto>> UpdateAppetizer(UpdateAppetizerDto updatedAppetizer)
    {
      var serviceResponse = new ServiceResponse<GetAppetizerDto>();

      try
      {
        var appetizer = await context.Appetizers.FirstOrDefaultAsync(a => a.Id == updatedAppetizer.Id);

        appetizer.Title = updatedAppetizer.Title;
        appetizer.Description = updatedAppetizer.Description;
        appetizer.ImageUrl = updatedAppetizer.ImageUrl;
        appetizer.VideoUrl = updatedAppetizer.VideoUrl;
        appetizer.Type = updatedAppetizer.Type;
        appetizer.LastEdited = DateTime.Now;

        context.SaveChangesAsync();

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
        Appetizer appetizer = await context.Appetizers.FirstAsync(a => a.Id == id);
        context.Appetizers.Remove(appetizer);
        await context.SaveChangesAsync();

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