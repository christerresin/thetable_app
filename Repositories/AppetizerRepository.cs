using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTableApi.Data;
using TheTableApi.Interfaces;
using TheTableApi.Models;

namespace TheTableApi.Repositories
{
  public class AppetizerRepository : IAppetizerRepository
  {
    private readonly DataContext context;

    public AppetizerRepository(DataContext context)
    {
      this.context = context;
    }

    public async Task<Appetizer> AddNewAppetizer(Appetizer newAppetizer)
    {
      context.Appetizers.Add(newAppetizer);
      await context.SaveChangesAsync();
      return newAppetizer;
    }

  }
}