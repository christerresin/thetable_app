using System.Text.Json.Serialization;

namespace TheTableApi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MealType
    {
        Appetizer = 1,
        MainCourse = 2,
        Dessert = 3
    }
}