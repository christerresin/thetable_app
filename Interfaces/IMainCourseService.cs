using TheTableApi.Models;

namespace TheTableApi.Controllers
{
  public interface IMainCourseService
  {
    public Task<ServiceResponse<List<Meal>>> GetAllMainCourses();
  }
}