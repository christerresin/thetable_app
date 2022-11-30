using TheTableApi.Dtos.Meal;
using TheTableApi.Models;

namespace TheTableApi.Controllers
{
  public interface IMainCourseService
  {
    Task<ServiceResponse<GetMealDto>> AddNewMainCourse(AddMealDto newMainCourse);
    Task<ServiceResponse<List<Meal>>> GetAllMainCourses();
  }
}