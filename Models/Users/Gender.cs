using System.Text.Json.Serialization;

namespace WebApi.Models.Users
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {   
        Male,
        Female 
    }
}

