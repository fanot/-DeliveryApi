using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WebApi.Models.Dish;

namespace WebApi.Entities
{
    public class Dish
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required, MinLength(1)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public string Image { get; set; }
        public bool Vegetarian { get; set; }
        public double? Rating { get; set; }
        public DishCategory Category { get; set; }

        

        [JsonIgnore]
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
        [JsonIgnore]
        public ICollection<Order> Orders { get; set; } = new List<Order>();


    }

    public class DishBasketDTO
    {
       // public double? TotalPrice { get; set; }
        public int? Amount { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }


    }
}
