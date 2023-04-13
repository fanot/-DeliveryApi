using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi.Models.Users;

public class UserEditModel
{
    [Required,MinLength(1)]
    public string FullName { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? Address { get; set; }

    [Required]
    [EnumDataType(typeof(Gender), ErrorMessage = "The field Gender is invalid.")]

    public Gender Gender { get; set; }
    [Required]
    public string? PhoneNumber { get; set; }

}