namespace WebApi.Models.Users;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class UserRegisterModel
{
    [Required, MinLength(1)]
    public string FullName { get; set; }
    [Required,DataType(DataType.Password),MinLength(6)]
    public string Password { get; set; }
    
    [Required, MinLength(1)]
    [EmailAddress]

    public string Email { get; set; }

    public string? Address { get; set; }
    [Required]
    public DateTime? BirthDate { get; set; }

    [Required]
    [EnumDataType(typeof(Gender), ErrorMessage = "The field Gender is invalid.")]
    public Gender Gender { get; set; }

    [Required, DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }

  
}