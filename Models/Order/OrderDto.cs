using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApi.Entities;
using WebApi.Models.Dish;

namespace WebApi.Models.Order
{
    public class OrderDetail 
    {
        public string Id { get; set; }

        [Required]
        public DateTime OrderTime { get; set; }
        [Required]
        public DateTime DeliveryTime { get; set; }
        [Required]
        public OrderStatus Status { get; set; }

        public double Price { get; set; }
        
        public string Address { get; set; }
    }
   public class OrderDto
    {
   

        public string Id { get; set; }

        [Required]
        public DateTime OrderTime { get; set; }
        [Required]
        public DateTime DeliveryTime { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required, MinLength(1)]
        public string Address { get; set; }
        public double? Price { get; set; }
        public List<DishBasketDTO> Basket { get; set; }

        /* public List<DishBasketDTO> Basket { get; set; }
         public List<OrderDetail> Detail { get; set; }
         public OrderDto(List<DishBasketDTO> basket, List<OrderDetail> detailOder)
         {
             Basket = basket;
             Detail = detailOder;
         }
         /*public OrderDto(DishBasketDTO dishes, OrderDetail details)
         {
             Dish = dishes;
             Detail = details;

         }*/


    }
}
