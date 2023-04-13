using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WebApi.Models.Order;
namespace WebApi.Entities
{
    public class Order
    {
       
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [ForeignKey("Cart")]
        public string Id { get; set; }
        [Required]
        public DateTime OrderTime { get; set; } 
        [Required]
        public DateTime? DeliveryTime { get; set; }

        [JsonIgnore]
        public Entities.Users Users { get; set; }

        [JsonIgnore]
        public int? Amount { get; set; }

        public OrderStatus Status { get; set; }

        public double? Price { get; set; }

        public string? Address { get; set; }

        

    }


}
