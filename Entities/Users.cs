namespace WebApi.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models.Users;

public class Users 
{
    [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    [Required, MinLength(1)]
    public string FullName { get; set; }
    [Required, MinLength(1)]
    [EmailAddress]
    public string Email { get; set; }
    public string? Address { get; set; }
    public DateTime? BirthDate { get; set; }
    [Required]
    public Gender Gender { get; set; }


    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }
   

    [JsonIgnore]
    public string PasswordHash { get; set; }
    [JsonIgnore]
    public string Token { get; set; }


    [JsonIgnore]
    public ICollection<Cart> Carts { get; set; }  = new List<Cart>();
    [JsonIgnore]
    public ICollection<Order> Orders { get; set; }  = new List<Order>();


}