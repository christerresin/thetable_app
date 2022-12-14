using Microsoft.AspNetCore.Mvc;
using TheTableApi.Dtos.Meal;
using TheTableApi.Models;

namespace TheTableApi.Controllers
{
  public interface IMainCourseService
  {
    Task<ServiceResponse<GetMealDto>> AddNewMainCourse(AddMealDto newMainCourse);
    Task<ServiceResponse<List<GetMealDto>>> GetAllMainCourses();
    Task<ServiceResponse<GetMealDto>> GetMainCourseById(int id);
    Task<ServiceResponse<GetMealDto>> UpdateMainCourse(UpdateMealDto updatedMainCourse);
    Task<ServiceResponse<GetMealDto>> DeleteMainCourse(int id);
  }
}