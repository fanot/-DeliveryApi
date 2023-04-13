using System.Text.Json.Serialization;

namespace WebApi.Models.Dish
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DishSorting
    {
        NameAsc, 
        NameDesc, 
        PriceAsc, 
        PriceDesc, 
        RatingAsc, 
        RatingDesc

    }
}
