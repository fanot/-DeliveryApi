using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace WebApi.Models.Dish
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DishCategory
    {
        Wok, 
        Pizza, 
        Soup, 
        Dessert, 
        Drink

    }
}
