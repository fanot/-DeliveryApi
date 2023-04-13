using System.Text.Json.Serialization;

namespace WebApi.Models.Order
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        InProcess, 
        Delivered
    }
}
