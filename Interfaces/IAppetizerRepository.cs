using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTableApi.Models;

namespace TheTableApi.Interfaces
{
  public interface IAppetizerRepository
  {
    public Task<Appetizer> AddNewAppetizer(Appetizer newAppetizer);
  }
}